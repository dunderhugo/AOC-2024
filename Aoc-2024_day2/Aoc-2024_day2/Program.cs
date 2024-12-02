using System.Runtime.Serialization.Json;

namespace Aoc_2024_day2
{
	internal class Program
	{
		static bool AmountIncreaseDecreaseCheck(int i, int j)
		{
			int safeNum = i - j;
			if (safeNum < 4 && safeNum > -4 && safeNum != 0) return false;
			return true;
		}
		static void SetToFalse(ref bool increaseBool, ref bool decreaseBool, ref bool amountBool, ref bool possible, ref bool sameAmount)
		{
			increaseBool = false;
			decreaseBool = false;
			amountBool = false;
			possible = true;
			sameAmount = false;
		}
		static bool SameAmountCheck(int i, int j) 
		{
			if(j == i) return true;
			return false;
		}
		static void Main(string[] args)
		{
			string filePath = "..\\..\\..\\input.txt";

			string[] allLines = File.ReadAllLines(filePath);
			int safeAmount = 0;

			foreach (string line in allLines)
			{
                bool increaseBool = false;
				bool decreaseBool = false;
				bool amountBool = false;
				bool sameAmount = false;
				bool possible = true;
				bool checkAgain = true;
				string[] stringArr = line.Split(" ");
                int[] intArr = Array.ConvertAll(stringArr, int.Parse);
				int amountOfTimesLooped = 0;
				int indexToSkip = -1;
				while (checkAgain)
				{

					int previous = 0;
					for(int i = 0; i < intArr.Length; i++)
					{
						if (indexToSkip == i) i++;
						if(i >= intArr.Length) previous = 0;
						if(previous != 0)
						{
							amountBool = AmountIncreaseDecreaseCheck(intArr[i], previous);
							sameAmount = SameAmountCheck(intArr[i], previous);
							if (intArr[i] > previous) increaseBool = true;
							if (intArr[i] < previous) decreaseBool = true;
						}
						if(amountBool || sameAmount ||(increaseBool && decreaseBool))
						{
							possible = false;
						}
						if(i < intArr.Length) previous = intArr[i];
					}
					if (possible)
					{
						safeAmount++;
						checkAgain = false;
					}
					if (amountOfTimesLooped < intArr.Length && !possible)
					{
						indexToSkip++;
						amountOfTimesLooped++;
					}
					else checkAgain = false;
					SetToFalse(ref increaseBool, ref decreaseBool, ref amountBool, ref possible, ref sameAmount);
				}
				indexToSkip = -1;
				SetToFalse(ref increaseBool, ref decreaseBool, ref amountBool, ref possible, ref sameAmount);
			}

            Console.WriteLine("Part 2 " + safeAmount);
        }
	}
}
