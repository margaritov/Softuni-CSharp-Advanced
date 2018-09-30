using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            while (inputCount-- > 0)
            {
                Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(e => elements.Add(e));
            }
            Console.WriteLine(string.Join(" ", elements));
            Console.WriteLine();
        }
    }
}
