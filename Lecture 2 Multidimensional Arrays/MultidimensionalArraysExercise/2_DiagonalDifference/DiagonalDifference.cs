using System;
using System.Linq;

namespace _2_DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long primaryDiagonal = 0;
            long secondaryDiagonal = 0;
            long[,] matrix = new long[n, n];

            for (int i = 0; i < n; i++)
            {
                var temp = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = temp[j];
                }
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, n - i - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
