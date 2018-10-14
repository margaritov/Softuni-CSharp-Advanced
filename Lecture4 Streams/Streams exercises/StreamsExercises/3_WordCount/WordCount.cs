using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3_WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//";
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(path + "words.txt"))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (!words.ContainsKey(line))
                    { words[line] = 0; }
                    line = sr.ReadLine();
                }
            }

            using (StreamReader sr = new StreamReader(path + "text.txt"))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    line = line.ToLower();
                    Regex regex = new Regex(@"[A-Za-z]+");
                    foreach (Match match in regex.Matches(line))
                    {
                        if (words.ContainsKey(match.Value))
                        {
                            words[match.Value]++;
                        }
                    }
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(path + "result.txt"))
            {
                foreach (var word in words.OrderByDescending(x => x.Value))
                {
                    sw.WriteLine($"{word.Key} - {word.Value}");
                }
            }
            // Console.WriteLine();
        }
    }
}
