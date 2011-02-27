using ZedGraph;

namespace RDA
{
	public static class GBuilder
	{
		public static IPointList MakeGraph(double[][] fx)
		{
            IPointList points = new PointPairList(fx[0], fx[1]);
            return points; 
		}

		public static IPointList MakeGraph(double[] x, double[] fx)
		{
			IPointList points = new PointPairList(x, fx);
			return points;
		}
	}
}
