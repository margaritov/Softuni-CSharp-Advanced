using System;
using System.Linq;

namespace _1_MatrixOfPallindromes
{
    class MatrixOfPallinfromes
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string[,] matrix = new string[data[0], data[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ((char)('a' + i)).ToString() + ((char)('a' + i + j)).ToString() + ((char)('a' + i)).ToString();
                    Console.Write(matrix[i, j]);
                    if (j < matrix.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
