using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Tagram
{
    class Tagram
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                if (!name.StartsWith("ban "))
                {
                    string tag = tokens[1];
                    int likes = int.Parse(tokens[2]);

                    if (!data.ContainsKey(name))
                    {
                        data.Add(name, new Dictionary<string, int>());
                    }
                    if (!data[name].ContainsKey(tag))
                    {
                        data[name].Add(tag, likes);
                    }
                    else
                    {
                        data[name][tag] += likes;
                    }
                }
                else
                {//ban command
                    string nameToRemove = name.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray()
                        .Skip(1)
                        .First();
                    if (data.ContainsKey(nameToRemove))
                    {
                        data.Remove(nameToRemove);
                    }
                }
                input = Console.ReadLine();
            }

            Print(data);
            ;
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> data)
        {
            foreach (var name in data.OrderByDescending(u => u.Value.Values.Sum()).ThenBy(u => u.Value.Keys.Count()))
            {
                Console.WriteLine(name.Key);
                foreach (var tag in name.Value)
                {
                    Console.WriteLine($" - {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}