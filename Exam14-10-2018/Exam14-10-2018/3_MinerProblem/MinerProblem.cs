using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_MinerProblem
{
    class MinerProblem
    {
        static int collected = 0;
        static int coalsTotal = 0;
        static int minerRow = 0;
        static int minerCol = 0;
        static char[][] field;
        static bool gameOver = false;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());
            field = new char[n][];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().ToCharArray().Where(c => c != ' ').ToArray();
                field[i] = row;
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == 's')
                    {
                        minerCol = j;
                        minerRow = i;
                    }
                    else if (row[j] == 'c')
                    {
                        coalsTotal++;
                    }
                }
            }

            while (commands.Count > 0 && gameOver == false && coalsTotal > collected)
            {
                Move(commands.Dequeue());
            }


            if (!gameOver)
            {
                if (collected == coalsTotal) { Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})"); }
                else
                {
                    Console.WriteLine($"{coalsTotal - collected} coals left. ({minerRow}, {minerCol})");
                }
            }
            ;
        }

        private static void Move(string command)
        {
            field[minerRow][minerCol] = '*';

            switch (command)
            {
                case "up":
                    if (minerRow > 0)
                    {
                        minerRow--;
                    }
                    break;
                case "down":
                    if (minerRow < field.Length - 1)
                    {
                        minerRow++;
                    }
                    break;
                case "right":
                    if (minerCol < field[0].Length - 1)
                    {
                        minerCol++;
                    }
                    break;
                case "left":
                    if (minerCol > 0)
                    {
                        field[minerRow][minerCol] = '*';
                        minerCol--;
                    }
                    break;
            }
            CheckField(minerRow, minerCol);
            field[minerRow][minerCol] = 's';
        }

        private static void CheckField(int minerRow, int minerCol)
        {
            if (field[minerRow][minerCol] == 'c')
            {
                collected++;
                field[minerRow][minerCol] = '*';
            }
            else if (field[minerRow][minerCol] == 'e')
            {
                Console.WriteLine($"Game over! ({ minerRow}, { minerCol})");
                gameOver = true;
            }
        }

        private static void PrintField(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                Console.WriteLine(String.Join(" ", field[i]));
            }
        }
    }
}
