using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int stationsCount = int.Parse(Console.ReadLine());
            Queue<int> stations = new Queue<int>(stationsCount);
            for (int i = 0; i < stationsCount; i++)
            {
                int[] stationData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                int currentStationBalance = stationData[0] - stationData[1];
                stations.Enqueue(currentStationBalance);
            }

            int startingStationNumber = 0;
            int stationsVisited = 0;
            while (stationsVisited < stationsCount)
            {
                int tank = 0;

                foreach (var station in stations)
                {
                    tank += station;
                    stationsVisited++;
                    if (tank < 0)
                    {
                        startingStationNumber++;
                        stationsVisited = 0;
                        stations.Enqueue(stations.Dequeue());
                        break;
                    }
                }
            }
            Console.WriteLine(startingStationNumber.ToString());
        }
    }
}
