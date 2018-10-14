using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate;
            Queue<string> guests = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (tokens[0] != "Party!")
            {
                predicate = GetPredicate(tokens[1], tokens[2]);
                switch (tokens[0])
                {
                    case "Remove":
                        Remove(guests, predicate);
                        break;
                    case "Double":
                        Double(guests, predicate);
                        break;
                }
                tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{String.Join(", ", guests)} are going to the party!");
            }
        }

        private static void Double(Queue<string> guests, Predicate<string> predicate)
        {
            int processedGuests = 0;
            int initialGuestsCount = guests.Count;
            while (processedGuests++ < initialGuestsCount)
            {
                var currentGuest = guests.Dequeue();
                guests.Enqueue(currentGuest);
                if (predicate(currentGuest))
                {
                    guests.Enqueue(currentGuest);
                }
            }
        }

        private static void Remove(Queue<string> guests, Predicate<string> predicate)
        {
            int processedGuests = 0;
            int initialGuestsCount = guests.Count;
            while (processedGuests++ < initialGuestsCount)
            {
                string currentGuest = guests.Dequeue();
                if (!predicate(currentGuest))
                {
                    guests.Enqueue(currentGuest);
                }
            }

        }

        private static Predicate<string> GetPredicate(string condition, string parameter)
        {
            switch (condition)
            {
                case "StartsWith":
                    return x => x.StartsWith(parameter);
                case "EndsWith":
                    return x => x.EndsWith(parameter);
                case "Length":
                    return x => x.Length == int.Parse(parameter);
                default:
                    return null;
            }
        }
    }
}
