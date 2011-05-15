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
	public partial class UcParamEditor : UserControl
	{
		public UcParamEditor()
		{
			InitializeComponent();
		}

		public string ParamName
		{
			set { lblParam.Text = value; }
		}

		public string ParamValue
		{
			get { return tbParamVal.Text; }
			set { tbParamVal.Text = value; }
		}
	}
}
