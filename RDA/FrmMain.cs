using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace RDA
{
	public partial class FrmMain : Form
	{
		public FrmMain ()
		{
			InitializeComponent ();
			var fun1 = new Func (FuncHelper.Func4 ());
			funcAnalysis1.DispFunc = fun1;
			var fun2 = new Func (FuncHelper.Func2 ());
			ucFuncAnalysis1.DispFunc = fun2;
			var fun3 = new Func (FuncHelper.Func3 ());
			ucFuncAnalysis2.DispFunc = fun3;
			//var polyharmFun = new Func(
			//    Algorithms.SlowReverseFourierTransform(
			//Algorithms.SlowFourierTransformCplx(FuncHelper.Polyharm(
			//    new[] { 50, 5, 150.0 },
			//    new[] { 75.0, 15, 25 },
			//    0.001)[1])));

			var polyharmFun = new Func (FuncHelper.Polyharm (
				new[] { 50, 5, 150.0 },
				new[] { 75.0, 15, 25 },
				0.001));
			ucFuncAnalysis3.DispFunc = polyharmFun;
			var harmFun = new Func (FuncHelper.Harm (50, 25, 0.001));
			ucFuncAnalysis4.DispFunc = harmFun;
			var noize1F = new Func (FuncHelper.Noise1 ());
			ucFuncAnalysis5.DispFunc = noize1F;
			var noize2F = new Func (FuncHelper.Noise2 ());
			ucFuncAnalysis6.DispFunc = noize2F;
			var cardiogram = new Convolution ();
			var cardio = new Func (cardiogram.Result ());
			//cardio.AddF(noize1F);
			ucFuncAnalysis7.DispFunc = cardio;
			var deconvolution = new Deconvolution ();
			var deconv = new Func(deconvolution.Result(cardio.Fx[1], cardiogram));
			ucFuncAnalysis8.DispFunc = deconv;
			ucFiltration1.DispFunc = polyharmFun;
		}
	}
}