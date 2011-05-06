using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDA
{
	public partial class Picture : UserControl
	{
		private Bitmap p;

		private double[,] f;

		public Picture()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Application.StartupPath;
			DialogResult dr = openFileDialog1.ShowDialog();
			p = new Bitmap(openFileDialog1.FileName);
			pictureBox1.Image = p;
			f = new double[p.Width,p.Height];
			for (int i = 0; i < p.Width; i++)
				for (int j = 0; j < p.Height; j++)
					f[i, j] = p.GetPixel(i, j).R;
			//Algorithms.Convolution()
		}
	}
}
