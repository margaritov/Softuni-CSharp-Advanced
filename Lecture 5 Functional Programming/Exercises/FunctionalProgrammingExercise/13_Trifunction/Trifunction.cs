using System;
using System.Linq;
namespace _13_Trifunction
{
    class Trifunction
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Func<string, int, bool> CalcAsciiSum = (name, totalSum) => name.Sum(x => x) >= totalSum;
            Func<string[], Func<string, int, bool>, string> FilterFunc = (names, func) => names.FirstOrDefault(x => func(x, n));
            Console.WriteLine(FilterFunc(list, CalcAsciiSum));
        }

        private static string CheckNames(string[] names, Func<string, int, bool> calcAsciiValue)
        {
            return names.Where(calcAsciiValue).FirstOrDefault();
        }
    }
}
