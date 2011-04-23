using System;
using System.Linq;

namespace RDA
{
	public static class FuncHelper
	{
		private static readonly Random Rand = new Random();
		// число дискретных значений функции
		public static int N = 1000;
		// число интервалов в гистограмме
		public static int IntCount = 20;
		// f1 (тренд)
		public static double[][] Func1()
		{
			var res = new double[2][];
			res[0] = new double[N];
			res[1] = new double[N];
			for (int k = 0; k < N; k++)
			{
				res[0][k] = k;
				res[1][k] = k*0.01;
			}
			return res;
		}

		// f2
		public static double[][] Func2()
		{
			var res = new double[2][];
			res[0] = new double[N];
			res[1] = new double[N];
			for (int k = 0; k < N; k++)
			{
				res[0][k] = k;
				res[1][k] = (N - k)*0.2;
			}
			return res;
		}

		// f3
		public static double[][] Func3()
		{
			var res = new double[2][];
			res[0] = new double[N];
			res[1] = new double[N];
			for (int k = 0; k < N; k++)
			{
				res[0][k] = k;
				res[1][k] = k*Math.Exp(-k*0.001);
			}
			return res;
		}

		// f4 (рабочая функция)
		public static double[][] Func4()
		{
			var res = new double[2][];
			res[0] = new double[N];
			res[1] = new double[N];
			for (int k = 0; k < N; k++)
			{
				res[0][k] = k;
				res[1][k] = (N - k)*Math.Exp(-k*0.002);
			}
			return res;
		}

		// шум 1
		public static double[] Noise1(double scale)
		{
			var res = new double[N];
			for (int k = 0; k < N; k++)
				res[k] = (1 - 2*Rand.NextDouble())*scale;
			return res;
		}

		public static double[] Noise1()
		{
			return Noise1(1);
		}

		// шум 2
		public static double[] Noise2(double scale)
		{
			var res = new double[N];
			for (int k = 0; k < N; k++)
				res[k] = (1 - 2*Rand.NextDouble())*scale;
			return res;
		}

		public static double[] Noise2()
		{
			return Noise2(1);
		}

		// мат ожидание
		public static double M(double[] fx)
		{
			return fx.Sum()/fx.Count();
		}

		// дисперсия
		public static double Disp(double[] fx)
		{
			double m = M(fx);
			return fx.Sum(y => (y - m)*(y - m))/fx.Count();
		}

		// средне-квадратичное значение
		public static double MSq(double[] fx)
		{
			return Math.Sqrt(fx.Sum(y => y*y)/fx.Count());
		}

		// средне-квадратичное отклонение
		public static double Rms(double[] fx)
		{
			return Math.Sqrt(Disp(fx));
		}

		// плотность вероятности для заданого Ef
		public static double[][] P(double[] fx, double min, double max)
		{
			var res = new double[2][];
			res[0] = new double[IntCount];
			res[1] = new double[IntCount];
			double intLen = (max - min) / IntCount == 0 ? 1 : (max - min) / IntCount;

			foreach (double y in fx)
			{
				int i = 0;
				for (double t = min + intLen; t <= max; t += intLen, i++)
					if (y > t - intLen && y < t)
						res[1][i]++;
			}
			for (int j = 0; j < IntCount; j++)
			{
				res[0][j] = intLen/2 + j*intLen;
				res[1][j] /= N;
			}
			return res;
		}

		// плотность вероятности
		public static double[][] P(double[] fx)
		{
			double min = fx.Min(), max = fx.Max();
			return P(fx, min, max);
		}

		//сдвиг, возвращает значение функции автокорреляции
		private static double Ac(double[] fx, int m)
		{
			//double s = 0;
			//double sz = M(fx);
			//for (int i = 0; i + m < N; i++)
			//    s += (fx[i] - sz)*(fx[i + m] - sz);
			//return s/N;
			return 0;
		}

		//сдвиг, возвращает значение функции взаимной автокорреляции
		private static double Rac(double[] f1X, double[] f2X, int m)
		{
			double s = 0;
			double sz1 = M(f1X);
			double sz2 = M(f2X);
			for (int i = 0; i + m < N; i++)
				s += (f1X[i] - sz1)*(f2X[i + m] - sz2);
			return s/N;
		}

		// автокорреляция 
		public static double[] FAc(double[] fx)
		{
			var res = new double[N];
			for (int m = 0; m < N; m++) //максимальный сдвиг = N-1
				res[m] = Ac(fx, m);
			return res;
		}

		// взаимная автокорреляция
		public static double[] FRac(double[] f1X, double[] f2X)
		{
			var res = new double[N];
			for (int m = 0; m < N; m++) //максимальный сдвиг = N-1
				res[m] = Rac(f1X, f2X, m);
			return res;
		}

