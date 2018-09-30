using System;
using System.Collections.Generic;
using System.Linq;


namespace _7_TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            // every vlogger has list (SortedSet) of followers
            Dictionary<string, SortedSet<string>> vloggers = new Dictionary<string, SortedSet<string>>();

            while (command.Equals("Statistics") == false)
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[1])
                {
                    case "joined":
                        if (vloggers.ContainsKey(tokens[0]) == false)
                        {
                            vloggers[tokens[0]] = new SortedSet<string>();
                        }
                        break;
                    case "followed":
                        string follower = tokens[0];
                        string followed = tokens[2];
                        if (followed != follower && vloggers.ContainsKey(followed) && vloggers.ContainsKey(follower) && !vloggers[followed].Contains(follower))
                        {
                            vloggers[followed].Add(follower);
                        }

                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int rank = 1;
            foreach (var user in vloggers.OrderByDescending(u => u.Value.Count).ThenBy(u => vloggers.Where(vlogger => vlogger.Value.Contains(u.Key)).Count()))
            {

                int followingCount = vloggers.Where(vlogger => vlogger.Value.Contains(user.Key)).Count();
                Console.WriteLine($"{rank}. {user.Key} : {user.Value.Count()} followers, {followingCount} following");
                if (rank == 1)
                {
                    foreach (var follower in user.Value)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                rank++;
            }
            Console.WriteLine();
        }
    }
}
