using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3_CryptoBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string sequence = "";
            for (int i = 0; i < n; i++)
            {
                sequence += Console.ReadLine();
            }

            string pattern = @"{[^\]\[{]+}|\[[^\{}\[]+\]";
            MatchCollection matches = Regex.Matches(sequence, pattern);
            List<string> validMatches = new List<string>();
            foreach (Match match in matches)
            {
                validMatches.Add(match.ToString());
            }

            string decoded = "";
            foreach (var str in validMatches)
            {
                string numStr = new string(str.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());

                if (numStr.Length % 3 == 0)
                {
                    decoded += Decode(numStr, str.Length);
                }
            }
            Console.WriteLine(decoded);
            ;
        }

        private static string Decode(string encoded, int length)
        {
            string decoded = "";
            int index = 0;
            while (index < encoded.Length)
            {
                int dec = int.Parse(encoded.Substring(index, 3)) - length;
                decoded += (char)dec;
                index += 3;
            }
            return decoded;
        }
    }
}
