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
	public partial class UcFilter : UserControl
	{
		public event FilterChangedEventHandler FilterChanged;

		public double[] FilterFunc
		{
			get { return _filter.Fx[1]; }
		}

		public void InvokeFilterChanged(FilterChangedEventHandlerArgs e)
		{
			FilterChangedEventHandler handler = FilterChanged;
			if (handler != null) handler(this, e);
		}

		private Func _filter;

		public UcFilter()
		{
			InitializeComponent();

			f1editor.ParamName = "f1";
			f1editor.ParamValue = 10.ToString();
			f2editor.ParamName = "f1";
			f2editor.ParamValue = 60.ToString();
			mEditor.ParamName = "m";
			mEditor.ParamValue = 100.ToString();
			dtEditor.ParamName = "dt";
			dtEditor.ParamValue = 0.001.ToString();

			_filter = new Func(MakeFilter());
			InvokeFilterChanged(new FilterChangedEventHandlerArgs(_filter));

			comboBox1.SelectedIndex = 0;
		}

		private double[] MakeFilter()
		{
			switch (ftype.SelectedIndex)
			{
				case 0:
					return Filter.Result(
						Convert.ToDouble(f1editor.ParamValue),
						Convert.ToInt32(mEditor.ParamValue),
						Convert.ToDouble(dtEditor.ParamValue));
				case 1:
					return Filter.ResultHP(
						Convert.ToDouble(f1editor.ParamValue),
						Convert.ToInt32(mEditor.ParamValue),
						Convert.ToDouble(dtEditor.ParamValue));
				case 2:
					return Filter.ResultSlice(
						Convert.ToDouble(f1editor.ParamValue),
						Convert.ToDouble(f2editor.ParamValue),
						Convert.ToInt32(mEditor.ParamValue),
						Convert.ToDouble(dtEditor.ParamValue));
				case 3:
					return Filter.ResultBsw(
						Convert.ToDouble(f1editor.ParamValue),
						Convert.ToDouble(f2editor.ParamValue),
						Convert.ToInt32(mEditor.ParamValue),
						Convert.ToDouble(dtEditor.ParamValue));
				default:
					ftype.SelectedIndex = 0;
					return MakeFilter();
			}
		}

		private void bbuild_Click(object sender, EventArgs e)
		{
			_filter = new Func(MakeFilter());
			comboBox1_SelectedIndexChanged(null, null);
			InvokeFilterChanged(new FilterChangedEventHandlerArgs(_filter));
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			zgc.GraphPane.CurveList.Clear();
			IPointList pl;
			switch (comboBox1.SelectedIndex)
			{
				case 0:
					pl = GBuilder.MakeGraph(new Func(Algorithms.SlowFourierTransform(_filter.Fx[1])).Fx);
					break;
				case 1:
					pl = GBuilder.MakeGraph(_filter.Fx);
					break;
				default:
					comboBox1.SelectedIndex = 0;
					pl = GBuilder.MakeGraph(new Func(Algorithms.SlowFourierTransform(_filter.Fx[1])).Fx);
					break;
			}
			zgc.GraphPane.AddCurve("filter", pl, Color.Black, SymbolType.None);
			zgc.AxisChange();
			zgc.Refresh();
		}
	}

	public delegate void FilterChangedEventHandler(object sender, FilterChangedEventHandlerArgs args);

	public class FilterChangedEventHandlerArgs
	{
		public Func Filter { get; set; }
		public FilterChangedEventHandlerArgs(Func filter)
		{
			Filter = filter;
		}
	}
}
