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
            Console.WriteLine("Alllines count: " + allLines.Length);
            foreach (string line in allLines)
			{
                string [] splitLine = line.Split("   ");
				leftValue.Add(int.Parse(splitLine[0]));
				rightValue.Add(int.Parse(splitLine[1]));
			}
            Console.WriteLine("right count: " + rightValue.Count());
            leftValue.Sort();
			rightValue.Sort();
			int sum = 0;
			for(int i = 0; i < leftValue.Count(); i++)
			{
				sum = leftValue[i] - rightValue[i];
				if(sum < 0) sum = Math.Abs(sum);
				sumValue.Add(sum);
			}
			int totalSum = 0;
			foreach(int i in sumValue)
			{
				totalSum += i;
			}
			Console.WriteLine(totalSum);

        }


	}
}
