using System;
using System.Collections.Generic;

namespace _12_MatrixRotation
{
    class MatrixRotation
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            command = command.Substring(0, command.Length - 1);
            command = command.Substring(command.IndexOf('(') + 1);
            int degrees = int.Parse(command) % 360;

            List<string> rows = new List<string>();
            string input = Console.ReadLine();
            int longestRowLength = 0;
            while (input != "END")
            {
                rows.Add(input);
                if (input.Length > longestRowLength)
                {
                    longestRowLength = input.Length;
                }
                input = Console.ReadLine();
            }

            char[,] matrix = new char[rows.Count, longestRowLength];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    matrix[i, j] = rows[i][j];
                }
            }

            if (degrees == 90)
            {
                matrix = RotateMatrix90(matrix);
            }
            else if (degrees == 180)
            {
                matrix = RotateMatrix90(matrix);
                matrix = RotateMatrix90(matrix);
            }
            else if (degrees == 270)
            {
                matrix = RotateMatrix90(matrix);
                matrix = RotateMatrix90(matrix);
                matrix = RotateMatrix90(matrix);
            }
            PrintMatrix(matrix);
            //  Console.WriteLine();
        }

        private static void PrintMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == (char)0)
                    {
                        matrix[i, j] = ' ';
                    }
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }


        private static char[,] RotateMatrix90(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            char[,] newMatrix = new char[cols, rows];
            int newColIndex = rows - 1;
            int oldColIndex = 0;
            while (newColIndex >= 0)
            {
                for (int i = 0; i < cols; i++)
                {
                    newMatrix[i, newColIndex] = matrix[oldColIndex, i];
                }
                oldColIndex++;
                newColIndex--;
            }
            return newMatrix;
        }
    }
}
