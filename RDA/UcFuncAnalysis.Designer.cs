namespace RDA
{
	partial class UcFuncAnalysis
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.bfft = new System.Windows.Forms.Button();
			this.bDown = new System.Windows.Forms.Button();
			this.bUp = new System.Windows.Forms.Button();
			this.bPolyharm = new System.Windows.Forms.Button();
			this.bHarm = new System.Windows.Forms.Button();
			this.bTrend = new System.Windows.Forms.Button();
			this.bJump = new System.Windows.Forms.Button();
			this.bNoise = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelS = new System.Windows.Forms.Label();
			this.labelM = new System.Windows.Forms.Label();
			this.labelDisp = new System.Windows.Forms.Label();
			this.bAC = new System.Windows.Forms.Button();
			this.bRAC = new System.Windows.Forms.Button();
			this.bP = new System.Windows.Forms.Button();
			this.zgc = new ZedGraph.ZedGraphControl();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bfft);
			this.panel1.Controls.Add(this.bDown);
			this.panel1.Controls.Add(this.bUp);
			this.panel1.Controls.Add(this.bPolyharm);
			this.panel1.Controls.Add(this.bHarm);
			this.panel1.Controls.Add(this.bTrend);
			this.panel1.Controls.Add(this.bJump);
			this.panel1.Controls.Add(this.bNoise);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.bAC);
			this.panel1.Controls.Add(this.bRAC);
			this.panel1.Controls.Add(this.bP);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(666, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(151, 577);
			this.panel1.TabIndex = 0;
			// 
			// bfft
			// 
			this.bfft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bfft.Location = new System.Drawing.Point(3, 362);
			this.bfft.Name = "bfft";
			this.bfft.Size = new System.Drawing.Size(145, 43);
			this.bfft.TabIndex = 12;
			this.bfft.Text = "Спектральный анализ";
			this.bfft.UseVisualStyleBackColor = true;
			this.bfft.Click += new System.EventHandler(this.bfft_Click);
			// 
			// bDown
			// 
			this.bDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bDown.Location = new System.Drawing.Point(3, 294);
			this.bDown.Name = "bDown";
			this.bDown.Size = new System.Drawing.Size(145, 26);
			this.bDown.TabIndex = 11;
			this.bDown.Text = "Опустить график";
			this.bDown.UseVisualStyleBackColor = true;
			this.bDown.Click += new System.EventHandler(this.bDown_Click);
			// 
			// bUp
			// 
			this.bUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bUp.Location = new System.Drawing.Point(3, 262);
			this.bUp.Name = "bUp";
			this.bUp.Size = new System.Drawing.Size(145, 26);
			this.bUp.TabIndex = 10;
			this.bUp.Text = "Поднять график";
			this.bUp.UseVisualStyleBackColor = true;
			this.bUp.Click += new System.EventHandler(this.bUp_Click);
			// 
			// bPolyharm
			// 
			this.bPolyharm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bPolyharm.Location = new System.Drawing.Point(3, 208);
			this.bPolyharm.Name = "bPolyharm";
			this.bPolyharm.Size = new System.Drawing.Size(145, 48);
			this.bPolyharm.TabIndex = 9;
			this.bPolyharm.Tag = "1";
			this.bPolyharm.Text = "Добавить полигарм. колеб.";
			this.bPolyharm.UseVisualStyleBackColor = true;
			this.bPolyharm.Click += new System.EventHandler(this.bPolyharm_Click);
			// 
			// bHarm
			// 
			this.bHarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bHarm.Location = new System.Drawing.Point(3, 176);
			this.bHarm.Name = "bHarm";
			this.bHarm.Size = new System.Drawing.Size(145, 26);
			this.bHarm.TabIndex = 8;
			this.bHarm.Tag = "1";
			this.bHarm.Text = "Добавить синус";
			this.bHarm.UseVisualStyleBackColor = true;
			this.bHarm.Click += new System.EventHandler(this.bHarm_Click);
			// 
			// bTrend
			// 
			this.bTrend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bTrend.Location = new System.Drawing.Point(3, 144);
			this.bTrend.Name = "bTrend";
			this.bTrend.Size = new System.Drawing.Size(145, 26);
			this.bTrend.TabIndex = 7;
			this.bTrend.Tag = "1";
			this.bTrend.Text = "Добавить тренд";
			this.bTrend.UseVisualStyleBackColor = true;
			this.bTrend.Click += new System.EventHandler(this.bTrend_Click);
			// 
			// bJump
			// 
			this.bJump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bJump.Location = new System.Drawing.Point(3, 112);
			this.bJump.Name = "bJump";
			this.bJump.Size = new System.Drawing.Size(145, 26);
			this.bJump.TabIndex = 6;
			this.bJump.Tag = "1";
			this.bJump.Text = "Добавить всплески";
			this.bJump.UseVisualStyleBackColor = true;
			this.bJump.Click += new System.EventHandler(this.bJump_Click);
			// 
			// bNoise
			// 
			this.bNoise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bNoise.Location = new System.Drawing.Point(3, 80);
			this.bNoise.Name = "bNoise";
			this.bNoise.Size = new System.Drawing.Size(145, 26);
			this.bNoise.TabIndex = 5;
			this.bNoise.Tag = "1";
			this.bNoise.Text = "Добавить шум";
			this.bNoise.UseVisualStyleBackColor = true;
			this.bNoise.Click += new System.EventHandler(this.bNoise_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelS);
			this.groupBox1.Controls.Add(this.labelM);
			this.groupBox1.Controls.Add(this.labelDisp);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(151, 76);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Характеристики";
			// 
			// labelS
			// 
			this.labelS.AutoSize = true;
			this.labelS.Location = new System.Drawing.Point(10, 52);
			this.labelS.Name = "labelS";
			this.labelS.Size = new System.Drawing.Size(33, 17);
			this.labelS.TabIndex = 2;
			this.labelS.Text = "S = ";
			// 
			// labelM
			// 
			this.labelM.AutoSize = true;
			this.labelM.Location = new System.Drawing.Point(8, 18);
			this.labelM.Name = "labelM";
			this.labelM.Size = new System.Drawing.Size(35, 17);
			this.labelM.TabIndex = 1;
			this.labelM.Text = "M = ";
			// 
			// labelDisp
			// 
			this.labelDisp.AutoSize = true;
			this.labelDisp.Location = new System.Drawing.Point(9, 35);
			this.labelDisp.Name = "labelDisp";
			this.labelDisp.Size = new System.Drawing.Size(34, 17);
			this.labelDisp.TabIndex = 0;
			this.labelDisp.Text = "D = ";
			// 
			// bAC
			// 
			this.bAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bAC.Location = new System.Drawing.Point(3, 480);
			this.bAC.Name = "bAC";
			this.bAC.Size = new System.Drawing.Size(145, 44);
			this.bAC.TabIndex = 3;
			this.bAC.Text = "Функция автокорреляции";
			this.bAC.UseVisualStyleBackColor = true;
			this.bAC.Click += new System.EventHandler(this.bAC_Click);
			// 
			// bRAC
			// 
			this.bRAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bRAC.Location = new System.Drawing.Point(3, 411);
			this.bRAC.Name = "bRAC";
			this.bRAC.Size = new System.Drawing.Size(145, 63);
			this.bRAC.TabIndex = 2;
			this.bRAC.Text = "Функция взаимной корреляции";
			this.bRAC.UseVisualStyleBackColor = true;
			this.bRAC.Click += new System.EventHandler(this.bRAC_Click);
			// 
			// bP
			// 
			this.bP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bP.Location = new System.Drawing.Point(3, 530);
			this.bP.Name = "bP";
			this.bP.Size = new System.Drawing.Size(145, 44);
			this.bP.TabIndex = 1;
			this.bP.Text = "Плотность вероятности";
			this.bP.UseVisualStyleBackColor = true;
			this.bP.Click += new System.EventHandler(this.bP_Click);
			// 
			// zgc
			// 
			this.zgc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zgc.Location = new System.Drawing.Point(0, 0);
			this.zgc.Margin = new System.Windows.Forms.Padding(5);
			this.zgc.Name = "zgc";
			this.zgc.ScrollGrace = 0D;
			this.zgc.ScrollMaxX = 0D;
			this.zgc.ScrollMaxY = 0D;
			this.zgc.ScrollMaxY2 = 0D;
			this.zgc.ScrollMinX = 0D;
			this.zgc.ScrollMinY = 0D;
			this.zgc.ScrollMinY2 = 0D;
			this.zgc.Size = new System.Drawing.Size(666, 577);
			this.zgc.TabIndex = 2;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Шум",
            "Полигармонический процесс",
            "Гармонический процесс",
            "Исходная Функция"});
			this.comboBox1.Location = new System.Drawing.Point(398, 550);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(265, 24);
			this.comboBox1.TabIndex = 13;
			this.comboBox1.Text = "Выберите коррелирующую функцию";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// UcFuncAnalysis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.zgc);
			this.Controls.Add(this.panel1);
			this.Name = "UcFuncAnalysis";
			this.Size = new System.Drawing.Size(817, 577);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private ZedGraph.ZedGraphControl zgc;
		private System.Windows.Forms.Button bAC;
		private System.Windows.Forms.Button bRAC;
		private System.Windows.Forms.Button bP;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelDisp;
		private System.Windows.Forms.Label labelS;
		private System.Windows.Forms.Label labelM;
		private System.Windows.Forms.Button bPolyharm;
		private System.Windows.Forms.Button bHarm;
		private System.Windows.Forms.Button bTrend;
		private System.Windows.Forms.Button bJump;
		private System.Windows.Forms.Button bNoise;
		private System.Windows.Forms.Button bUp;
		private System.Windows.Forms.Button bDown;
		private System.Windows.Forms.Button bfft;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}
