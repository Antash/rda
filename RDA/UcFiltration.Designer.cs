namespace RDA
{
	partial class UcFiltration
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.zgcfiltered = new ZedGraph.ZedGraphControl();
			this.zgc = new ZedGraph.ZedGraphControl();
			this.ucFilter1 = new RDA.UcFilter();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 412F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.ucFilter1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 553);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.zgcfiltered, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.zgc, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(415, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(367, 547);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// zgcfiltered
			// 
			this.zgcfiltered.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zgcfiltered.Location = new System.Drawing.Point(5, 278);
			this.zgcfiltered.Margin = new System.Windows.Forms.Padding(5);
			this.zgcfiltered.Name = "zgcfiltered";
			this.zgcfiltered.ScrollGrace = 0D;
			this.zgcfiltered.ScrollMaxX = 0D;
			this.zgcfiltered.ScrollMaxY = 0D;
			this.zgcfiltered.ScrollMaxY2 = 0D;
			this.zgcfiltered.ScrollMinX = 0D;
			this.zgcfiltered.ScrollMinY = 0D;
			this.zgcfiltered.ScrollMinY2 = 0D;
			this.zgcfiltered.Size = new System.Drawing.Size(357, 264);
			this.zgcfiltered.TabIndex = 4;
			// 
			// zgc
			// 
			this.zgc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zgc.Location = new System.Drawing.Point(5, 5);
			this.zgc.Margin = new System.Windows.Forms.Padding(5);
			this.zgc.Name = "zgc";
			this.zgc.ScrollGrace = 0D;
			this.zgc.ScrollMaxX = 0D;
			this.zgc.ScrollMaxY = 0D;
			this.zgc.ScrollMaxY2 = 0D;
			this.zgc.ScrollMinX = 0D;
			this.zgc.ScrollMinY = 0D;
			this.zgc.ScrollMinY2 = 0D;
			this.zgc.Size = new System.Drawing.Size(357, 263);
			this.zgc.TabIndex = 3;
			// 
			// ucFilter1
			// 
			this.ucFilter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucFilter1.Location = new System.Drawing.Point(3, 3);
			this.ucFilter1.Name = "ucFilter1";
			this.ucFilter1.Size = new System.Drawing.Size(406, 312);
			this.ucFilter1.TabIndex = 0;
			// 
			// UcFiltration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "UcFiltration";
			this.Size = new System.Drawing.Size(785, 553);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private UcFilter ucFilter1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private ZedGraph.ZedGraphControl zgcfiltered;
		private ZedGraph.ZedGraphControl zgc;
	}
}
