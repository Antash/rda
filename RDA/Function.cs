using System;
using System.Linq;

namespace RDA
{
	public class Function
	{
		public int Length;
		public string Name;
		public double [] F;
		
		public Function (double[] values)
		{
			F = (double[])values.Clone ();
			Length = F.Length;
		}
		
		public static double[] operator + (Function f1, Function f2)
		{
			if (f1.Length == f2.Length)
			{
				var res = new double[f1.Length];
				for (int i = 0; i < f1.Length; i++)
					res[i] = f1.F[i] + f2.F[i];
				return res;
			}
			throw new RankException ();
		}
		
		public static double[] operator - (double val, Function f)
		{
			var res = new double[f.Length];
			for (int i = 0; i < f.Length; i++)
				res[i] = val - f.F[i];
			return res;
		}
	}
}

