using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PartyReservationFilterModule
{
    class PartyFilter
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> predicate;

            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var filters = new Dictionary<string, HashSet<string>>();
            while (input[0] != "Print")
            {
                predicate = GetPredicate(input[1], input[2]);
                switch (input[0])
                {
                    case "Add filter":
                        if (!filters.ContainsKey(input[1]))
                        {
                            filters[input[1]] = new HashSet<string>();
                        }
                        filters[input[1]].Add(input[2]);
                        break;
                    case "Remove filter":
                        if (filters.ContainsKey(input[1]) && filters[input[1]].Contains(input[2]))
                        {
                            filters[input[1]].Remove(input[2]);
                        }
                        break;
                }


                input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var filter in filters)
            {
                foreach (var item in filter.Value)
                {
                    predicate = GetPredicate(filter.Key, item);
                    guests.RemoveAll(predicate);
                }
            }

            Console.WriteLine(String.Join(" ", guests));

        }

        private static Predicate<string> GetPredicate(string condition, string parameter)
        {
            switch (condition)
            {
                case "Starts with":
                    return x => x.StartsWith(parameter);
                case "Ends with":
                    return x => x.EndsWith(parameter);
                case "Length":
                    return x => x.Length == int.Parse(parameter);
                case "Contains":
                    return x => x.Contains(parameter);
                default:
                    return null;
            }
        }
    }
}
