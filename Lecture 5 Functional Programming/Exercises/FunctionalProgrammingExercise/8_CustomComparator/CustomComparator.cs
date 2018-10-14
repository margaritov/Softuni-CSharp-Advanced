using System;
using System.Linq;

namespace _8_CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {

            Func<int, int, int> comparer = (x, y) =>
                (x % 2 == 0 && y % 2 != 0) ? -1 :
                 (x % 2 != 0 && y % 2 == 0) ? 1 : x.CompareTo(y);

            int [] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse).ToArray();

            Array.Sort(nums, new Comparison<int>(comparer));
            Console.WriteLine(String.Join(" ",nums));
        }
    }
}
