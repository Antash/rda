using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDA
{
	public partial class UserControl1 : UserControl
	{
		PointF p1 = new PointF(100, 200);
		PointF p2 = new PointF(100, 100);
		PointF p3 = new PointF(50, 110);
		PointF p4 = new PointF(100, 40);
		Pen p = new Pen(new SolidBrush(Color.Black), 2);
		Pen pe = new Pen(new SolidBrush(Color.Red), 5);

		public UserControl1()
		{
			InitializeComponent();
			p1 = new PointF(0, 0);
			 p2 = new PointF(100, 100);
			 p3 = new PointF(50, 110);
			 p4 = new PointF(Width, Height);
		}

		private void UserControl1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

			e.Graphics.DrawEllipse(pe, p1.X, p1.Y, 1, 1);
			e.Graphics.DrawEllipse(pe, p2.X, p2.Y, 1, 1);
			e.Graphics.DrawEllipse(pe, p3.X, p3.Y, 1, 1);
			e.Graphics.DrawEllipse(pe, p4.X, p4.Y, 1, 1);
			e.Graphics.DrawBezier(p, p1, p2, p3, p4);
		}

		private void UserControl1_Resize(object sender, EventArgs e)
		{
			p1 = new PointF(0, 0);
			p2 = new PointF(Width - 5, 0);
			p3 = new PointF(0, Height - 5);
			p4 = new PointF(Width - 5, Height - 5);
		}
	}
}
