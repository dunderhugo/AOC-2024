namespace Aoc_2024_day2
{
	internal class Program
	{
		static bool CheckIfSafe(int i, int j)
		{
			int safeNum = i - j;
			if (safeNum == 0) return true;
			if (safeNum < 4 && safeNum > -4) return false;
			return true;
		}
		static void Main(string[] args)
		{
			string filePath = "..\\..\\..\\input.txt";

			string[] allLines = File.ReadAllLines(filePath);
			int safeAmount = 0;
			int previous = 0;

			foreach (string line in allLines)
			{
				bool increaseBool = false;
				bool decreaseBool = false;
				bool amountBool = false;
				bool notPossible = false;
				string[] splitLine = line.Split(" ");
                for (int i = 0; i < splitLine.Length; i++)
				{
					int current = int.Parse(splitLine[i]);
					if (i > 0)
					{
						amountBool = CheckIfSafe(current, previous);
						if (current == previous)
						{
							increaseBool = true;
							decreaseBool = true;
							amountBool = true;
						}
						else if (current > previous) increaseBool = true;
						else if (current < previous) decreaseBool = true;
					}
					if (amountBool || ((increaseBool && decreaseBool)))
					{
						notPossible = true;
						i = splitLine.Length - 1;
					}

					previous = current;
				}
				if (!notPossible) safeAmount++;
				increaseBool = false;
				decreaseBool = false;
				amountBool = false;
			}
            Console.WriteLine("Part 1" + safeAmount);
        }
	}
}
