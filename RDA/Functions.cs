using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDA
{
	class Functions
	{
		private static readonly Random Rand = new Random();

		public static double[] Fh(int n)
		{
			var res = new double[n];
			for (int i = 0; i < n; i++)
				res[i] = Math.Sin(2 * Math.PI * i / n) * Math.Exp(-0.1 * i);
			return res;
		}

		public static double[] Fspectrum(int n, int r, double offset, double pPos, double pNeg, double disp)
		{
			var res = new double[n];

			for (int i = 0; i < n; i++)
			{
				if (i % r == 0 && i / r > 0)
					res[i] = pPos + (1 - Rand.NextDouble()) * pPos * disp;
				if ((i - offset * r) % r == 0 && (i - offset * r) / r > 0)
					res[i] = -pNeg + (1 - Rand.NextDouble()) * pNeg * disp;
			}

			return res;
		}

		public static double[] NoiseRand(int n, double scale)
		{
			var res = new double[n];
			for (int k = 0; k < n; k++)
				res[k] = (1 - 2 * Rand.NextDouble()) * scale;
			return res;
		}

		public static double[] NoiseRand(int n)
		{
			return NoiseRand(n, 1);
		}
	}
}
