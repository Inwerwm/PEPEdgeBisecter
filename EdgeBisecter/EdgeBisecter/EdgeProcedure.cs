using PEPExtensions;
using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeBisecter
{
    static class EdgeProcedure
    {
        public static IPXVertex Bisect(IPXVertex edgeVertex1, IPXVertex edgeVertex2, float ratio, IPXPmx pmx)
        {
            try
            {
                // 選択頂点間を分割対象辺とする
                // モデル内の全面から取得した2頂点を内包する面を取得
                var allFaces = pmx.Material.SelectMany(material => material.Faces.Select<IPXFace, (IPXFace Face, IPXMaterial IncludeMaterial)>(face => (face, material)));
                var faceToBisect = allFaces.Where(face =>
                {
                    IPXVertex[] vertices = face.Face.ToVertices();
                    return vertices.Contains(edgeVertex1) && vertices.Contains(edgeVertex2);
                });

                if (faceToBisect.Count() < 1)
                    throw new InvalidOperationException($"構成頂点として選択頂点を含む面を発見できませんでした。{Environment.NewLine}同一面を構成する2点のみ選択してください。");

                // 分割頂点を生成
                var separateVertex = CreateAverageVertex(new (IPXVertex, float)[] { (edgeVertex1, ratio), (edgeVertex2, 1 - ratio) });

                // 面を分割
                var createdFaces = faceToBisect.Select(face => (BisectFace(face.Face, edgeVertex1, edgeVertex2, separateVertex), face.IncludeMaterial));
                
                // 新規生成された要素をモデルに追加
                pmx.Vertex.Add(separateVertex);
                foreach ((IPXFace Face, IPXMaterial IncludeMaterial) item in createdFaces)
                {
                    item.IncludeMaterial.Faces.Add(item.Face);
                }

                return separateVertex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// パラメータが加重平均で設定された頂点を生成する
        /// </summary>
        /// <param name="sourceVertices">平均する頂点コレクション</param>
        /// <returns>生成頂点</returns>
        private static IPXVertex CreateAverageVertex(IEnumerable<(IPXVertex Vertex, float AverageWeight)> sourceVertices)
        {
            // 平均頂点
            var averageVertex = PEStaticBuilder.Pmx.Vertex();

            // 各パラメータを選択頂点の荷重平均に設定する
            averageVertex.EdgeScale = sourceVertices.Select(v => v.Vertex.EdgeScale * v.AverageWeight).Sum();
            averageVertex.Position = sourceVertices.Select(v => v.Vertex.Position * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
            averageVertex.Normal = sourceVertices.Select(v => v.Vertex.Normal * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
            averageVertex.UV = sourceVertices.Select(v => v.Vertex.UV * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
            averageVertex.UVA1 = sourceVertices.Any(v => v.Vertex.UVA1 * v.AverageWeight == null) ? null : sourceVertices.Select(v => v.Vertex.UVA1 * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
            averageVertex.UVA2 = sourceVertices.Any(v => v.Vertex.UVA2 * v.AverageWeight == null) ? null : sourceVertices.Select(v => v.Vertex.UVA2 * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
            averageVertex.UVA3 = sourceVertices.Any(v => v.Vertex.UVA3 * v.AverageWeight == null) ? null : sourceVertices.Select(v => v.Vertex.UVA3 * v.AverageWeight).Aggregate((sum, elm) => sum + elm);

            averageVertex.QDEF = sourceVertices.Select(v => v.Vertex.QDEF).Aggregate((sum, elm) => sum && elm);
            averageVertex.SDEF = sourceVertices.Select(v => v.Vertex.SDEF).Aggregate((sum, elm) => sum && elm);
            if (averageVertex.SDEF)
            {
                averageVertex.SDEF_C = sourceVertices.Select(v => v.Vertex.SDEF_C * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
                averageVertex.SDEF_R0 = sourceVertices.Select(v => v.Vertex.SDEF_R0 * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
                averageVertex.SDEF_R1 = sourceVertices.Select(v => v.Vertex.SDEF_R1 * v.AverageWeight).Aggregate((sum, elm) => sum + elm);
            }

            // ウェイト処理

            // 頂点のボーン・ウェイトを取得
            var basisWeights = sourceVertices.Select(v => (Utility.GetWeights(v.Vertex), v.AverageWeight));
            // ウェイトに荷重をかける
            var scaledWeights = basisWeights.SelectMany(elm => elm.Item1.Select(bw => (bw.bone, bw.weight * elm.AverageWeight)));
            // ボーンでグループ化し、同一ボーンのウェイトを積算する
            var mergedWeights = scaledWeights.GroupBy(weight => weight.bone).Select(group => (group.Key, group.Sum(elm => elm.Item2)));
            // ウェイト情報を平均頂点に反映
            Utility.SetVertexWeights(mergedWeights.ToList(), ref averageVertex);

            return averageVertex;
        }

        /// <summary>
        /// <para>面の指定頂点から構成される辺を分割する</para>
        /// <para>引数の面は構成頂点の1つが分割用頂点に差し替えられる</para>
        /// <para>分割によって生成された面は戻り値になる</para>
        /// </summary>
        /// <param name="targetFace">分割対象面</param>
        /// <param name="edgeVertex1">分割する辺の頂点1</param>
        /// <param name="edgeVertex2">分割する辺の頂点2</param>
        /// <param name="separateVertex">分割用頂点</param>
        /// <returns>分割によって新たに生成された面</returns>
        private static IPXFace BisectFace(IPXFace targetFace, IPXVertex edgeVertex1, IPXVertex edgeVertex2, IPXVertex separateVertex)
        {
            //var separateVertex = CreateAverageVertex(new (IPXVertex, float)[] { (edgeVertex1, ratio), (edgeVertex2, 1 - ratio) });

            var newFace = (IPXFace)targetFace.Clone();
            var edge = getEdgeInfo(targetFace, edgeVertex1, edgeVertex2);

            if (targetFace.Vertex1 == edge.afterVertex)
                targetFace.Vertex1 = separateVertex;
            if (targetFace.Vertex2 == edge.afterVertex)
                targetFace.Vertex2 = separateVertex;
            if (targetFace.Vertex3 == edge.afterVertex)
                targetFace.Vertex3 = separateVertex;

            if (newFace.Vertex1 == edge.beforeVertex)
                newFace.Vertex1 = separateVertex;
            if (newFace.Vertex2 == edge.beforeVertex)
                newFace.Vertex2 = separateVertex;
            if (newFace.Vertex3 == edge.beforeVertex)
                newFace.Vertex3 = separateVertex;

            return newFace;
        }

        /// <summary>
        /// 面と対面頂点群から面内の頂点情報を取得
        /// </summary>
        /// <param name="face">調査する面</param>
        /// <param name="edgeVertices">辺の構成頂点</param>
        /// <returns>面内頂点情報</returns>
        private static (IPXVertex beforeVertex, IPXVertex afterVertex) getEdgeInfo(IPXFace face, IPXVertex edgeVertex1, IPXVertex edgeVertex2)
        {
            // 最初の頂点が外側頂点
            if (face.Vertex1 != edgeVertex1 && face.Vertex1 != edgeVertex2)
                return (face.Vertex2, face.Vertex3);

            // 中間の頂点が外側頂点
            if (face.Vertex2 != edgeVertex1 && face.Vertex2 != edgeVertex2)
                return (face.Vertex3, face.Vertex1);

            // 最後の頂点が外側頂点
            return (face.Vertex1, face.Vertex2);
        }
    }
}
