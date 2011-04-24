using System;
using System.Linq;

namespace RDA
{
	/// <summary>
	/// Class contains transformation algorithms
	/// </summary>
	class Algorithms
	{
		/// <summary>
		/// Fast reverce Fourier transformation
		/// </summary>
		/// <param name="f">Input complex function</param>
		/// <returns>Complex result</returns>
		public static Complex[] FastReverseFourierTransformCplx(Complex[] f)
		{
			var nn = (int)Math.Pow(2, Math.Floor(Math.Log(f.Length) / Math.Log(2)));

			var res = Fft(f, nn, true);

			return res;
		}

		/// <summary>
		/// Fast reverce Fourier transformation
		/// </summary>
		/// <param name="f">Input complex function</param>
		/// <returns>Real result</returns>
		public static double[] FastReverseFourierTransform(Complex[] f)
		{
			var cplxRes = FastReverseFourierTransformCplx(f);

			var res = new double[cplxRes.Length];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxRes[i].Real + cplxRes[i].Imag;

			return res;
		}

		/// <summary>
		/// Main algorithm of the fast Fourier transformation
		/// </summary>
		/// <param name="f">Input real discrete function</param>
		/// <param name="nn">
		/// Number of significant function values.
		/// Must be the power of 2
		/// </param>
		/// <param name="reverce">indicates if transformation is reverce</param>
		/// <returns>Complex transformation result</returns>
		private static Complex[] Fft(double[] f, int nn, bool reverce)
		{
			var cplxf = new Complex[f.Length];

			for (int i = 0; i < f.Length; i++)
				cplxf[i] = new Complex(f[i], 0);

			return Fft(cplxf, nn, reverce);
		}

		/// <summary>
		/// Main algorithm of the fast Fourier transformation
		/// </summary>
		/// <param name="f">Input complex discrete function</param>
		/// <param name="nn">
		/// Number of significant function values.
		/// Must be the power of 2
		/// </param>
		/// <param name="reverce">indicates if transformation is reverce</param>
		/// <returns>Complex transformation result</returns>
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

		/// <summary>
		/// Fast Fourier transformation
		/// </summary>
		/// <param name="f">Input real function</param>
		/// <returns>Complex result</returns>
		public static Complex[] FastFourierTransformCplx(double[] f)
		{
			var nn = (int)Math.Pow(2, Math.Floor(Math.Log(f.Length) / Math.Log(2)));

			return Fft(f, nn, false);
		}

		/// <summary>
		/// Fast Fourier transformation real
		/// </summary>
		/// <param name="f">Input real function</param>
		/// <returns>Real result (half, symmetrical values discarded)</returns>
		public static double[] FastFourierTransform(double[] f)
		{
			var cplxres = FastFourierTransformCplx(f);
			var res = new double[cplxres.Length / 2];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxres[i].Abs;

			return res;
		}

		/// <summary>
		/// Traditional Fourier transformation complex
		/// </summary>
		/// <param name="f">Input real function</param>
		/// <returns>Complex result</returns>
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

		/// <summary>
		/// Traditional Fourier transformation real
		/// </summary>
		/// <param name="f">Input real function</param>
		/// <returns>Real result (half, symmetrical values discarded)</returns>
		public static double[] SlowFourierTransform(double[] f)
		{
			var cplxRes = SlowFourierTransformCplx(f);
			var res = new double[f.Length / 2];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxRes[i].Abs;

			return res;
		}

		/// <summary>
		/// Traditional reverce Fourier transformation
		/// </summary>
		/// <param name="f">Input complex function</param>
		/// <returns>Complex result</returns>
		public static Complex[] SlowReverseFourierTransformCplx(Complex[] f)
		{
			var res = new Complex[f.Length];
			double arg = 2 * Math.PI / f.Length;

			for (int i = 0; i < f.Length; i++)
			{
				res[i] = new Complex();
				for (int j = 0; j < f.Length; j++)
				{
					res[i] += f[j] * new Complex(Math.Cos(arg * i * j), Math.Sin(arg * i * j));
				}
				res[i] /= f.Length;
			}

			return res;
		}

		/// <summary>
		/// Traditional reverce Fourier transformation
		/// </summary>
		/// <param name="f">Input complex function</param>
		/// <returns>Real result</returns>
		public static double[] SlowReverseFourierTransform(Complex[] f)
		{
			var cplxRes = SlowReverseFourierTransformCplx(f);
			var res = new double[cplxRes.Length];

			for (int i = 0; i < res.Length; i++)
				res[i] = cplxRes[i].Real + cplxRes[i].Imag;

			return res;
		}

		/// <summary>
		/// Convolution algorythm
		/// </summary>
		/// <param name="x">Main function</param>
		/// <param name="h">Second function</param>
		/// <returns>Result function</returns>
		/// <remarks>
		/// Result function actual length is x.Length + h.Length
		/// This convolution algorythm trims resulf for h.Length/2 values, so
		/// returned result have the same length as function x.
		/// Warning! [x] Length must be greater than [h]'s!
		/// </remarks>
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

		/// <summary>
		/// Deconvolution algorythm
		/// Restores source signal from input signal [y]
		/// with help of affecting function [h]
		/// </summary>
		/// <param name="y">Input signal</param>
		/// <param name="h">Affecting function</param>
		/// <returns>Source function</returns>
		/// <remarks>
		/// This algorithm uses slow fourier transformations!
		/// </remarks>
		public static double[] Deconvolution(double[] y, double[] h)
		{
			const double alpha = 0.1;
			var hs = SlowFourierTransformCplx(h.Concat(new double[y.Length - h.Length]).ToArray());
			var ys = SlowFourierTransformCplx(y);
			var hrev = new Complex[hs.Length];
			var xs = new Complex[ys.Length];

			for (int i = 0; i < hs.Length; i++)
			{
				hrev[i] = hs[i].GetConjugate() /
					(hs[i].Abs * hs[i].Abs + alpha * alpha);
			}

			for (int i = 0; i < xs.Length; i++)
			{
				xs[i] = ys[i] * hrev[i];
			}

			return SlowReverseFourierTransform(xs);
		}
	}
}
