using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (!input.Equals("end of contests"))
            {
                string[] tokens = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (contests.ContainsKey(tokens[0]) == false)
                {
                    contests[tokens[0]] = tokens[1];
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            while (!input.Equals("end of submissions"))
            {
                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string currentContest = tokens[0];
                string currentPassword = tokens[1];
                string currentUser = tokens[2];
                int currentScore = int.Parse(tokens[3]);

                if (contests.ContainsKey(currentContest) && contests[currentContest] == currentPassword)
                { //valid contest and valid password provided
                    if (users.ContainsKey(currentUser) == false)
                    { //create user and add contest
                        users[currentUser] = new Dictionary<string, int>();
                    }

                    if (users[currentUser].ContainsKey(currentContest) == false)
                    {
                        users[currentUser][currentContest] = currentScore;
                    }
                    else if (users[currentUser][currentContest] < currentScore)
                    { //update score if better that previous
                        users[currentUser][currentContest] = currentScore;
                    }
                }
                input = Console.ReadLine();
            }

            var topUser = users.OrderByDescending(c => c.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {topUser.Key} with total {topUser.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
            Console.WriteLine();
        }
    }
}
