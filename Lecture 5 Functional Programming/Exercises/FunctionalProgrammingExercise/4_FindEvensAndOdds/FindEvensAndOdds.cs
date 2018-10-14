using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_FindEvensAndOdds
{
    class FindEvensAndOdds
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse).ToArray();

            string target = Console.ReadLine();
            Func<int, bool> Filter = x => x % 2 == 0; ;
            if (target == "odd")
            {
                Filter = x => x % 2 != 0;
            }

            List<int> filtered = new List<int>();
            for (int i = input[0]; i <= input[1]; i++)
            {
                if (Filter(i) == true)
                {
                    filtered.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}
