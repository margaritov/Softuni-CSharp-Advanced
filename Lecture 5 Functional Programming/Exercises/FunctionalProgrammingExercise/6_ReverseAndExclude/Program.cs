using System;
using System.Linq;

namespace _6_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> IsNotDivisible = (x) => x % divisor != 0;
            Console.WriteLine(String.Join(" ", nums.Where(IsNotDivisible).Reverse()));
        }
    }
}
