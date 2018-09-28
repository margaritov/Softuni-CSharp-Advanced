using System;
using System.Linq;
namespace _3_SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int count = 0;
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[input[0], input[1]];
            for (int i = 0; i < input[0]; i++)
            {
                var row = Console.ReadLine().ToCharArray().Where(c => c != ' ').ToArray();
                for (int j = 0; j < input[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i - 1, j - 1] == matrix[i - 1, j] &&
                        matrix[i - 1, j - 1] == matrix[i, j - 1] &&
                        matrix[i - 1, j - 1] == matrix[i, j])
                    {
                        count++;
                    }

                }
            }
            Console.WriteLine(count);

        }
    }
}
