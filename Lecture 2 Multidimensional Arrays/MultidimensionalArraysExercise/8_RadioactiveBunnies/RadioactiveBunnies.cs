using System;
using System.Linq;

namespace _8_RadioactiveBunnies
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point()
        {

        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class RadioactiveBunnies
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[input[0], input[1]];
            int currentRow = 0;
            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < input[0]; i++)
            {
                char[] tempRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < tempRow.Length; j++)
                {
                    matrix[currentRow, j] = tempRow[j];
                    if (tempRow[j] == 'P')
                    {
                        playerRow = currentRow;
                        playerCol = j;
                    }
                }
                currentRow++;
            }

            char[] commands = Console.ReadLine().ToUpper().ToCharArray();
            bool isAlive = true;
            bool isEscaped = false;
            int commandIndex = 0;
            string status = "";
            while (isAlive && !isEscaped)
            {
                MovePlayer(matrix, ref playerRow, ref playerCol, commands[commandIndex], ref isAlive, ref isEscaped);
                commandIndex++;

                ExpandAllBunnies(matrix);
                if (!isEscaped)
                {
                    isAlive = IsAlivePlayer(matrix);
                }

            }

            PrintMatrix(matrix);
            status = isAlive ? "won" : "dead";
            Console.WriteLine($"{status}: {playerRow} {playerCol}");
            //Console.WriteLine();
        }

        private static void MovePlayer(char[,] matrix, ref int playerRow, ref int playerCol, char command, ref bool isAlive, ref bool isEscaped)
        {
            switch (command)
            {
                case 'U':
                    if (playerRow == 0)
                    {
                        matrix[playerRow, playerCol] = '.';
                        isEscaped = true;
                    }
                    else if (matrix[playerRow - 1, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow--;
                        isAlive = false;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow--;
                        matrix[playerRow, playerCol] = 'P';
                    }
                    break;
                case 'D':
                    if (playerRow == matrix.GetLength(0) - 1)
                    {
                        matrix[playerRow, playerCol] = '.';
                        isEscaped = true;
                    }
                    else if (matrix[playerRow + 1, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow++;
                        isAlive = false;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow++;
                        matrix[playerRow, playerCol] = 'P';
                    }
                    break;
                case 'R':
                    if (playerCol == matrix.GetLength(1) - 1)
                    {
                        matrix[playerRow, playerCol] = '.';
                        isEscaped = true;
                    }
                    else if (matrix[playerRow, playerCol + 1] == 'B')
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol++;
                        isAlive = false;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol++;
                        matrix[playerRow, playerCol] = 'P';
                    }
                    break;
                case 'L':
                    if (playerCol == 0)
                    {
                        matrix[playerRow, playerCol] = '.';
                        isEscaped = true;
                    }
                    else if (matrix[playerRow, playerCol - 1] == 'B')
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol--;
                        isAlive = false;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol--;
                        matrix[playerRow, playerCol] = 'P';
                    }
                    break;

                default:
                    break;
            }
        }

        private static void ExpandAllBunnies(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        ExpandBunny(matrix, i, j);
                    }
                }
            }
            ConfirmNewBunnies(matrix);
        }

        // expand a bunny to up, down, left, right cell - mark new bunnies 'N'
        private static void ExpandBunny(char[,] matrix, int y, int x)
        {
            if (IsInsideMatrix(matrix, y - 1, x) && matrix[y - 1, x] != 'B')
            {
                matrix[y - 1, x] = 'N';
            }

            if (IsInsideMatrix(matrix, y + 1, x) && matrix[y + 1, x] != 'B')
            {
                matrix[y + 1, x] = 'N';
            }

            if (IsInsideMatrix(matrix, y, x - 1) && matrix[y, x - 1] != 'B')
            {
                matrix[y, x - 1] = 'N';
            }
            if (IsInsideMatrix(matrix, y, x + 1) && matrix[y, x + 1] != 'B')
            {
                matrix[y, x + 1] = 'N';
            }
        }

        //returns true if input coordinates are inside a matrix
        private static bool IsInsideMatrix(char[,] matrix, int row, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (col >= 0 && col < matrix.GetLength(1) &&
                row >= 0 && row < matrix.GetLength(0))
            {
                return true;
            }
            return false;
        }

        private static void ConfirmNewBunnies(char[,] matrix)
        {
            // set new bunnies from 'N' to 'B'
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 'N')
                    {
                        matrix[i, j] = 'B';
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsAlivePlayer(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
