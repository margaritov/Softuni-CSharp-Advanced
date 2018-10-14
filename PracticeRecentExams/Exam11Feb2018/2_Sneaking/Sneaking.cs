using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2_Sneaking
{
    class Sneaking
    {
        static int[] samPosition = new int[2];
        static int[] nikoladzePosition = new int[2];
        static bool isSamAlive = true;
        static bool isEnemyAlive = true;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = 0;
            char[][] room = new char[rows][];

            for (int r = 0; r < rows; r++)
            {
                string row = Console.ReadLine();
                room[r] = new char[row.Length];
                for (int c = 0; c < row.Length; c++)
                {

                    room[r][c] = row[c];
                    if (room[r][c] == 'S')
                    {
                        samPosition[0] = r;
                        samPosition[1] = c;
                    }
                    else if (room[r][c] == 'N')
                    {
                        nikoladzePosition[0] = r;
                        nikoladzePosition[1] = c;
                    }
                }



            }
            // Console.WriteLine();
            var moves = Console.ReadLine();

            foreach (var move in moves)
            {
                MoveEnemies(room);
                if (!isSamAlive)
                {
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    room[samPosition[0]][samPosition[1]] = 'X';
                    break;
                }


                Console.WriteLine();
                MoveSam(move, room, samPosition);
                if (samPosition[0] == nikoladzePosition[0])
                {
                    room[nikoladzePosition[0]][nikoladzePosition[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            PrintMatrix(room);
            //Console.WriteLine();
        }

        private static void MoveSam(char direction, char[][] room, int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = '.';

            switch (direction)
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;

                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            room[samPosition[0]][samPosition[1]] = 'S';

        }



        private static void MoveEnemies(char[][] room)
        {
            for (int r = 0; r < room.Length; r++)
            {
                for (int i = 0; i < room[r].Length; i++)
                {
                    if (room[r][i] == 'd')
                    {
                        if (i == 0)
                        {
                            room[r][i] = 'b';
                            if (samPosition[0] == r && samPosition[1] > 0)
                            {
                                isSamAlive = false;
                            }
                        }
                        else
                        {
                            room[r][i] = '.';
                            room[r][i - 1] = 'd';
                            if (samPosition[0] == r && samPosition[1] < i - 1)
                            {
                                isSamAlive = false;
                            }
                        }

                        break;
                    }
                    else if (room[r][i] == 'b')
                    {
                        if (i == room[r].Length - 1)
                        {
                            room[r][i] = 'd';
                            if (samPosition[0] == r)
                            {
                                isSamAlive = false;
                            }
                        }
                        else
                        {
                            room[r][i] = '.';
                            room[r][i + 1] = 'b';
                            if (samPosition[0] == r && samPosition[1] > i + 1)
                            {
                                isSamAlive = false;

                            }
                        }

                        break;
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] room)
        {
            foreach (var row in room)
            {
                Console.WriteLine(row);
            }
        }
    }
}
