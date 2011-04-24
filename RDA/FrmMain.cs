using System.Windows.Forms;

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
			var polyharmFun = new Func (
				Algorithms.FastReverseFourierTransform(
			Algorithms.FastFourierTransformCplx(FuncHelper.Polyharm(
				new[] { 50, 5, 150.0 },
				new[] { 75.0, 15, 25 },
				0.001)[1])));
			ucFuncAnalysis3.DispFunc = polyharmFun;
			var harmFun = new Func (FuncHelper.Harm (50, 25, 0.001));
			ucFuncAnalysis4.DispFunc = harmFun;
			var noize1F = new Func (FuncHelper.Noise1 ());
			ucFuncAnalysis5.DispFunc = noize1F;
			var noize2F = new Func (FuncHelper.Noise2 ());
			ucFuncAnalysis6.DispFunc = noize2F;
			var cardiogram = new Convolution ();
			var cardio = new Func (cardiogram.Result ());
			ucFuncAnalysis7.DispFunc = cardio;
			var deconvolution = new Deconvolution ();
			var deconv = new Func (deconvolution.Result (cardiogram.Result (), cardiogram));
			ucFuncAnalysis8.DispFunc = deconv;
			var fil = new Filter();
			var filter = new Func(fil.Result(1, 1000, 0.01));
			ucFuncAnalysis9.DispFunc = filter;
			var filtered = new Func(fil.FilterSignal(FuncHelper.Polyharm (
				new[] { 50, 5, 150.0 },
				new[] { 75.0, 15, 25 },
				0.001)[1], fil.Result(1, 1000, 0.01)));
			ucFuncAnalysis10.DispFunc = filtered;
		}
	}
}