using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDA
{
	class Cardio
	{
		private const double Scale = 300;
		private const int Np = 75;
		private const double pP = 100;
		private const double eps = 0.01; 

		public double [] Result()
		{
			var res = new double[FuncHelper.N];
			P(ref res);
			Q(ref res);
			H(ref res); 
			S(ref res);
			T(ref res);
			U(ref res);
			return res;
		}
		private static void P(ref double [] x)
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (i % (60 * Scale / Np) == 0)
					Pspike(ref x, (int) (i % (60 * Scale / Np)));
			}
		}
		private static void Q(ref double[] x)
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (i % (60 * Scale / Np) == 0)
					Pspike(ref x, i);
			}
		}
		private static void H(ref double[] x)
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (i % (60 * Scale / Np) == 0)
					Pspike(ref x, i);
			}
		}
		private static void S(ref double[] x)
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (i % (60 * Scale / Np) == 0)
					Pspike(ref x, i);
			}
		}
		private static void T(ref double[] x)
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (i % (60 * Scale / Np) == 0)
					Pspike(ref x, i);
			}
		}
		private static void U(ref double[] x)
		{
			for (int i = 0; i < x.Length; i++)
			{
				if (i % (60 * Scale / Np) == 0)
					Pspike(ref x, i);
			}
		}
		private static void Pspike(ref double [] x, int i)
		{
			
		}
	}
}
