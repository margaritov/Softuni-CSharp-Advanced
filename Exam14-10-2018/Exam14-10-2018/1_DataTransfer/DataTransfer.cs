using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4_CupsAndBottles
{
    class CupsAndBottles
    {
        static int totalData = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string message = Console.ReadLine();
                string pattern = @"s:(?<sender>.+)r:(?<recipient>.+)m--""(?<message>[A-Za-z\s]+)""";
                Regex validData = new Regex(pattern);
                MatchCollection mc = validData.Matches(message);
                foreach (Match m in mc)
                {
                    string sender = new string(m.Groups["sender"].Value.Where(c => Char.IsLetter(c)).ToArray());
                    string recipient = new string(m.Groups["recipient"].Value.Where(c => Char.IsLetter(c)).ToArray());
                    string msg = m.Groups["message"].Value;
                    Console.WriteLine($"Yoo {sender} says \"{msg}\" to {recipient}");

                    totalData += m.Groups["sender"].Value
                        .Where(c => Char.IsDigit(c)).ToList()
                        .Select(a => int.Parse(a.ToString()))
                        .Sum();

                    totalData += m.Groups["recipient"].Value
                        .Where(c => Char.IsDigit(c))
                        .ToList().Select(a => int.Parse(a.ToString()))
                        .Sum();
                }
            }
            Console.WriteLine($"Total data transferred: {totalData}MB");
            ;
        }
    }
}
