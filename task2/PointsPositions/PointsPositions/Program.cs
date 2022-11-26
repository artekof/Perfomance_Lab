using System;
using System.Collections.Generic;
using System.IO;

namespace PointsPositions
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var circlePath = args[0];
			var pointsPath = args[1];
			
			var circleData = File.ReadAllLines(circlePath);
			var pointsData = File.ReadAllLines(pointsPath);

			var circlePoints = circleData[0].Split(' ');
			
			int x0 = int.Parse(circlePoints[0]);
			int y0 = int.Parse(circlePoints[1]);

			int radius = int.Parse(circleData[1]);

			foreach (var point in pointsData)
			{
				var pointsArray = point.Split(' ');

				var xValue = int.Parse(pointsArray[0]);
				var yValue = int.Parse(pointsArray[1]);

				var position = GetPointPositionRelativeCircle(xValue, yValue, radius, x0, y0);

				Console.WriteLine(position);
			}
		}

		private static int GetPointPositionRelativeCircle(int x, int y, int r, int x0 = 0, int y0 = 0)
		{
			var radius = Math.Pow(r, 2);
			var pointsSum = Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2);

			if (radius > pointsSum)
			{
				return 1;
			}

			if (radius < pointsSum)
			{
				return 2;
			}

			return 0;
		}
	}
}
