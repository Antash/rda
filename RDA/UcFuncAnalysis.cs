using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace RDA
{
	public partial class UcFuncAnalysis : UserControl
	{
		private Func dispFunc;

		public UcFuncAnalysis()
		{
			InitializeComponent();
		}

		public Func DispFunc
		{
			set
			{
				dispFunc = value;
				Refresh();
			}
		}

		private new void Refresh()
		{
			zgc.GraphPane.CurveList.Clear();
			zgc.GraphPane.AddCurve(dispFunc.Name, dispFunc.FpList, Color.Black, SymbolType.None);
			zgc.AxisChange();
			zgc.Refresh();
			labelDisp.Text = String.Format("D = {0:0.###}", dispFunc.Disp);
			labelM.Text = String.Format("M = {0:0.###}", dispFunc.M);
			labelS.Text = String.Format("S = {0:0.###}", dispFunc.Sq);
		}

		private void bRAC_Click(object sender, EventArgs e)
		{
			if (dispFunc.FFrac == null)
				MessageBox.Show("Вы должны задать коррелирующую функцию.");
			else
				new FrmFuncViewer(dispFunc.FracList).Show();
		}

		private void bAC_Click(object sender, EventArgs e)
		{
			new FrmFuncViewer(dispFunc.FacList).Show();
		}

		private void bP_Click(object sender, EventArgs e)
		{
			new FrmFuncViewer(dispFunc.PList).Show();
		}

		private void bPolyharm_Click(object sender, EventArgs e)
		{
			if (int.Parse(bPolyharm.Tag.ToString()) == 1)
			{
				var polyharmFun = new Func(FuncHelper.Polyharm(
					new[] { 50, 5, 150.0 },
					new[] { 75.0, 15, 25 },
					0.001));
				dispFunc.AddF(polyharmFun);
				bPolyharm.Tag = 0;
				bPolyharm.Text = "Очистить от полигарм. колеб.";
			}
			else
			{
				FuncHelper.ClearPolyHarm(ref dispFunc.Fx[1]);
				dispFunc.CountF();
				bPolyharm.Tag = 1;
				bPolyharm.Text = "Добавить полигарм. колеб.";
			}
			Refresh();
		}

		private void bHarm_Click(object sender, EventArgs e)
		{
			if (int.Parse(bHarm.Tag.ToString()) == 1)
			{
				var harmFun = new Func(FuncHelper.Harm(50, 25, 0.001));
				dispFunc.AddF(harmFun);
				bHarm.Tag = 0;
				bHarm.Text = "Убрать синус";
			}
			else
			{
				FuncHelper.ClearHarm(ref dispFunc.Fx[1]);
				dispFunc.CountF();
				bHarm.Tag = 1;
				bHarm.Text = "Добавить синус";
			}
			Refresh();
		}

		private void bTrend_Click(object sender, EventArgs e)
		{
			if (int.Parse(bTrend.Tag.ToString()) == 1)
			{
				var funTrend = new Func(FuncHelper.Func1());
				dispFunc.AddF(funTrend);
				bTrend.Tag = 0;
				bTrend.Text = "Убрать тренд";
			}
			else
			{
				FuncHelper.ClearTrend(ref dispFunc.Fx[1]);
				dispFunc.CountF();
				bTrend.Tag = 1;
				bTrend.Text = "Добавить тренд";
			}
			Refresh();
		}

		private void bJump_Click(object sender, EventArgs e)
		{
			if (int.Parse(bJump.Tag.ToString()) == 1)
			{
				dispFunc.AddF(FuncHelper.Jump(5, 1000));
				bJump.Tag = 0;
				bJump.Text = "Убрать всплески";
			}
			else
			{
				FuncHelper.ClearJumps(ref dispFunc.Fx[1], 1000);
				dispFunc.CountF();
				bJump.Tag = 1;
				bJump.Text = "Добавить всплески";
			}
			Refresh();
		}

		private void bNoise_Click(object sender, EventArgs e)
		{
			if (int.Parse(bNoise.Tag.ToString()) == 1)
			{
				var funNoise = new Func(FuncHelper.Noise1(10));
				dispFunc.AddF(funNoise);
				bNoise.Tag = 0;
				bNoise.Text = "Убрать шум";
			}
			else
			{
				FuncHelper.ClearNoize(ref dispFunc.Fx[1]);
				dispFunc.CountF();
				bNoise.Tag = 1;
				bNoise.Text = "Добавить шум";
			}
			Refresh();
		}

		private void bUp_Click(object sender, EventArgs e)
		{
			dispFunc.AddF(50);
			Refresh();
		}

		private void bDown_Click(object sender, EventArgs e)
		{
			dispFunc.AddF(-50);
			Refresh();
		}

		private void bfft_Click(object sender, EventArgs e)
		{
			new FrmFuncViewer(GBuilder.MakeGraph(FuncHelper.SpectralAnalysis(dispFunc.Fx))).Show();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (((ComboBox) sender).SelectedIndex)
			{
				case 0: // noize
					dispFunc.FracAdd(new Func(FuncHelper.Noise1()));
					break;
				case 1: // polyharm
					var polyharmFun = new Func(FuncHelper.Polyharm(
						new[] { 50,  5, 150.0 },
						new[] { 75.0, 15, 25 },
						0.001));
					dispFunc.FracAdd(polyharmFun);
					break;
				case 2: // harm
					dispFunc.FracAdd(new Func(FuncHelper.Harm( 50, 25, 0.001)));
					break;
				case 3: // func
					dispFunc.FracAdd(new Func(dispFunc.StartFunc));
					break;
			}
		}
	}
}
