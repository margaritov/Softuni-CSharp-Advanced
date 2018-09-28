using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_HeiganDance
{

    class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    class Player
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public double LifePoints { get; set; }
        public double AttackPower { get; set; }
        public Player()
        {
            this.Row = 7;
            this.Col = 7;
            this.LifePoints = 18500;
            this.AttackPower = 0;
        }

        internal void DecreaseLife(double damage)
        {
            this.LifePoints -= damage;
        }
    }

    class HeiganDance
    {
        static Player player = new Player();
        static char[,] matrix = new char[15, 15];
        static double delayedDamage = 0;
        static string spellName;

        static int attackRow;
        static int attackCol;
        static string lastAttack;

        static void Main(string[] args)
        {
            double heiganLifePoints = 3000000;
            player.AttackPower = double.Parse(Console.ReadLine());

            while (true)
            {
                string[] actionHeigan = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string spell = actionHeigan[0];
                attackRow = int.Parse(actionHeigan[1]);
                attackCol = int.Parse(actionHeigan[2]);

                if (player.LifePoints > 0)
                {
                    heiganLifePoints -= player.AttackPower;
                }
                if (lastAttack == "Plague Cloud")
                {
                    player.DecreaseLife(delayedDamage);
                    delayedDamage = 0;
                }

                if (IsAffected(player.Row, player.Col) && heiganLifePoints > 0)
                {
                    if (Move(player, -1, 0))
                    {
                    }
                    else if (Move(player, 0, 1))
                    {
                    }
                    else if (Move(player, 1, 0))
                    {
                    }
                    else if (Move(player, 0, -1))
                    {
                    }
                    else
                    {

                        if (player.LifePoints > 0)
                        {
                            player.DecreaseLife(GetDamage(spell));
                        }
                    }

                }
                if (player.LifePoints <= 0 || heiganLifePoints <= 0)
                {
                    string heiganStatus = heiganLifePoints <= 0 ? "Defeated!" : $"{heiganLifePoints:F2}";
                    string playerStatus = player.LifePoints <= 0 ? $"Killed by {lastAttack}" : $"{player.LifePoints.ToString()}";

                    Console.WriteLine($"Heigan: {heiganStatus}");
                    Console.WriteLine($"Player: {playerStatus}");
                    Console.WriteLine($"Final position: {player.Row}, {player.Col}");
                    break;
                }
            }
        }

        private static int GetDamage(string spell)
        {
            int Damage = 0;
            switch (spell)
            {
                case "Eruption":
                    lastAttack = "Eruption";
                    Damage = 6000;
                    break;
                case "Cloud":
                    lastAttack = "Plague Cloud";
                    delayedDamage = 3500;
                    Damage = 3500;
                    break;
                default:
                    break;
            }
            return Damage;
        }

        private static bool Move(Player player, int row, int col)
        {
            int targetRow = player.Row + row;
            int targetCol = player.Col + col;
            if (IsInside(targetRow, targetCol) && !IsAffected(targetRow, targetCol))
            {
                player.Row = targetRow;
                player.Col = targetCol;
                return true;
            }
            return false;
        }

        //check if cell is inside attack perimeter
        private static bool IsAffected(int row, int col)
        {
            return (row >= attackRow - 1 && row <= attackRow + 1 && col >= attackCol - 1 && col <= attackCol + 1);
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < 15 && col >= 0 && col < 15;
        }
    }
}
