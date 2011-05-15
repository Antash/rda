using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDA
{
	public partial class UcFilter : UserControl
	{
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
		}
	}
}
