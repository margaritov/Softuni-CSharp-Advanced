using System;
using System.Linq;

namespace _7_PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int filterLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> FilterNames = x => x.Length <= filterLength;

            Console.WriteLine(string.Join("\r\n", names.Where(FilterNames)));
        }
    }
}
