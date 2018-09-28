using System;
using System.Collections.Generic;
using System.Linq;

namespace _9_CrossFire
{
    class Crossfire
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = i * cols + j + 1;
                }

            }

            string input = Console.ReadLine();
            while (input.Equals("Nuke it from orbit") == false)
            {
                long[] shotData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

               matrix= ShotMatrix(matrix, shotData);
               // ReformatMatrix(matrix);

                input = Console.ReadLine();
            }
            Printmatrix(matrix);
            //  Console.WriteLine();
        }

        private static void ReformatMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = matrix[i, j + 1];
                        matrix[i, j + 1] = 0;
                    }
                }

            }
        }
        private static int[,] ShotMatrix(int[,] matrix, long[] shotData)
        {
            long shotRow = shotData[0];
            long shotCol = shotData[1];
            long shotRadius = shotData[2];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            //shot horizontal impact:
            long horizontalStart = Math.Max(0, (shotCol - shotRadius));
            long horizontalEnd = Math.Min(cols - 1, shotCol + shotRadius);
            long verticalStart = Math.Max(0, shotRow - shotRadius);
            long verticalEnd = Math.Min(rows - 1, shotRow + shotRadius);

            //Console.WriteLine($"{horizontalStart}:{horizontalEnd} {verticalStart}:{verticalEnd}");

            if (shotRow >= 0 && shotRow < rows && shotRadius > 0 && horizontalStart < cols && horizontalEnd >= 0)
            {
                for (long i = horizontalStart; i <= horizontalEnd; i++)
                {
                    matrix[shotRow, i] = 0;
                }
            }

            if (shotCol >= 0 && shotCol < cols && shotRadius > 0 && verticalStart < rows && verticalEnd >= 0)
            {
                for (long i = verticalStart; i <= verticalEnd; i++)
                {
                    matrix[i, shotCol] = 0;
                }
            }

            if (shotCol >= 0 && shotCol < cols && shotRow >= 0 && shotRow < rows)
            {
                matrix[shotRow, shotCol] = 0;
            }

            int[,] newMatrix = new int[rows, cols];

            int newMatrixRowIndex = 0;
            int newMatrixColIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                newMatrixColIndex = 0;
               bool  isEmptyRow = true;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i,j]!=0)
                    {
                        newMatrix[newMatrixRowIndex, newMatrixColIndex] = matrix[i, j];
                        newMatrixColIndex++;
                        isEmptyRow = false;
                    }
                }
                if (!isEmptyRow)
                {
                    newMatrixRowIndex++;
                }
            }
            return newMatrix;

        }

        private static void Printmatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                // bool isRowEmpty = true;
                List<int> currentRow = new List<int>();
                for (int j = 0; j < cols; j++)
                {

                    if (matrix[i, j] > 0)
                    {
                        //isRowEmpty = false;
                        currentRow.Add(matrix[i, j]);
                        //Console.Write(" " + matrix[i, j]);
                        //currentRow =currentRow.Append(" " + matrix[i, j])
                    }
                }
                if (currentRow.Count > 0)

                {

                    Console.WriteLine(string.Join(" ", currentRow));
                }
            }

        }
    }
}
