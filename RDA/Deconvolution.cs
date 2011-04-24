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
			var h = conv.Fh();
			var y = conv.Result();

			return Algorithms.Deconvolution(y, h);
		}
	}
}
