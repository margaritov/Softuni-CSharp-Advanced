using System;
using System.Linq;

namespace _4_MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int i = 0; i < matrixSize[0]; i++)
            {
                int[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int sum = 0;
            int largestSum = 0;
            int largestTopRow = 0;
            int largestTopCol = 0; ;
            for (int i = 0; i < matrixSize[0] - 2; i++)
            {
                for (int j = 0; j < matrixSize[1] - 2; j++)
                {
                    sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                         matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                          matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (sum > largestSum)
                    {
                        largestSum = sum;
                        largestTopRow = i;
                        largestTopCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {largestSum}");
            for (int i = largestTopRow; i < largestTopRow + 3; i++)
            {
                Console.WriteLine($"{matrix[i, largestTopCol]} {matrix[i, largestTopCol + 1]} {matrix[i, largestTopCol + 2]}");
            }
        }
    }
}
