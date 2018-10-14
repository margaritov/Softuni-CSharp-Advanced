using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<long> cups = new Queue<long>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList());

            Stack<long> bottles = new Stack<long>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList());

            long wastedWater = 0;
            long currentCup = cups.Peek();
            while (cups.Count > 0 && bottles.Count > 0)
            {
                long currentBottle = bottles.Pop();

                if (currentBottle > currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    currentCup = 0;
                }
                else
                {
                    currentCup -= currentBottle;
                }

                if (currentCup == 0)
                {
                    cups.Dequeue();
                    if (cups.Count > 0)
                    {
                        currentCup = cups.Peek();
                    }
                }
            }

            if (cups.Count == 0)

            {
                Console.WriteLine($"Bottles: {String.Join(" ", bottles.ToArray())}");
            }
            else
            {
                Console.WriteLine($"Cups: {String.Join(" ", cups.ToArray())}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
            ;
        }
    }
}
