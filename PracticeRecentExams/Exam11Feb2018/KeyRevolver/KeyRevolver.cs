using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int value = int.Parse(Console.ReadLine());

            int bulletsLeftInBarrel = Math.Min(barrelSize, bullets.Count);
            int bulletsShooted = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                bulletsShooted++;
                bulletsLeftInBarrel--;

                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsLeftInBarrel == 0 && bullets.Count>0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsLeftInBarrel = Math.Min(barrelSize, bullets.Count);
                }
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - bulletsShooted * bulletPrice}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            //Console.WriteLine();
        }
    }
}
