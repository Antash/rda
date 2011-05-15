namespace RDA
{
	partial class UcParamEditor
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
			this.tlp = new System.Windows.Forms.TableLayoutPanel();
			this.lblParam = new System.Windows.Forms.Label();
			this.tbParamVal = new System.Windows.Forms.TextBox();
			this.tlp.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlp
			// 
			this.tlp.ColumnCount = 2;
			this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlp.Controls.Add(this.lblParam, 0, 0);
			this.tlp.Controls.Add(this.tbParamVal, 1, 0);
			this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlp.Location = new System.Drawing.Point(0, 0);
			this.tlp.Name = "tlp";
			this.tlp.RowCount = 1;
			this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlp.Size = new System.Drawing.Size(233, 40);
			this.tlp.TabIndex = 0;
			// 
			// lblParam
			// 
			this.lblParam.AutoSize = true;
			this.lblParam.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblParam.Location = new System.Drawing.Point(3, 0);
			this.lblParam.Name = "lblParam";
			this.lblParam.Size = new System.Drawing.Size(110, 40);
			this.lblParam.TabIndex = 0;
			this.lblParam.Text = "paramName";
			// 
			// tbParamVal
			// 
			this.tbParamVal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbParamVal.Location = new System.Drawing.Point(119, 3);
			this.tbParamVal.Name = "tbParamVal";
			this.tbParamVal.Size = new System.Drawing.Size(111, 22);
			this.tbParamVal.TabIndex = 1;
			this.tbParamVal.Text = "value";
			// 
			// UcParamEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tlp);
			this.Name = "UcParamEditor";
			this.Size = new System.Drawing.Size(233, 40);
			this.tlp.ResumeLayout(false);
			this.tlp.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlp;
		private System.Windows.Forms.Label lblParam;
		private System.Windows.Forms.TextBox tbParamVal;
	}
}
