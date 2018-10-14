using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_MovieTime
{
    class MovieTime
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> movies = new Dictionary<string, int>();
            string favGenre = Console.ReadLine();
            string favDuration = Console.ReadLine();
            int playListDuration = 0;
            Func<int, int, bool> favOrder;
            if (favDuration == "Short")
            {
                favOrder = (a, b) => a < b;
            }
            else if (favDuration == "Long")
            {
                favOrder = (a, b) => a > b;
            }
            string input = Console.ReadLine();
            while (input != "POPCORN!")
            {
                string[] tokens = input.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                playListDuration += TimeToInt(tokens[2]);
                if (tokens[1] == favGenre)
                {
                    if (!movies.ContainsKey(tokens[0]))
                    {
                        movies.Add(tokens[0], TimeToInt(tokens[2]));
                        //Console.WriteLine($"con back {IntToTime(TimeToInt(tokens[2]))}");
                    }
                }
                input = Console.ReadLine();
            }

            if (favDuration == "Short")
            {
                foreach (var movie in movies.OrderBy(x => x.Value))
                {
                    Console.WriteLine(movie.Key);
                    string choice = Console.ReadLine();
                    if (choice == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {IntToTime(movie.Value)}");
                        break;
                    }
                }
            }
            else
            {
                foreach (var movie in movies.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine(movie.Key);
                    string choice = Console.ReadLine();
                    if (choice == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {IntToTime(movie.Value)}");
                        break;
                    }
                }
            }
            Console.WriteLine($"Total Playlist Duration: {IntToTime(playListDuration)}");
            ;
        }
        private static string IntToTime(int secondsCount)
        {
            if (secondsCount < 0) { secondsCount = 0; }
            string result = "";
            int seconds = secondsCount % 60;
            secondsCount -= seconds;
            secondsCount /= 60;
            int minutes = secondsCount % 60;
            secondsCount -= minutes;

            int hours = secondsCount / 60;
            result = ($"{hours:d2}:{minutes:d2}:{seconds:d2}");
            return result;
        }

        private static int TimeToInt(string time)
        {
            int[] tokens = time.Split(":".ToCharArray()).Select(int.Parse).ToArray();
            return tokens[0] * 3600 + tokens[1] * 60 + tokens[2];
        }
    }
}
