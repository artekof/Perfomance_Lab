using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CastToTheSame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var filePath = args[0];
			var dataFromFile = File.ReadAllLines(filePath);
			var numbersCollection = new List<int>();

			foreach(var itemFromFile in dataFromFile)
			{
				numbersCollection.Add(int.Parse(itemFromFile));
			}

			/* it's a fact that value can be only among numbers */

			var possibleSteps = new List<int>();

			var leftBorder = numbersCollection.Min();
			var rightBorder = numbersCollection.Max();

			for(int i = leftBorder; i <= rightBorder; i++)
			{
				possibleSteps.Add(GetStepsCount(numbersCollection, i));
			}

			var minStepsCount = possibleSteps.Min();

			Console.WriteLine(minStepsCount);
		}

		private static int GetStepsCount(List<int> values, int valueToCast)
		{
			var a = 0;

			foreach(var value in values)
			{
				a += Math.Abs(valueToCast - value);
			}

			return a;
		}
	}
}
