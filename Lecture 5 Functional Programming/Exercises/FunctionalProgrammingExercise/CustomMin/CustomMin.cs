using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMin
{
    class CustomMin
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> GetMin = n =>
            {
                int smallest = int.MaxValue;
                foreach (var num in n)
                {
                    if (num < smallest)
                    {
                        smallest = num;
                    }
                }

                return smallest;
            };

            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(GetMin(nums));

        }

        private static int GetNum(List<int> nums, Func<List<int>, int> operation)
        {
            int smallest = int.MaxValue;
            foreach (var num in nums)
            {
                if (num < smallest)
                {
                    smallest = num;
                }
            }

            return smallest;
        }
    }
}
