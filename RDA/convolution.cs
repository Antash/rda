using System;

namespace RDA
{
	class Convolution
	{
		private const double Dt = 0.005;
		private const double Tx = 5;
		private const int Nx = (int)(Tx / Dt);
		private const int R = (int)(1 / Dt);
		private const double Tp = 0.25;
		private const int Np = (int)(Tp / Dt);
		private const double Arg = 2 * Math.PI * Dt;
		private const double PsistAvg = 120;
		private const double PdiastAvg = 80;
		private const int Ny = Nx + Np;

		private static readonly Random Rand = new Random();

		public static double[] Fh()
		{
			var res = new double[Ny];
			for (int i = 0; i < Np; i++)
				res[i] = Math.Sin(Arg * i / Tp) * Math.Exp(-0.1 * i);
			return res;
		}

		static double[] Fx()
		{
			var res = new double[Ny];

			for (int i = 0; i < Nx; i++)
			{
				if (i % R == 0 && i / R > 0)
					res[i] = PsistAvg + (1 - Rand.NextDouble()) * PsistAvg * 0.05;
				if ((i - Tp * R) % R == 0 && (i - Tp * R) / R > 0)
					res[i] = -PdiastAvg + (1 - Rand.NextDouble()) * PdiastAvg * 0.05;
			}

			return res;
		}

		public double[] Result()
		{
			var y = new double[Ny];
			var x = Fx();
			var h = Fh();

			for (int i = 0; i < Ny; i++)
			{
				double t = 0;
				for (int j = 0; j < i; j++)
					t += h[j] * x[i - j];
				y[i] = t;
			}

			var res = new double[FuncHelper.N];

			for (int i = 0, j = Np / 2; i < FuncHelper.N; i++, j++)
				res[i] = y[j];

			return res;
		}
	}
}
