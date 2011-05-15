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
			var f = new Func(Filter.FilterSignal(dispFunc.Fx[1], filter.Fx[1]));
			zgcfiltered.GraphPane.AddCurve(dispFunc.Name, f.FpList, Color.Black, SymbolType.None);
			zgcfiltered.AxisChange();
			zgcfiltered.Refresh();
		}
	}
}
