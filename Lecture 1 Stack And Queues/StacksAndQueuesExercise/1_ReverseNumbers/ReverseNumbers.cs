using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace _1_ReverseNumbers
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();
            var inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse);
            foreach (var num in inputNumbers)
            {
                nums.Push(num);
            }
            List<String> outputList = new List<string>();

            while (nums.Count > 0)
            {
                outputList.Add(nums.Pop().ToString());
            }
            Console.WriteLine(String.Join(" ", outputList));
        }
    }
}