using System;
using ZedGraph;

namespace RDA
{
	public class Func : ICloneable
	{
		public double[][] StartFunc;
		public double Disp;
		public double M;
		public double[][] P;
		public IPointList PList;
		public double Sq;
		public double[] Fac;
		public IPointList FacList;
		public IPointList FpList;
		public double[] Frac;
		public IPointList FracList;
		public double[][] Fx;
		public Func FFrac;
		public string Name;

		public Func(double[][] fx, string name)
			: this(fx)
		{
			Name = name;
		}

		public Func(double[][] fx)
		{
			Fx = fx.Clone() as double[][];
			CountF();
			StartFunc = fx.Clone() as double[][];
		}

		public Func(double[] fx)
		{
			var x = new double[FuncHelper.N];
			for (var i = 0; i < FuncHelper.N; i++)
				x[i] = i;
			Fx = new double[2][];
			Fx[0] = new double[FuncHelper.N];
			Fx[1] = new double[FuncHelper.N];
			Fx[0] = x;
			Fx[1] = fx.Clone() as double[];
			CountF();
			StartFunc = fx.Clone() as double[][];
		}

		public Func()
		{
			throw new NotImplementedException();
		}

		public void CountF()
		{
			if (Fx == null) return;
			P = FuncHelper.P(Fx[1]);
			M = FuncHelper.M(Fx[1]);
			Sq = FuncHelper.MSq(Fx[1]);
			Disp = FuncHelper.Disp(Fx[1]);
			Fac = FuncHelper.FAc(Fx[1]);
			if (FFrac != null)
				Frac = FuncHelper.FRac(Fx[1], FFrac.Fx[1]);
			PList = GBuilder.MakeGraph(P);
			FacList = GBuilder.MakeGraph(Fx[0], Fac);
			FracList = GBuilder.MakeGraph(Fx[0], Frac);
			FpList = GBuilder.MakeGraph(Fx);
		}

		public void FracAdd(Func f)
		{
			FFrac = f;
			CountF();
		}

		public void AddF(Func f)
		{
			for (var i = 0; i < FuncHelper.N; i++)
				Fx[1][i] += f.Fx[1][i];
			CountF();
		}

		public void AddF(double[] f)
		{
			for (var i = 0; i < FuncHelper.N; i++)
				Fx[1][i] += f[i];
			CountF();
		}

		public void AddF(double mx)
		{
			for (var i = 0; i < FuncHelper.N; i++)
				Fx[1][i] += mx;
			CountF();
		}

		public object Clone()
		{
			var f = new Func(Fx);
			return f;
		}
	}
}