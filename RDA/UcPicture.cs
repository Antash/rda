using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RDA
{
	public partial class UcPicture : UserControl
	{
		private Bitmap _p;
		private Histogramm hRed;

		private double[][] _f;

		public UcPicture()
		{
			InitializeComponent();
		}

		public void Converttoimage()
		{
			var bmp = new Bitmap(_p.Width, _p.Height);
			for (int i = 0; i < bmp.Width; i++)
				for (int j = 0; j < bmp.Height; j++)
				{
					var c = Math.Min((int)Math.Abs(_f[i][j]), 255);
					bmp.SetPixel(i, j, Color.FromArgb(c, c, c));
				}
			pictureBox1.Image = bmp;
		}

		public void FilterImg()
		{
			var filter = ucFilter1.FilterFunc;
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

		private void button2_Click(object sender, EventArgs e)
		{
			hRed = new Histogramm((Bitmap) pictureBox1.Image, 0);
			hRed.DrawHistogramm(ref pictureBox2);
		}

		public class Histogramm
		{
			Bitmap histogramFor;
			int chanel;
			int[] histogrammArray;
			int[] PhistogrammArray;

			public Histogramm(Bitmap SourceImage, int Chanel)
			{
				histogramFor = SourceImage;
				if (Chanel > 2)
					throw new Exception("Chanel index must be between 0..2");
				chanel = Chanel;
				BuildArray();
				buildPhist();
			}

			void buildPhist()
			{
				PhistogrammArray = new int[256];
				int currsumm = 0;
				for (int i = 0; i < 256; i++)
				{
					currsumm += histogrammArray[i];
					PhistogrammArray[i] = currsumm;
				}
				double divisor = currsumm / 255.0;
				for (int i = 0; i < 256; i++)
				{
					PhistogrammArray[i] = (int) (PhistogrammArray[i] / divisor);
				}
			}

			void BuildArray()
			{
				Bitmap bmp = new Bitmap(histogramFor);
				histogrammArray = new int[256];
				for (int i = 0; i < bmp.Width; i++)
					for (int j = 0; j < bmp.Height; j++)
					{
						switch (chanel)
						{
							case 0:
								histogrammArray[bmp.GetPixel(i, j).R]++;
								break;
							case 1:
								histogrammArray[bmp.GetPixel(i, j).G]++;
								break;
							case 2:
								histogrammArray[bmp.GetPixel(i, j).B]++;
								break;
						}
					}
			}

			public void DrawPHistogramm(ref PictureBox DrawTo)
			{
				Bitmap bmp = new Bitmap(DrawTo.Width, DrawTo.Height);
				Graphics g = Graphics.FromImage(bmp);
				Brush HBrush = Brushes.Blue;
				//switch (chanel)
				//{
				//    case 0:
				//        HBrush = Brushes.Red;
				//        break;
				//    case 1:
				//        HBrush = Brushes.Green;
				//        break;
				//    case 2:
				//        HBrush = Brushes.Blue;
				//        break;
				//}
				//Вычеслим относительные коэффициенты
				float DeltaHeight = (float)bmp.Height / (float)PhistogrammArray.Max();
				float DeltaWidth = (float)bmp.Width / 256;
				//строим
				for (int i = 0; i < 256; i++)
				{
					g.FillRectangle(HBrush, (float)i * DeltaWidth, bmp.Height - (float)PhistogrammArray[i] * DeltaHeight, DeltaWidth, bmp.Height);
				}
				DrawTo.Image = bmp;
			}

			public void DrawHistogramm(ref PictureBox DrawTo)
			{
				Bitmap bmp = new Bitmap(DrawTo.Width, DrawTo.Height);
				Graphics g = Graphics.FromImage(bmp);
				Brush HBrush = Brushes.Black;
				//switch (chanel)
				//{
				//    case 0:
				//        HBrush = Brushes.Red;
				//        break;
				//    case 1:
				//        HBrush = Brushes.Green;
				//        break;
				//    case 2:
				//        HBrush = Brushes.Blue;
				//        break;
				//}
				//Вычеслим относительные коэффициенты
				float DeltaHeight = (float)bmp.Height / (float)histogrammArray.Max();
				float DeltaWidth = (float)bmp.Width / 256;
				//строим
				for (int i = 0; i < 256; i++)
				{
					g.FillRectangle(HBrush, (float)i * DeltaWidth, bmp.Height - (float)histogrammArray[i] * DeltaHeight, DeltaWidth, bmp.Height);
				}
				DrawTo.Image = bmp;
			}

			public Bitmap Evaluate()
			{
				var bmp = new Bitmap(histogramFor.Width, histogramFor.Height);
				for (int i = 0; i < histogramFor.Width; i++)
					for (int j = 0; j < histogramFor.Height; j++)
					{
						int r = histogramFor.GetPixel(i, j).R;
						int nr = PhistogrammArray[r];
						bmp.SetPixel(i, j, Color.FromArgb(nr, nr, nr));
					}
				return bmp;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Application.StartupPath;
			openFileDialog1.ShowDialog();
			_p = new Bitmap(openFileDialog1.FileName);
			pictureBox1.Image = _p;
			convertFromImage(_p);
		}

		void convertFromImage(Bitmap img)
		{
			_f = new double[img.Width][];
			for (int i = 0; i < img.Width; i++)
				_f[i] = new double[img.Height];
			for (int i = 0; i < img.Width; i++)
				for (int j = 0; j < img.Height; j++)
					_f[i][j] = img.GetPixel(i, j).R;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FilterImg();
			Converttoimage();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			hRed = new Histogramm((Bitmap)pictureBox1.Image, 0);
			var bmp = hRed.Evaluate();
			pictureBox1.Image = bmp;
			convertFromImage(bmp);
			_p = bmp;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			hRed = new Histogramm((Bitmap)pictureBox1.Image, 0);
			hRed.DrawPHistogramm(ref pictureBox2);
			//hRed.DrawHistogramm(ref pictureBox2);
		}
	}
}
