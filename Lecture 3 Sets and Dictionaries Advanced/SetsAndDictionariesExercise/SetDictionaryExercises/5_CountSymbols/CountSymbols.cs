using System;
using System.Collections.Generic;
using System.Linq;
namespace _5_CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();
            foreach (var c in text.ToCharArray())
            {
                if (!occurences.ContainsKey(c))
                {
                    occurences[c] = 0;
                }
                occurences[c]++;
            }
            occurences.ToList().ForEach(c => Console.WriteLine($"{c.Key}: {c.Value} time/s"));
        }
    }
}
