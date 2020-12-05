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
    public class EdgeBisecter : IPEPlugin
    {
        private bool disposedValue;

        public string Name => "EdgeBisecter";

        public string Version => "1.0";

        public string Description => "EdgeBisecter";

        public IPEPluginOption Option => new PEPluginOption(false, true);


        public void Run(IPERunArgs args)
        {
            try
            {
                var pmx = args.Host.Connector.Pmx.GetCurrentState();

                // 選択頂点間を分割対象辺とする
                var targetVertices = args.Host.Connector.View.PmxView.GetSelectedVertexIndices().Select(id => pmx.Vertex[id]);
                if (targetVertices.Count() != 2)
                    throw new InvalidOperationException($"選択頂点が2つと違います。{Environment.NewLine}同一面を構成する2点のみ選択してください。");

                // モデル内の全面から取得した2頂点を内包する面を取得
                var allFaces = pmx.Material.SelectMany(material => material.Faces.Select<IPXFace, (IPXFace Face, IPXMaterial IncludeMaterial)>(face => (face, material)));
                var faceToBisect = allFaces.Where(face => face.Face.ToVertices().Contains(targetVertices));
                if (faceToBisect.Count() < 1)
                    throw new InvalidOperationException($"構成頂点として選択頂点を含む面を発見できませんでした。{Environment.NewLine}同一面を構成する2点のみ選択してください。");

                // 面を分割
                var createdItems = faceToBisect.Select(face => (BisectFace(face.Face, targetVertices), face.IncludeMaterial));
                // 新規生成された要素をモデルに追加
                foreach (((IPXFace Face, IPXVertex Vertex) Created, IPXMaterial IncludeMaterial) item in createdItems)
                {
                    pmx.Vertex.Add(item.Created.Vertex);
                    item.IncludeMaterial.Faces.Add(item.Created.Face);
                }

                Utility.Update(args.Host.Connector, pmx);
            }
            catch (InvalidOperationException ex)
            {
                Utility.ShowExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                Utility.ShowException(ex);
            }
        }

        private static IPXVertex CreateAverageVertex(IEnumerable<IPXVertex> targetVertices)
        {
            int targetCount = targetVertices.Count();

            // 平均頂点
            var averageVertex = PEStaticBuilder.Pmx.Vertex();

            // 各パラメータを選択頂点の平均に設定する
            averageVertex.EdgeScale = targetVertices.Select(v => v.EdgeScale).Sum() / targetCount;
            averageVertex.Position = targetVertices.Select(v => v.Position).Aggregate((sum, elm) => sum + elm) / targetCount;
            averageVertex.Normal = targetVertices.Select(v => v.Normal).Aggregate((sum, elm) => sum + elm) / targetCount;
            averageVertex.UV = targetVertices.Select(v => v.UV).Aggregate((sum, elm) => sum + elm) / targetCount;
            averageVertex.UVA1 = targetVertices.Any(ValueTuple => ValueTuple.UVA1 == null) ? null : targetVertices.Select(v => v.UVA1).Aggregate((sum, elm) => sum + elm) / targetCount;
            averageVertex.UVA2 = targetVertices.Any(ValueTuple => ValueTuple.UVA2 == null) ? null : targetVertices.Select(v => v.UVA2).Aggregate((sum, elm) => sum + elm) / targetCount;
            averageVertex.UVA3 = targetVertices.Any(ValueTuple => ValueTuple.UVA3 == null) ? null : targetVertices.Select(v => v.UVA3).Aggregate((sum, elm) => sum + elm) / targetCount;

            averageVertex.QDEF = targetVertices.Select(v => v.QDEF).Aggregate((sum, elm) => sum && elm);
            averageVertex.SDEF = targetVertices.Select(v => v.SDEF).Aggregate((sum, elm) => sum && elm);
            if (averageVertex.SDEF)
            {
                averageVertex.SDEF_C = targetVertices.Select(v => v.SDEF_C).Aggregate((sum, elm) => sum + elm) / targetCount;
                averageVertex.SDEF_R0 = targetVertices.Select(v => v.SDEF_R0).Aggregate((sum, elm) => sum + elm) / targetCount;
                averageVertex.SDEF_R1 = targetVertices.Select(v => v.SDEF_R1).Aggregate((sum, elm) => sum + elm) / targetCount;
            }

            // ウェイト処理
            var basisWeights = targetVertices.SelectMany(v => Utility.GetWeights(v));
            var mergedWeights = basisWeights.GroupBy(weight => weight.bone).Select(group => (group.Key, group.Sum(elm => elm.weight) / targetCount));
            Utility.SetVertexWeights(mergedWeights.ToList(), ref averageVertex);

            return averageVertex;
        }

        /// <summary>
        /// <para>面を指定頂点が構成する辺で二等分する</para>
        /// <para>引数の面は構成頂点の1つが新規生成頂点に差し替えられる</para>
        /// <para>分割によって生成された面と頂点は戻り値になる</para>
        /// </summary>
        /// <param name="targetFace">分割対象面</param>
        /// <param name="targetEdgeVertex">分割対象辺の構成頂点</param>
        /// <returns>分割によって新たに生成された面と頂点</returns>
        private (IPXFace CreatedFace, IPXVertex CreatedVertex) BisectFace(IPXFace targetFace, IEnumerable<IPXVertex> targetEdgeVertex)
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~Class1()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
