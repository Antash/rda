using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDA
{
	class Deconvolution
	{
		public double[] Result(double[] inp, Convolution conv)
		{
			var h = conv.Fh(true);
			var y = conv.Result(true);
			
			var hFourie = FuncHelper.SpectralAnalysis(h);
			var yFourie = FuncHelper.SpectralAnalysis(y);
			
			return yFourie[1];
		}
	}
}
