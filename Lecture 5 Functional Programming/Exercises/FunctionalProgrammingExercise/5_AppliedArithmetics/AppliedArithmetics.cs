using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();

            Func<int, int> Add = x => ++x;
            Func<int, int> Subtract = x => --x;
            Func<int, int> Multiply = x => x * 2;
            Action<List<int>> Print = l => Console.WriteLine(String.Join(" ", l));

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = Process(nums, Add);
                        break;
                    case "subtract":
                        nums = Process(nums, Subtract);
                        break;
                    case "multiply":
                        nums = Process(nums, Multiply);
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", nums));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }

        static int[] Process(int[] nums, Func<int, int> operation)
        {
            return nums.Select(operation).ToArray();
        }
    }
}
