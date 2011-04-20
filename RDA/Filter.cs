using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDA
{
	class Filter
	{
		public double[] halfFilter (int b, int m, double dt)
		{
			var w = new double[m + 1];
			var d = new[] {0.35577019, 0.2436983, 0.07211497, 0.00630165 };
			double fact = 2 * b * dt;
			w[0] = fact;
			fact *= Math.PI;
			for (int i = 1; i <= m; i++)
				w[i] = Math.Sin (fact * i) / (Math.PI * i);
			w[m] /= 2;
			double sumg = 0;
			for (int i = 1; i <= m; i++) {
				double sum = d[0];
				fact = Math.PI * i / m;
				for (int j = 1; j <= 3; j++)
					sum += 2 * d[j] * Math.Cos (fact * j);
				w[i] *= sum;
				sumg += 2 * w[i];
			}
			for (int i = 0; i <= m; i++)
				w[i] /= sumg;
			
			    return w;
        }
		
		public double[] Result (int b, int m, double dt)
		
		{
			var w = new double[m + 1];
			w = halfFilter(b, m / 2, dt).Reverse().Concat(halfFilter(b, m / 2, dt)).ToArray();
			return w;
		}
	}
}
