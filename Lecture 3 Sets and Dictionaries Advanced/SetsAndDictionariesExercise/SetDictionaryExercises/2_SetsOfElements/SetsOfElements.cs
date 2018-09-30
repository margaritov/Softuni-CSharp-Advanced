using System;
using System.Linq;
using System.Collections.Generic;
namespace _2_SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] count = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> setA = new HashSet<int>(count[0]);
            while (count[0]-- > 0)
            {
                setA.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> setB = new HashSet<int>(count[1]);

            while (count[1]-- > 0)
            {
                int num = int.Parse(Console.ReadLine());
                setB.Add(num);
            }
            Console.WriteLine(string.Join(" ", setA.Where(c => setB.Contains(c))));
        }
    }
}
