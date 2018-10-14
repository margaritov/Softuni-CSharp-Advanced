using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_HitList
{

    class HitList
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> names = new Dictionary<string, Dictionary<string, string>>();


            string input = Console.ReadLine();
            while (input != "end transmissions")
            {
                string[] tokens = input.Split("=;:".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!names.ContainsKey(tokens[0]))
                {
                    names.Add(tokens[0], new Dictionary<string, string>());
                }
                int keyIndex = 1;
                while (keyIndex < tokens.Length)
                {
                    names[tokens[0]][tokens[keyIndex]] = tokens[keyIndex + 1];
                    keyIndex += 2;
                }
                input = Console.ReadLine();
            }
            string targetName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).First();
            Console.WriteLine($"Info on {targetName}:");
            int infoIndex = GetData(names[targetName]);
            if (infoIndex>targetIndex)
            {
                Console.WriteLine("Proceed");
            }else
            {
                Console.WriteLine($"Need {targetIndex-infoIndex} more info.");
            }
            ;
        }

        private static int GetData(Dictionary<string, string> person)
        {
            int infoIndex = 0;
            

            foreach ( var record in person.OrderBy(x =>x.Key))
            {         

                Console.WriteLine($"---{record.Key}: {record.Value}");
                infoIndex += record.Key.Length;
                infoIndex += record.Value.Length;

            }
            Console.WriteLine($"Info index: {infoIndex}");

            return infoIndex;
        }
    }
}
