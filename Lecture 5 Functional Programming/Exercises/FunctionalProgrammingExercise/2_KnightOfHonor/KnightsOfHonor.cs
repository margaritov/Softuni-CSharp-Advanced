using System;
using System.Linq;

namespace _2_KnightOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> printer = c => Console.WriteLine("Sir " + c);

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList().ForEach(printer);
        }
    }
}
