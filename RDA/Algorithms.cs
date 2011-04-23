using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDA
{
	class Algorithms
	{
		public static Complex[] SlowFurieTransformCplx(double[] f)
		{
			var res = new Complex[f.Length];
			double arg = 2 * Math.PI / f.Length;

			for (int i = 0; i < f.Length; i++)
			{
				res[i] = new Complex();
				for (int j = 0; j < f.Length; j++)
				{
					res[i].Real += f[j] * Math.Cos(arg * i * j);
					res[i].Imag -= f[j] * Math.Sin(arg * i * j);
				}
			}
			return res;
		}

		public static double[] SlowFurieTransform(double[] f)
		{
			var cplxRes = SlowFurieTransformCplx(f);
			var res = new double[f.Length];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxRes[i].Abs / f.Length;

			return res;
		}

		public static Complex[] SlowReverseFurieTransformCplx(Complex[] f)
		{
			var res = new Complex[f.Length];
			double arg = 2 * Math.PI / f.Length;

			for (int i = 0; i < f.Length; i++)
			{
				res[i] = new Complex();
				for (int j = 0; j < f.Length; j++)
				{
					res[i].Real += f[j].Real * Math.Cos(arg * i * j) - f[j].Imag * Math.Sin(arg * i * j);
					res[i].Imag += f[j].Imag * Math.Cos(arg * i * j) + f[j].Real * Math.Sin(arg * i * j);
				}
				res[i].Real /= f.Length;
				res[i].Imag /= f.Length;
			}

			return res;
		}

		public static double[] SlowReverseFurieTransform(Complex[] f)
		{
			var cplxRes = SlowReverseFurieTransformCplx(f);
			var res = new double[cplxRes.Length];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxRes[i].Real + cplxRes[i].Imag;

			return res;
		}

		public static double[] Convolution(double[] x, double[] h)
		{
			var tmpres = new double[x.Length + h.Length];

			for (int i = 0; i < tmpres.Length; i++)
			{
				double t = 0;
				for (int j = 0; j < i; j++)
					if ((j < h.Length) && (i - j < x.Length))
						t += h[j] * x[i - j];
				tmpres[i] = t;
			}

			var res = new double[x.Length];

			for (int i = 0, j = h.Length / 2; i < res.Length; i++, j++)
				res[i] = tmpres[j];

			return res;
		}

		private const double Alpha = 0.1;

		public static double[] Deconvolution(double[] y, double[] h)
		{
			var H = SlowFurieTransformCplx(h.Concat(new double[y.Length - h.Length]).ToArray());
			var Y = SlowFurieTransformCplx(y);
			var G = new Complex[H.Length];
			var X = new Complex[Y.Length];

			for (int i = 0; i < H.Length; i++)
			{
				double div = H[i].Abs * H[i].Abs + Alpha * Alpha;
				G[i] = new Complex
						{
							Real = H[i].Real / div,
							Imag = -H[i].Imag / div
						};
			}

			for (int i = 0; i < X.Length; i++)
			{
				X[i] = new Complex
						{
							Real = Y[i].Real * G[i].Real - Y[i].Imag * G[i].Imag,
							Imag = Y[i].Real * G[i].Imag + Y[i].Imag * G[i].Real
						};
			}

			return SlowReverseFurieTransform(X);
		}
	}
}
