using System;
using System.Linq;

namespace _5_RubiksMatrix
{
    class RubiksMatrix
    {

        private static void RotateLeft(int[,] matrix, int row, int count)
        {
            int colCount = matrix.GetLength(1);
            while (count > 0)
            {
                int temp = matrix[row, 0];
                for (int i = 0; i < colCount - 1; i++)
                {
                    matrix[row, i] = matrix[row, i + 1];
                }
                matrix[row, colCount - 1] = temp;
                count--;
            }
        }

        private static void RotateRight(int[,] matrix, int row, int count)
        {
            int colCount = matrix.GetLength(1);
            while (count > 0)
            {
                int temp = matrix[row, colCount - 1];
                for (int i = colCount - 1; i > 0; i--)
                {
                    matrix[row, i] = matrix[row, i - 1];
                }
                matrix[row, 0] = temp;
                count--;
            }
        }

        private static void RotateUp(int[,] matrix, int col, int count)
        {
            int rowCount = matrix.GetLength(0);
            while (count > 0)
            {
                int temp = matrix[0, col];
                for (int i = 0; i < rowCount - 1; i++)
                {
                    matrix[i, col] = matrix[i + 1, col];
                }
                matrix[rowCount - 1, col] = temp;
                count--;
            }
        }
        
        private static void RotateDown(int[,] matrix, int col, int count)
        {
            int rowCount = matrix.GetLength(0);
            while (count > 0)
            {
                int temp = matrix[rowCount - 1, col];
                for (int i = rowCount - 1; i > 0; i--)
                {
                    matrix[i, col] = matrix[i - 1, col];
                }
                matrix[0, col] = temp;
                count--;
            }
        }
        
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];
            int commandCount = int.Parse(Console.ReadLine().Trim());
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            //fill matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = (i * cols) + j;
                }
            }

            //rotate matrix
            while (commandCount > 0)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                switch (command[1])
                {
                    case "left":
                        RotateLeft(matrix, int.Parse(command[0]), int.Parse(command[2]) % matrix.GetLength(1));

                        break;

                    case "right":
                        RotateRight(matrix, int.Parse(command[0]), int.Parse(command[2]) % matrix.GetLength(1));

                        break;
                    case "up":

                        RotateUp(matrix, int.Parse(command[0]), int.Parse(command[2]) % matrix.GetLength(0));
                        break;

                    case "down":
                        RotateDown(matrix, int.Parse(command[0]), int.Parse(command[2]) % matrix.GetLength(0));
                        break;

                    default:
                        break;
                }
                commandCount--;
            }

            //final scan matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int correctValue = i * cols + j;
                    if (matrix[i, j] == correctValue)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        bool found = false;
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == correctValue)
                                {
                                    Console.WriteLine($"Swap ({i}, {j}) with ({row}, {col})");
                                    int temp = matrix[i, j];
                                    matrix[i, j] = matrix[row, col];
                                    matrix[row, col] = temp;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