		// сдвиг
		public static void Move(double mx, ref double[] fx)
		{
			for (int i = 0; i < N; i++)
				fx[i] += mx;
		}

		// наложение флуктуаций
		public static double[] Jump(double n, double mx)
		{
			var res = new double[N];
			Move(mx, ref res);
			for (int i = 0; i < n; i++)
			{
				double val = mx/10 + Rand.NextDouble()*(mx - mx/10);
				res[Rand.Next(N)] += Rand.Next(2) == 0 ? val : -val;
			}
			return res;
		}

		// гармонический процесс

		// harm
		public static double[][] Harm(double f, double a, double dt)
		{
			var res = new double[2][];
			res[0] = new double[N];
			res[1] = new double[N];
			for (int k = 0; k < N; k++)
			{
				res[0][k] = k;
				res[1][k] = a*Math.Sin(2*Math.PI*f*dt*k);
			}
			return res;
		}

		// polyharm
		public static double[][] Polyharm(double[] f, double[] a, double dt)
		{
			var res = new double[2][];
			res[0] = new double[N];
			res[1] = new double[N];
			if (f.Count() == a.Count())
				for (int k = 0; k < N; k++)
				{
					res[0][k] = k;
					for (int i = 0; i < f.Count(); i++)
						res[1][k] += a[i]*Math.Sin(2*Math.PI*f[i]*dt*k);
				}
			return res;
		}

		public static void ClearJumps(ref double[] f, double mx)
		{
			for (int i = 1; i < f.Count() - 1; i++)
			{
				double d = Math.Abs(  f[i - 1] - f[i] );
				if (d > mx / 10)
					f[i] = (f[i - 1] + f[i + 1])/2;
			}
		}

		public static void ClearNoize(ref double[] f)
		{
		}

		public static void ClearHarm(ref double[] f)
		{
		}

		public static void ClearPolyHarm(ref double[] f)
		{
		}

		public static void ClearTrend(ref double[] f)
		{
		}

		public static double Amp(Func f)
		{
			return (f.Fx[1].Max() - f.Fx[1].Min());
		}
		
		public struct CplxF
		{
			public double X;
			public Complex Fx;

			public CplxF(double x, Complex fx)
			{
				X = x;
				Fx = fx;
			}
		}

		public static Complex[] Fourie(double[] fx)
		{
			const int ns = 1000;
			var res = new Complex[ns];
			//for (int i = 0; i < ns; i++)
			//{
			//    double a;
			//    double b;
			//    FourieKoef(fx, i, out a, out b);
			//    res[i].Fx = new Complex(a, b);
			//}
			return res;
		}

		public static CplxF[] Fourie(double[][] fx)
		{
			const int ns = 1000;
			var res = new CplxF[ns];
			for (int i = 0; i < ns; i++)
			{
				res[i].X = i / 2.0 / Math.PI;
				double a;
				double b;
				FourieKoef(fx, i, out a, out b);
				res[i].Fx = new Complex(a, b);
			}
			return res;
		}

		public static double[][] SpectralAnalysis(double[][] fx)
		{
			var res = new double[2][];
			const int ns = 1000;
			res[0] = new double[ns];
			res[1] = new double[ns];
			for (int i = 1; i < ns; i++)
			{
				res[0][i] = i/2.0/Math.PI;
				double a;
				double b;
				FourieKoef(fx, i, out a, out b);
				res[1][i] = Math.Sqrt(a*a + b*b);
			}
			return res;
		}

		public static void FourieKoef(double[][] fx, double n, out double a, out double b)
		{
			var modafx = new double[2][];
			modafx[0] = new double[fx[0].Count()];
			modafx[1] = new double[fx[0].Count()];
			for (int i = 0; i < fx[0].Count(); i++)
			{
				modafx[1][i] = fx[1][i]*Math.Cos(n * fx[0][i] / 1000);
				modafx[0][i] = fx[0][i];
			}
			a = Integral(modafx) / Math.Sqrt(2 * Math.PI);
			var modbfx = new double[2][];
			modbfx[0] = new double[fx[0].Count()];
			modbfx[1] = new double[fx[0].Count()];
			for (int i = 0; i < fx[0].Count(); i++)
			{
				modbfx[1][i] = fx[1][i] * Math.Sin(n * fx[0][i] / 1000);
				modbfx[0][i] = fx[0][i];
			}
			b = Integral(modbfx) / Math.Sqrt( 2 * Math.PI);
		}

		public static double Integral(double[][] fx)
		{
			double res = 0;
			for (int i = 1; i < fx[0].Count(); i++)
			{
				res += (fx[1][i] + fx[1][i - 1])*Math.Abs(fx[0][i] - fx[0][i - 1])/2;
			}
			return res;
		}
		
		public static double Sn(Func f, Func noize)
		{
			return 20 * Math.Log10(Amp(f)/Amp(noize));
		}
	}
}