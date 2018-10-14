using System;
using System.Collections.Generic;
using System.Linq;

namespace _9_ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> divisors = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<Predicate<int>> list = new List<Predicate<int>>();
            divisors.ForEach(d => list.Add(x => x % d == 0));

            List<int> result = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                bool valid = true;
                foreach (var p in list)
                {
                    valid = p(i);
                    if (!valid) break;
                }
                if (!valid)
                {
                    continue;
                }
                result.Add(i);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
