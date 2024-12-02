using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace AOC_2024
{
	internal class Program
	{
		static void Main(string[] args)
		{


			string filePath = "..\\..\\..\\input.txt";
			List<int> leftValue = new List<int>();
			List<int> rightValue = new List<int>();
			List<int> sumValue = new List<int>();
			string[] allLines = File.ReadAllLines(filePath);
			int totalSum = 0;
			Console.WriteLine("Alllines count: " + allLines.Length);
			foreach (string line in allLines)
			{
				string[] splitLine = line.Split("   ");
				leftValue.Add(int.Parse(splitLine[0]));
				rightValue.Add(int.Parse(splitLine[1]));
			}
            Console.WriteLine("right count: " + rightValue.Count());
            leftValue.Sort();
			rightValue.Sort();

			for(int i = 0; i < leftValue.Count(); i++)
			{
				int sum = leftValue[i] - rightValue[i];
				if(sum < 0) sum = Math.Abs(sum);
				sumValue.Add(sum);
			}
			foreach(int i in sumValue)
			{
				totalSum += i;
			}
			int similaritySum = 0;

			foreach(int i in leftValue)
			{
				int totalSimilarity = 0;
				foreach (int j in rightValue)
				{
					if (i ==  j)
					{
						totalSimilarity++;
					}
				}
				similaritySum += totalSimilarity * i;
            }
			Console.WriteLine("Part 1: " + totalSum);
			Console.WriteLine("Part 2: " + similaritySum);
		}
	}
}
