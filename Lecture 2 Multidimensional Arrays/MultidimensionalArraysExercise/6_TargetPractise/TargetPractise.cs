using System;
using System.Linq;

namespace _6_TargetPractise
{
    class TargetPractise
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];

            string snake = Console.ReadLine();
            int[] shotDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int shotRow = shotDetails[0];
            int shotCol = shotDetails[1];
            int shotImpact = shotDetails[2];

            FillSnake(matrix, snake);
            ShotFire(matrix, shotRow, shotCol, shotImpact);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                while (!IsBalanced(matrix, col))
                { }
            }
           

            PrintMatrix(matrix);
            //   Console.WriteLine();
        }

        private static bool IsBalanced(char[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int row = 0; row < rows-1; row++)
            {
                if (matrix[row, col] != ' ' && matrix[row + 1,col] == ' ')
                {
                    
                    matrix[row+1, col] = matrix[row, col];
                    matrix[row,col ] = ' ';
                    return false;
                }
            }

            return true;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int pointX, int pointY, int circleX, int circleY, int diameter)
        {

            if ((diameter * diameter) >= (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2)))
            {
                return true;
            }
            return false;
        }

        private static void ShotFire(char[,] matrix, int shotRow, int shotCol, int shotImpact)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (IsInside(col, row, shotCol, shotRow, shotImpact))
                    {
                        matrix[row, col] = ' ';
                    }

                }
            }

        }

        private static void FillSnake(char[,] matrix, string snake)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int snakeCharacterIndex = 0;
            int row = matrix.GetLength(0) - 1;
            while (row >= 0)
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    matrix[row, col] = snake[snakeCharacterIndex];
                    if (snakeCharacterIndex < snake.Length - 1)
                    {
                        snakeCharacterIndex++;
                    }
                    else
                    {
                        snakeCharacterIndex = 0;
                    }
                }

                if (row > 0)
                {
                    row--;
                }
                else
                {
                    break;
                }

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = snake[snakeCharacterIndex];
                    if (snakeCharacterIndex < snake.Length - 1)
                    {
                        snakeCharacterIndex++;
                    }
                    else
                    {
                        snakeCharacterIndex = 0;
                    }
                }

                if (row > 0)
                {
                    row--;
                }
                else
                {
                    break;
                }

            }
        }
    }
}
