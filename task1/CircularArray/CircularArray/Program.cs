using System;
using System.Text;

namespace CircularArray
{
	public class Program
	{
		static void Main(string[] args)
		{
			var n = int.Parse(args[0]); // array length
			var m = int.Parse(args[1]); // step

			if(n == m)
			{
				throw new ArgumentException("values can not be the same");
			}

			var firstElementConst = "1";
			int[] baseArray = new int[n];

			for (int i = 0; i < baseArray.Length; i++)
			{
				baseArray[i] = i + 1;
			}

			var outputValue = new StringBuilder(firstElementConst);
			int stepValue;
			var stepCount = 0;

			for (int i = 0; i < baseArray.Length; i++)
			{
				stepCount++;

				if (stepCount == m)
				{
					stepValue = baseArray[i];

					if (stepValue == baseArray[0])
					{
						break;
					}

					stepCount = 1;
					outputValue.Append(baseArray[i].ToString());
				}

				if (i == baseArray.Length - 1) i = -1; // because the next iteration will increment value for i
			}

			Console.WriteLine(outputValue.ToString());
		}
	}
}
