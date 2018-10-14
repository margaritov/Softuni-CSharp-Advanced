using System;
using System.Linq;

namespace _1_ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> printer = c => Console.WriteLine(c);

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList().ForEach(printer);
        }
    }
}
