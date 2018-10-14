using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_InfernoIII
{
    class InfernoIII
    {
        static void Main(string[] args)
        {

            Func<int, List<int>, int> SumLeft = (index, list) =>
            { return index > 0 ? list[index] + list[index - 1] : list[index]; };

            Func<int, List<int>, int> SumRight = (index, list) =>
            { return index < list.Count - 1 ? list[index] + list[index + 1] : list[index]; };

            Func<int, List<int>, int> SumLeftRight = (index, list) => { return SumLeft(index, list) + SumRight(index, list) - list[index]; };

            List<int> gems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> PositionsToExclude = new List<int>();

            var filters = new Dictionary<string, HashSet<int>>();

            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string command = input[0];
            string filterName = input[1];
            int filterValue = int.Parse(input[2]);

            var indexesToExclude = new HashSet<int>();
            while (command != "Forge")
            {
                filterName = input[1];
                filterValue = int.Parse(input[2]);
                switch (command)
                {
                    case "Exclude":
                        if (!filters.ContainsKey(input[1]))
                        {
                            filters.Add(input[1], new HashSet<int>());
                        }
                        filters[input[1]].Add(int.Parse(input[2]));
                        break;
                    case "Reverse":
                        if (filters.ContainsKey(filterName) && filters[filterName].Contains(filterValue))
                            filters[filterName].Remove(filterValue);
                        if (filters[filterName].Count == 0)
                        {
                            filters.Remove(filterName);
                        }
                        break;
                    default:
                        break;
                }


                input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = input[0];

            }

            Console.WriteLine();

            foreach (var filter in filters)
            {
                switch (filter.Key)
                {
                    case "Sum Left":

                        foreach (var currentFilterValue in filter.Value)
                        {
                            List<int> gemsToRemove = ScanGemsToRemove(gems, SumLeft, currentFilterValue);
                            if (gemsToRemove.Count != 0)
                            {
                                gemsToRemove.ForEach(x => indexesToExclude.Add(x));
                            }
                        }
                        break;
                    case "Sum Right":
                        foreach (var currentFilterValue in filter.Value)
                        {
                            List<int> gemsToRemove = ScanGemsToRemove(gems, SumRight, currentFilterValue);
                            if (gemsToRemove.Count != 0)
                            {
                                gemsToRemove.ForEach(x => indexesToExclude.Add(x));
                            }
                        }
                        break;
                    case "Sum Left Right":
                        foreach (var currentFilterValue in filter.Value)
                        {
                            List<int> gemsToRemove = ScanGemsToRemove(gems, SumLeftRight, currentFilterValue);
                            if (gemsToRemove.Count != 0)
                            {
                                gemsToRemove.ForEach(x => indexesToExclude.Add(x));
                            }
                        }
                        break;

                }
            }

            //Console.WriteLine(string.Join(" ", indexesToExclude));
            var filtered = gems.Where((x, i) => !indexesToExclude.Contains(i)).ToArray();
            Console.WriteLine(string.Join(" ", filtered));

        }

        private static List<int> ScanGemsToRemove(List<int> gems, Func<int, List<int>, int> sumLeft, int currentFilterValue)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < gems.Count; i++)
            {


                if (sumLeft(i, gems) == currentFilterValue)
                {
                    result.Add(i);
                }

            }
            return result;
        }
    }

}
