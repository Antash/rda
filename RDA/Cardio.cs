using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDA
{
	class Cardio
	{
		private const double Dt = 0.005;
		private const double Tx = 5;
		private const int Nx = (int) (Tx / Dt);
		private const int R = (int) (1 / Dt);
		private const double Tp = 0.25;
		private const int Np = (int) (Tp / Dt);
		private const double Arg = 2 * Math.PI * Dt;
		private const double PsistAvg = 120;
		private const double PdiastAvg = 80;
		private const int Ny = Nx + Np;

		private static readonly Random Rand = new Random();

		static double[] Fh()
		{
			var res = new double[Np];

			for (int i = 0; i < Np; i++)
				res[i] = Math.Sin(Arg * i / Tp) * Math.Exp(-0.1 * i);
			return res;
		}

		static double[] Fx()
		{
			var res = new double[Nx];

			for (int i = 0; i < Nx; i++)
			{
				if (i % R == 0)
					res[i] = PsistAvg + (1 - Rand.NextDouble())*PsistAvg*0.05;
				else if ((i - Tp*R) % R == 0)
					res[i] = -PdiastAvg + (1 - Rand.NextDouble()) * PdiastAvg * 0.05;
				else
					res[i] = 0;
			}

			return res;
		}

		public double[] Result()
		{
			var y = new double[Ny];
			var x = Fx();
			var h = Fh();

			for (int i = 0; i < Ny && i < Nx; i++)
			{
				double t = 0;
				for (int j = 0; j < i && j < Np; j++)
					t += h[j] * x[i - j];
				y[i] = t;
			}
			
			return y;
		}
	}
}
