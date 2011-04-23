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

		public double[] Fh()
		{
			var res = new double[Np];
			for (int i = 0; i < Np; i++)
				res[i] = Math.Sin(Arg * i / Tp) * Math.Exp(-0.1 * i);
			return res;
		}

		public double[][] Fh(bool f)
		{
			var res = new double[2][];
			res[0] = new double[FuncHelper.N];
			res[1] = Fh();
			for (int i = 0; i < FuncHelper.N; i++)
				res[0][i] = i;
			return res;
		}
		
		static double[] Fx()
		{
			var res = new double[Nx];

			for (int i = 0; i < Nx; i++)
			{
				if (i % R == 0 && i / R > 0)
					res[i] = PsistAvg + (1 - Rand.NextDouble()) * PsistAvg * 0.05;
				if ((i - Tp * R) % R == 0 && (i - Tp * R) / R > 0)
					res[i] = -PdiastAvg + (1 - Rand.NextDouble()) * PdiastAvg * 0.05;
			}

			return res;
		}

		public double[][] Result(bool f)
		{
			var res = new double[2][];
			res[0] = new double[FuncHelper.N];
			res[1] = Result();

			for (int j = 0; j < FuncHelper.N; j++)
				res[0][j] = j;

			return res;
		}
		
		public double[] Result()
		{
			return Algorithms.Convolution(Fx(), Fh());
		}
	}
}
