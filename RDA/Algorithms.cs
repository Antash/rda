using System;
using System.Linq;

namespace RDA
{
	class Algorithms
	{
		public static Complex[] FastReverseFourierTransformCplx(Complex[] f)
		{
			var nn = (int)Math.Pow(2, Math.Floor(Math.Log(f.Length) / Math.Log(2)));

			var res = Fft(f, nn, true);

			return res;
		}

		public static double[] FastReverseFourierTransform(Complex[] f)
		{
			var cplxRes = FastReverseFourierTransformCplx(f);

			var res = new double[cplxRes.Length];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxRes[i].Real + cplxRes[i].Imag;

			return res;
		}

		private static Complex[] Fft(double[] f, int nn, bool reverce)
		{
			var cplxf = new Complex[f.Length];

			for (int i = 0; i < f.Length; i++)
				cplxf[i] = new Complex(f[i], 0);

			return Fft(cplxf, nn, reverce);
		}

		private static Complex[] Fft(Complex[] f, int nn, bool reverce)
		{
			var data = new double[2 * nn + 1];
			double tempr;

			int isign = reverce ? 1 : -1;

			for (int k = 0; k < nn; k++)
			{
				data[k * 2] = f[k].Imag;
				data[k * 2 + 1] = f[k].Real;
			}

			int n = nn * 2;
			int m;
			int i = 1;
			int j = 1;
			while (i < n)
			{
				if (j > i)
				{
					tempr = data[i];
					data[i] = data[j];
					data[j] = tempr;
					tempr = data[i + 1];
					data[i + 1] = data[j + 1];
					data[j + 1] = tempr;
				}
				m = n / 2;
				while ((m >= 2) && (j > m))
				{
					j = j - m;
					m = m / 2;
				}
				j = j + m;
				i = i + 2;
			}

			int mmax = 2;
			while (n > mmax)
			{
				int istep = 2 * mmax;
				double theta = 2.0 * Math.PI / (isign * mmax);
				double wtemp = Math.Sin(0.5 * theta);
				double wpr = -2.0 * wtemp * wtemp;
				double wpi = Math.Sin(theta);
				double wr = 1.0;
				double wi = 0.0;
				m = 1;
				while (m < mmax)
				{
					i = m;
					while (i < n)
					{
						j = i + mmax;
						tempr = wr * data[j] - wi * data[j + 1];
						double tempi = wr * data[j + 1] + wi * data[j];
						data[j] = data[i] - tempr;
						data[j + 1] = data[i + 1] - tempi;
						data[i] = data[i] + tempr;
						data[i + 1] = data[i + 1] + tempi;
						i = i + istep;
					}
					wtemp = wr;
					wr = wtemp * wpr - wi * wpi + wr;
					wi = wi * wpr + wtemp * wpi + wi;
					m = m + 2;
				}
				mmax = istep;
			}
			var res = new Complex[nn];

			for (i = 0; i < nn; i++)
			{
				res[i] = new Complex
				{
					Real = reverce ? data[i * 2 + 1] / nn : data[i * 2 + 1],
					Imag = reverce ? data[i * 2] / nn : data[i * 2]
				};
			}

			return res;
		}

		public static Complex[] FastFourierTransformCplx(double[] f)
		{
			var nn = (int)Math.Pow(2, Math.Floor(Math.Log(f.Length) / Math.Log(2)));

			return Fft(f, nn, false);
		}

		public static double[] FastFourierTransform(double[] f)
		{
			var cplxres = FastFourierTransformCplx(f);
			var res = new double[cplxres.Length / 2];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxres[i].Abs;

			return res;
		}

		public static Complex[] SlowFourierTransformCplx(double[] f)
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

		public static double[] SlowFourierTransform(double[] f)
		{
			var cplxRes = SlowFourierTransformCplx(f);
			var res = new double[f.Length / 2];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxRes[i].Abs;

			return res;
		}

		public static Complex[] SlowReverseFourierTransformCplx(Complex[] f)
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

		public static double[] SlowReverseFourierTransform(Complex[] f)
		{
			var cplxRes = SlowReverseFourierTransformCplx(f);
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

		public static double[] SlowDeconvolution(double[] y, double[] h)
		{
			const double alpha = 0.1;
			var hs = SlowFourierTransformCplx(h.Concat(new double[y.Length - h.Length]).ToArray());
			var ys = SlowFourierTransformCplx(y);
			var hrev = new Complex[hs.Length];
			var xs = new Complex[ys.Length];

			for (int i = 0; i < hs.Length; i++)
			{
				double div = hs[i].Abs * hs[i].Abs + alpha * alpha;
				hrev[i] = new Complex
						{
							Real = hs[i].Real / div,
							Imag = -hs[i].Imag / div
						};
			}

			for (int i = 0; i < xs.Length; i++)
			{
				xs[i] = new Complex
						{
							Real = ys[i].Real * hrev[i].Real - ys[i].Imag * hrev[i].Imag,
							Imag = ys[i].Real * hrev[i].Imag + ys[i].Imag * hrev[i].Real
						};
			}

			return SlowReverseFourierTransform(xs);
		}

		//TODO : works bad
		public static double[] FastDeconvolution(double[] y, double[] h)
		{
			const double alpha = 0.1;
			var hs = FastFourierTransformCplx(h.Concat(new double[y.Length - h.Length]).ToArray());
			var ys = FastFourierTransformCplx(y);
			var hrev = new Complex[hs.Length];
			var xs = new Complex[ys.Length];

			for (int i = 0; i < hs.Length; i++)
			{
				double div = hs[i].Abs * hs[i].Abs + alpha * alpha;
				hrev[i] = new Complex
				{
					Real = hs[i].Real / div,
					Imag = -hs[i].Imag / div
				};
			}

			for (int i = 0; i < xs.Length; i++)
			{
				xs[i] = new Complex
				{
					Real = ys[i].Real * hrev[i].Real - ys[i].Imag * hrev[i].Imag,
					Imag = ys[i].Real * hrev[i].Imag + ys[i].Imag * hrev[i].Real
				};
			}

			return FastReverseFourierTransform(xs);
		}
	}
}
