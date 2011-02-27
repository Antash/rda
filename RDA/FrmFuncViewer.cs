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
			zgc.GraphPane.AddCurve("tmp", pl, Color.Black, SymbolType.None);
			zgc.AxisChange();
		}
	}
}
