using System;
using System.Drawing;
using System.Windows.Forms;

namespace RDA
{
	public partial class Picture : UserControl
	{
		private Bitmap _p;

		private double[][] _f;

		public Picture()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Application.StartupPath;
			openFileDialog1.ShowDialog();
			_p = new Bitmap(openFileDialog1.FileName);
			pictureBox1.Image = _p;
			_f = new double[_p.Width][];
			for (int i = 0; i < _p.Width; i++)
				_f[i] = new double[_p.Height];
			for (int i = 0; i < _p.Width; i++)
				for (int j = 0; j < _p.Height; j++)
					_f[i][j] = _p.GetPixel(i, j).R;
			FilterImg();
			Converttoimage();
		}

		public void Converttoimage()
		{
			var bmp = new Bitmap(_p.Width, _p.Height);
			for (int i = 0; i < bmp.Width; i++)
				for (int j = 0; j < bmp.Height; j++)
				{
					var c = Math.Min((int) Math.Abs(_f[i][j]), 255);
					bmp.SetPixel(i, j, Color.FromArgb(c, c, c));
				}
			pictureBox2.Image = bmp;
		}

		public void FilterImg()
		{
			var filter = Filter.Result(100, 100, 0.001);
			for (int i = 0; i < _p.Width; i++)
				_f[i] = Algorithms.Convolution(_f[i], filter);

			for (int i = 0; i < _p.Height; i++)
			{
				var tmp = new double[_p.Width];
				for (int j = 0; j < _p.Width; j++)
					tmp[j] = _f[j][i];
				tmp = Algorithms.Convolution(tmp, filter);
				for (int j = 0; j < _p.Width; j++)
					_f[j][i] = tmp[j];
			}
		}
	}
}
