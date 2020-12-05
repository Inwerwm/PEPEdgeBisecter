using PEPExtensions;
using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EdgeBisecter
{
    public partial class FormControl : Form
    {
        IPERunArgs Args { get; }
        IPXPmx Pmx { get; set; }

        public FormControl(IPERunArgs args)
        {
            Args = args;

            InitializeComponent();
            Reload();
        }

        internal void Reload()
        {
            Pmx = Args.Host.Connector.Pmx.GetCurrentState();
        }

        private void PositiveNumberOnlyValidation(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text != string.Empty)
                textbox.Text = uint.Parse(Regex.Replace(textbox.Text, @"[^0-9]", string.Empty)).ToString();
        }

        private void buttonGetEdgeVertex_Click(object sender, EventArgs e)
        {
            var selectedVertex = Args.Host.Connector.View.PmxView.GetSelectedVertexIndices();
            if (selectedVertex.Length != 2)
            {
                MessageBox.Show("分割する辺の頂点は、同じ面を構成する2つの頂点を選択してください。", "辺頂点選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBoxEdgeVertexNum1.Text = selectedVertex[0].ToString();
            textBoxEdgeVertexNum2.Text = selectedVertex[1].ToString();
        }

        private void buttonGetPositionVertex_Click(object sender, EventArgs e)
        {
            var selectedVertex = Args.Host.Connector.View.PmxView.GetSelectedVertexIndices();
            if (selectedVertex.Length != 1)
            {
                MessageBox.Show("頂点は1つだけ選択してください。", "位置基準頂点選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            textBoxPositionVertex.Text = selectedVertex[0].ToString();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (textBoxEdgeVertexNum1.Text == string.Empty || textBoxEdgeVertexNum2.Text == string.Empty)
            {
                MessageBox.Show("分割する辺の頂点を選択してください。", "辺頂点選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(radioButtonVertex.Checked && textBoxPositionVertex.Text == string.Empty)
            {
                MessageBox.Show("頂点で位置を指定して分割するときは、基準となる頂点を選択してください。", "辺頂点選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reload();
            IPXVertex edgeVertex1 = Pmx.Vertex[int.Parse(textBoxEdgeVertexNum1.Text)];
            IPXVertex edgeVertex2 = Pmx.Vertex[int.Parse(textBoxEdgeVertexNum2.Text)];
            IPXVertex positionVertex = null;

            float ratio = 0.5f;
            if (radioButtonVertex.Checked)
            {
                positionVertex = Pmx.Vertex[int.Parse(textBoxPositionVertex.Text)];
                var firstDistance = (positionVertex.Position - edgeVertex1.Position).Length();
                var secondDistance = (positionVertex.Position - edgeVertex2.Position).Length();
                ratio = firstDistance / (firstDistance + secondDistance);
            }

            try
            {
                var createdVertices = EdgeProcedure.Bisect(edgeVertex1, edgeVertex2, ratio, Pmx);
                if (radioButtonVertex.Checked)
                {
                    createdVertices.Position = positionVertex.Position.Clone();
                    // TODO: UVの移動処理
                    //       面を延伸した平面上への座標移動の射影分UVも移動させる。
                }
            }
            catch (Exception ex)
            {
                Utility.ShowExceptionMessage(ex);
                return;
            }
        }
    }
}
