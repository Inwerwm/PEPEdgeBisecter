
namespace EdgeBisecter
{
    partial class FormControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonHalf = new System.Windows.Forms.RadioButton();
            this.radioButtonVertex = new System.Windows.Forms.RadioButton();
            this.groupBoxSeparatePosition = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelPositionVertex = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGetPositionVertex = new System.Windows.Forms.Button();
            this.textBoxPositionVertex = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelEdgeVertex = new System.Windows.Forms.TableLayoutPanel();
            this.labelEdgeVertex = new System.Windows.Forms.Label();
            this.buttonGetEdgeVertex = new System.Windows.Forms.Button();
            this.textBoxEdgeVertexNum1 = new System.Windows.Forms.TextBox();
            this.textBoxEdgeVertexNum2 = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.groupBoxSeparatePosition.SuspendLayout();
            this.tableLayoutPanelPositionVertex.SuspendLayout();
            this.tableLayoutPanelEdgeVertex.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonHalf
            // 
            this.radioButtonHalf.AutoSize = true;
            this.radioButtonHalf.Location = new System.Drawing.Point(153, 26);
            this.radioButtonHalf.Name = "radioButtonHalf";
            this.radioButtonHalf.Size = new System.Drawing.Size(72, 24);
            this.radioButtonHalf.TabIndex = 0;
            this.radioButtonHalf.Text = "二等分";
            this.radioButtonHalf.UseVisualStyleBackColor = true;
            // 
            // radioButtonVertex
            // 
            this.radioButtonVertex.AutoSize = true;
            this.radioButtonVertex.Checked = true;
            this.radioButtonVertex.Location = new System.Drawing.Point(6, 26);
            this.radioButtonVertex.Name = "radioButtonVertex";
            this.radioButtonVertex.Size = new System.Drawing.Size(99, 24);
            this.radioButtonVertex.TabIndex = 1;
            this.radioButtonVertex.TabStop = true;
            this.radioButtonVertex.Text = "頂点で指定";
            this.radioButtonVertex.UseVisualStyleBackColor = true;
            // 
            // groupBoxSeparatePosition
            // 
            this.groupBoxSeparatePosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSeparatePosition.Controls.Add(this.tableLayoutPanelPositionVertex);
            this.groupBoxSeparatePosition.Controls.Add(this.radioButtonVertex);
            this.groupBoxSeparatePosition.Controls.Add(this.radioButtonHalf);
            this.groupBoxSeparatePosition.Location = new System.Drawing.Point(12, 89);
            this.groupBoxSeparatePosition.Name = "groupBoxSeparatePosition";
            this.groupBoxSeparatePosition.Size = new System.Drawing.Size(463, 92);
            this.groupBoxSeparatePosition.TabIndex = 2;
            this.groupBoxSeparatePosition.TabStop = false;
            this.groupBoxSeparatePosition.Text = "辺の分割位置";
            // 
            // tableLayoutPanelPositionVertex
            // 
            this.tableLayoutPanelPositionVertex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPositionVertex.ColumnCount = 2;
            this.tableLayoutPanelPositionVertex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPositionVertex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelPositionVertex.Controls.Add(this.buttonGetPositionVertex, 1, 0);
            this.tableLayoutPanelPositionVertex.Controls.Add(this.textBoxPositionVertex, 0, 0);
            this.tableLayoutPanelPositionVertex.Location = new System.Drawing.Point(0, 56);
            this.tableLayoutPanelPositionVertex.Name = "tableLayoutPanelPositionVertex";
            this.tableLayoutPanelPositionVertex.RowCount = 1;
            this.tableLayoutPanelPositionVertex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPositionVertex.Size = new System.Drawing.Size(463, 33);
            this.tableLayoutPanelPositionVertex.TabIndex = 2;
            // 
            // buttonGetPositionVertex
            // 
            this.buttonGetPositionVertex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetPositionVertex.Location = new System.Drawing.Point(316, 3);
            this.buttonGetPositionVertex.Name = "buttonGetPositionVertex";
            this.buttonGetPositionVertex.Size = new System.Drawing.Size(144, 27);
            this.buttonGetPositionVertex.TabIndex = 1;
            this.buttonGetPositionVertex.Text = "選択頂点から取得";
            this.buttonGetPositionVertex.UseVisualStyleBackColor = true;
            this.buttonGetPositionVertex.Click += new System.EventHandler(this.buttonGetPositionVertex_Click);
            // 
            // textBoxPositionVertex
            // 
            this.textBoxPositionVertex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPositionVertex.Location = new System.Drawing.Point(3, 3);
            this.textBoxPositionVertex.Name = "textBoxPositionVertex";
            this.textBoxPositionVertex.Size = new System.Drawing.Size(307, 27);
            this.textBoxPositionVertex.TabIndex = 2;
            this.textBoxPositionVertex.TextChanged += new System.EventHandler(this.PositiveNumberOnlyValidation);
            // 
            // tableLayoutPanelEdgeVertex
            // 
            this.tableLayoutPanelEdgeVertex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelEdgeVertex.ColumnCount = 3;
            this.tableLayoutPanelEdgeVertex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelEdgeVertex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEdgeVertex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelEdgeVertex.Controls.Add(this.labelEdgeVertex, 0, 0);
            this.tableLayoutPanelEdgeVertex.Controls.Add(this.buttonGetEdgeVertex, 2, 0);
            this.tableLayoutPanelEdgeVertex.Controls.Add(this.textBoxEdgeVertexNum1, 1, 0);
            this.tableLayoutPanelEdgeVertex.Controls.Add(this.textBoxEdgeVertexNum2, 1, 1);
            this.tableLayoutPanelEdgeVertex.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelEdgeVertex.Name = "tableLayoutPanelEdgeVertex";
            this.tableLayoutPanelEdgeVertex.RowCount = 2;
            this.tableLayoutPanelEdgeVertex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelEdgeVertex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelEdgeVertex.Size = new System.Drawing.Size(463, 71);
            this.tableLayoutPanelEdgeVertex.TabIndex = 3;
            // 
            // labelEdgeVertex
            // 
            this.labelEdgeVertex.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEdgeVertex.AutoSize = true;
            this.labelEdgeVertex.Location = new System.Drawing.Point(15, 25);
            this.labelEdgeVertex.Name = "labelEdgeVertex";
            this.tableLayoutPanelEdgeVertex.SetRowSpan(this.labelEdgeVertex, 2);
            this.labelEdgeVertex.Size = new System.Drawing.Size(119, 20);
            this.labelEdgeVertex.TabIndex = 0;
            this.labelEdgeVertex.Text = "分割する辺の頂点";
            // 
            // buttonGetEdgeVertex
            // 
            this.buttonGetEdgeVertex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetEdgeVertex.Location = new System.Drawing.Point(316, 3);
            this.buttonGetEdgeVertex.Name = "buttonGetEdgeVertex";
            this.tableLayoutPanelEdgeVertex.SetRowSpan(this.buttonGetEdgeVertex, 2);
            this.buttonGetEdgeVertex.Size = new System.Drawing.Size(144, 65);
            this.buttonGetEdgeVertex.TabIndex = 1;
            this.buttonGetEdgeVertex.Text = "選択頂点から取得";
            this.buttonGetEdgeVertex.UseVisualStyleBackColor = true;
            this.buttonGetEdgeVertex.Click += new System.EventHandler(this.buttonGetEdgeVertex_Click);
            // 
            // textBoxEdgeVertexNum1
            // 
            this.textBoxEdgeVertexNum1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEdgeVertexNum1.Location = new System.Drawing.Point(153, 4);
            this.textBoxEdgeVertexNum1.Name = "textBoxEdgeVertexNum1";
            this.textBoxEdgeVertexNum1.Size = new System.Drawing.Size(157, 27);
            this.textBoxEdgeVertexNum1.TabIndex = 2;
            this.textBoxEdgeVertexNum1.TextChanged += new System.EventHandler(this.PositiveNumberOnlyValidation);
            // 
            // textBoxEdgeVertexNum2
            // 
            this.textBoxEdgeVertexNum2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEdgeVertexNum2.Location = new System.Drawing.Point(153, 39);
            this.textBoxEdgeVertexNum2.Name = "textBoxEdgeVertexNum2";
            this.textBoxEdgeVertexNum2.Size = new System.Drawing.Size(157, 27);
            this.textBoxEdgeVertexNum2.TabIndex = 2;
            this.textBoxEdgeVertexNum2.TextChanged += new System.EventHandler(this.PositiveNumberOnlyValidation);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Location = new System.Drawing.Point(12, 207);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(463, 50);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.tableLayoutPanelEdgeVertex);
            this.Controls.Add(this.groupBoxSeparatePosition);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(500, 270);
            this.Name = "FormControl";
            this.Text = "辺を分割";
            this.groupBoxSeparatePosition.ResumeLayout(false);
            this.groupBoxSeparatePosition.PerformLayout();
            this.tableLayoutPanelPositionVertex.ResumeLayout(false);
            this.tableLayoutPanelPositionVertex.PerformLayout();
            this.tableLayoutPanelEdgeVertex.ResumeLayout(false);
            this.tableLayoutPanelEdgeVertex.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEdgeVertex;
        private System.Windows.Forms.RadioButton radioButtonHalf;
        private System.Windows.Forms.RadioButton radioButtonVertex;
        private System.Windows.Forms.GroupBox groupBoxSeparatePosition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPositionVertex;
        private System.Windows.Forms.Button buttonGetPositionVertex;
        private System.Windows.Forms.TextBox textBoxPositionVertex;
        private System.Windows.Forms.Label labelEdgeVertex;
        private System.Windows.Forms.Button buttonGetEdgeVertex;
        private System.Windows.Forms.TextBox textBoxEdgeVertexNum1;
        private System.Windows.Forms.TextBox textBoxEdgeVertexNum2;
        private System.Windows.Forms.Button buttonRun;
    }
}