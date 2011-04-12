using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDA
{
	class Deconvolution
	{
		private const double Alpha = 0.1;

		public double[] ReverceFt(FuncHelper.CplxF[] inp)
		{
			var res = new double[FuncHelper.N];
			for (int i = 0; i < FuncHelper.N; i++)
			{
				double s = 0;
				for (int j = 0; j < FuncHelper.N; j++)
				{
					double lambda = i * inp[j].X;
				//re:
					s += inp[j].Fx.Real*Math.Cos(lambda) - inp[j].Fx.Imag*Math.Sin(lambda);
				//im :
				//	s += inp[j].Fx.Real*Math.Sin(lambda) + inp[j].Fx.Imag*Math.Cos(lambda);
				//abs
				//	s += Math.Sqrt();
				}
				res[i] = s / Math.Sqrt(2 * Math.PI);
			}
			return res;
		}

		public double[] Result(double[] inp, Convolution conv)
		{
			var h = conv.Fh(true);
			var y = conv.Result(true);

			var hFourie = FuncHelper.Fourie(h);
			var yFourie = FuncHelper.Fourie(y);

			var res = new FuncHelper.CplxF[FuncHelper.N];

			for (int i = 0; i < FuncHelper.N; i++)
			{
				double abs = hFourie[i].Fx.Abs + Alpha * Alpha;
				res[i].X = i;
				res[i].Fx = new Complex(
								(hFourie[i].Fx.Real * yFourie[i].Fx.Real -
								hFourie[i].Fx.Imag * yFourie[i].Fx.Imag) / abs,
								(hFourie[i].Fx.Real * yFourie[i].Fx.Imag +
								hFourie[i].Fx.Imag * yFourie[i].Fx.Real) / abs
								);
			}
			return ReverceFt(res);
		}
	}
}
