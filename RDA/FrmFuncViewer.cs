using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace RDA
{
	public partial class FrmFuncViewer : Form
	{
		public FrmFuncViewer(IPointList pl)
		{
			InitializeComponent();
			zgc.GraphPane.AddCurve("base", pl, Color.Black, SymbolType.None);
			zgc.AxisChange();
		}

		public FrmFuncViewer(IPointList pl1, IPointList pl2)
		{
			InitializeComponent();
			zgc.GraphPane.AddCurve("filtered", pl2, Color.Red, SymbolType.None);
			zgc.GraphPane.AddCurve("base", pl1, Color.Black, SymbolType.None);
			zgc.AxisChange();
		}
	}
}
