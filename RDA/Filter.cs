using System;
using System.Linq;

namespace RDA
{
	class Filter
	{
		public static double[] LpPotter(double b, int m, double dt)
		{
			var w = new double[m + 1];
			var d = new[] { 0.35577019, 0.2436983, 0.07211497, 0.00630165 };
			double fact = 2 * b * dt;
			w[0] = fact;
			fact *= Math.PI;
			for (int i = 1; i <= m; i++)
				w[i] = Math.Sin(fact * i) / (Math.PI * i);
			w[m] /= 2;
			double sumg = 0;
			for (int i = 1; i <= m; i++)
			{
				double sum = d[0];
				fact = Math.PI * i / m;
				for (int j = 1; j <= 3; j++)
					sum += 2 * d[j] * Math.Cos(fact * j);
				w[i] *= sum;
				sumg += 2 * w[i];
			}
			for (int i = 0; i <= m; i++)
				w[i] /= sumg;

			return w;
		}

		public static double[] Result(double b, int m, double dt)
		{
			var hf = LpPotter(b, m / 2, dt);
			return hf.Reverse().Take(m / 2).Concat(hf).ToArray();
		}

		public static double[] ResultHP(double b, int m, double dt)
		{
			var w = Result(b, m, dt);
			var res = new double[w.Length];
			for (int i = 0; i < w.Length; i++)
			{
				if (i != (w.Length / 2))
					res[i] = -w[i];
				else
					res[i] = 1 - w[i];
			}
			return res;
		}

		public static double[] ResultSlice(double b1, double b2, int m, double dt)
		{
			double[] w1 = Result(b1, m, dt);
			var w2 = Result(b2, m, dt);
			var res = new double[w1.Length];
			for (int i = 0; i < w1.Length; i++)
			{
				res[i] = b2 > b1 ? w2[i] - w1[i] : w1[i] - w2[i];
			}
			return res;
		}

		public static double[] ResultBsw(double b1, double b2, int m, double dt)
		{
			if (b2 > b1)
			{
				var w1 = Result(b1, m, dt);
				var w2 = Result(b2, m, dt);
				var res = new double[w1.Length];
				for (int i = 0; i < w1.Length; i++)
				{
					if (i == (w1.Length - 1) / 2)
						res[i] = 1 + w1[i] - w2[i];
					else
						res[i] = w1[i] - w2[i];

				}
				return res;
			}
			throw new ArgumentException("use b2 > b1");
		}

		public static double[] FilterSignal(double[] doubles, double[] filter)
		{
			return Algorithms.Convolution(doubles, filter);
		}
	}
}
