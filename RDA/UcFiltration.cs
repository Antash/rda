using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace RDA
{
	public partial class UcFiltration : UserControl
	{
		private Func dispFunc;
		private Func filter;
		private Func filtered;

		public UcFiltration()
		{
			InitializeComponent();
			ucFilter1.FilterChanged += new FilterChangedEventHandler(ucFilter1_FilterChanged);
		}

		void ucFilter1_FilterChanged(object sender, FilterChangedEventHandlerArgs args)
		{
			filter = args.Filter;
			Refresh();
		}

		public Func DispFunc
		{
			set
			{
				dispFunc = value;
				Refresh();
			}
		}

		public new void Refresh()
		{
			zgc.GraphPane.CurveList.Clear();
			zgc.GraphPane.AddCurve(dispFunc.Name, dispFunc.FpList, Color.Black, SymbolType.None);
			zgc.AxisChange();
			zgc.Refresh();

			if (filter == null)
				return;
			zgcfiltered.GraphPane.CurveList.Clear();
			filtered = new Func(Filter.FilterSignal(dispFunc.Fx[1], filter.Fx[1]));
			zgcfiltered.GraphPane.AddCurve(dispFunc.Name, filtered.FpList, Color.Black, SymbolType.None);
			zgcfiltered.AxisChange();
			zgcfiltered.Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			new FrmFuncViewer(GBuilder.MakeGraph(new Func(Algorithms.SlowFourierTransform(dispFunc.Fx[1])).Fx),
				GBuilder.MakeGraph(new Func(Algorithms.SlowFourierTransform(filtered.Fx[1])).Fx)).Show();
		}
	}
}
