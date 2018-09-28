using System;
using System.Linq;

namespace _7_LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine().Trim());
            decimal[][] arr1 = new decimal[rows][];
            decimal[][] arr2 = new decimal[rows][];

            int totalCellsCount = 0;

            for (int i = 0; i < rows; i++)
            {
                arr1[i] = Console.ReadLine()
                    .Trim()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(decimal.Parse)
                    .ToArray();
                totalCellsCount += arr1[i].Length;
            }

            for (int i = 0; i < rows; i++)
            {
                arr2[i] = Console.ReadLine()
                    .Trim()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(decimal.Parse)
                    .Reverse()
                    .ToArray();
                totalCellsCount += arr2[i].Length;
            }

            int firstRowsSum = arr1[0].Length + arr2[0].Length;
            bool isValid = true;

            for (int i = 0; i < rows; i++)
            {
                if ((arr1[i].Length + arr2[i].Length) != firstRowsSum)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                for (int i = 0; i < rows; i++)
                {
                    Console.WriteLine("[" + String.Join(", ", arr1[i]) + ", " + String.Join(", ", arr2[i]) + "]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCellsCount}");
            }
        }

    }
}
