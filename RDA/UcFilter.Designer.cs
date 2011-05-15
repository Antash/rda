namespace RDA
{
	partial class UcFilter
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.filterParams = new System.Windows.Forms.GroupBox();
			this.ftype = new System.Windows.Forms.ComboBox();
			this.bbuild = new System.Windows.Forms.Button();
			this.mEditor = new RDA.UcParamEditor();
			this.dtEditor = new RDA.UcParamEditor();
			this.f1editor = new RDA.UcParamEditor();
			this.f2editor = new RDA.UcParamEditor();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.zgc = new ZedGraph.ZedGraphControl();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.filterParams.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// filterParams
			// 
			this.filterParams.Controls.Add(this.ftype);
			this.filterParams.Controls.Add(this.bbuild);
			this.filterParams.Controls.Add(this.mEditor);
			this.filterParams.Controls.Add(this.dtEditor);
			this.filterParams.Controls.Add(this.f1editor);
			this.filterParams.Controls.Add(this.f2editor);
			this.filterParams.Dock = System.Windows.Forms.DockStyle.Top;
			this.filterParams.Location = new System.Drawing.Point(3, 3);
			this.filterParams.Name = "filterParams";
			this.filterParams.Size = new System.Drawing.Size(124, 223);
			this.filterParams.TabIndex = 4;
			this.filterParams.TabStop = false;
			this.filterParams.Text = "filterParams";
			// 
			// ftype
			// 
			this.ftype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ftype.FormattingEnabled = true;
			this.ftype.Items.AddRange(new object[] {
            "Низкие",
            "Высокие",
            "Полосовой",
            "Режекторный"});
			this.ftype.Location = new System.Drawing.Point(5, 157);
			this.ftype.Name = "ftype";
			this.ftype.Size = new System.Drawing.Size(109, 24);
			this.ftype.TabIndex = 6;
			// 
			// bbuild
			// 
			this.bbuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bbuild.Location = new System.Drawing.Point(5, 187);
			this.bbuild.Name = "bbuild";
			this.bbuild.Size = new System.Drawing.Size(109, 29);
			this.bbuild.TabIndex = 4;
			this.bbuild.Text = "build";
			this.bbuild.UseVisualStyleBackColor = true;
			this.bbuild.Click += new System.EventHandler(this.bbuild_Click);
			// 
			// mEditor
			// 
			this.mEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mEditor.Location = new System.Drawing.Point(6, 89);
			this.mEditor.Name = "mEditor";
			this.mEditor.ParamValue = "value";
			this.mEditor.Size = new System.Drawing.Size(108, 28);
			this.mEditor.TabIndex = 2;
			// 
			// dtEditor
			// 
			this.dtEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtEditor.Location = new System.Drawing.Point(6, 123);
			this.dtEditor.Name = "dtEditor";
			this.dtEditor.ParamValue = "value";
			this.dtEditor.Size = new System.Drawing.Size(108, 28);
			this.dtEditor.TabIndex = 3;
			// 
			// f1editor
			// 
			this.f1editor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.f1editor.Location = new System.Drawing.Point(6, 23);
			this.f1editor.Name = "f1editor";
			this.f1editor.ParamValue = "value";
			this.f1editor.Size = new System.Drawing.Size(108, 26);
			this.f1editor.TabIndex = 0;
			// 
			// f2editor
			// 
			this.f2editor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.f2editor.Location = new System.Drawing.Point(6, 55);
			this.f2editor.Name = "f2editor";
			this.f2editor.ParamValue = "value";
			this.f2editor.Size = new System.Drawing.Size(108, 28);
			this.f2editor.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.filterParams, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 306F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 306);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.zgc, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.comboBox1, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(133, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(293, 300);
			this.tableLayoutPanel2.TabIndex = 5;
			// 
			// zgc
			// 
			this.zgc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zgc.Location = new System.Drawing.Point(5, 34);
			this.zgc.Margin = new System.Windows.Forms.Padding(5);
			this.zgc.Name = "zgc";
			this.zgc.ScrollGrace = 0D;
			this.zgc.ScrollMaxX = 0D;
			this.zgc.ScrollMaxY = 0D;
			this.zgc.ScrollMaxY2 = 0D;
			this.zgc.ScrollMinX = 0D;
			this.zgc.ScrollMinY = 0D;
			this.zgc.ScrollMinY2 = 0D;
			this.zgc.Size = new System.Drawing.Size(283, 261);
			this.zgc.TabIndex = 4;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Частотная характеристика",
            "Импульсная характеристика"});
			this.comboBox1.Location = new System.Drawing.Point(3, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(238, 24);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// UcFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "UcFilter";
			this.Size = new System.Drawing.Size(429, 306);
			this.filterParams.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UcParamEditor f1editor;
		private UcParamEditor f2editor;
		private UcParamEditor mEditor;
		private UcParamEditor dtEditor;
		private System.Windows.Forms.GroupBox filterParams;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private ZedGraph.ZedGraphControl zgc;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button bbuild;
		private System.Windows.Forms.ComboBox ftype;

	}
}
