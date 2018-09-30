using System;
using System.Collections.Generic;

namespace _6_WardRobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            while (count-- > 0)
            {
                string[] data = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = data[0];
                string[] items = data[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(color))
                {
                    clothes[color] = new Dictionary<string, int>();
                }
                foreach (var item in items)
                {
                    if (clothes[color].ContainsKey(item) == false)
                    {
                        clothes[color][item] = 0;
                    }
                    clothes[color][item]++;
                }
            }

            string[] itemToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in clothes[color.Key])
                {
                    if (color.Key == itemToFind[0] && item.Key == itemToFind[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
