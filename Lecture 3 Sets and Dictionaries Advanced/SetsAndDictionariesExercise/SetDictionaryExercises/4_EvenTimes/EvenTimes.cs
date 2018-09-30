using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();
            int count = int.Parse(Console.ReadLine());
            while (count-- > 0)
            {
                int num = int.Parse(Console.ReadLine());
                if (!nums.ContainsKey(num))
                {
                    nums[num] = 0;
                }
                nums[num]++;
            }
            Console.WriteLine(String.Join(" ", nums
                .Where(n => n.Value % 2 == 0)
                .Select(a => a.Key)));
        }
    }
}
