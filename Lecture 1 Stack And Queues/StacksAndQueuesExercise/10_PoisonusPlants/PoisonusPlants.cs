using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_PoisonusPlants
{
    class PoisonusPlants
    {
        static void Main(string[] args)
        {
            int countPlants = int.Parse(Console.ReadLine());
            Queue<int> plants = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int countDays = 0;
            while (true)
            {
                int dayBeginPlantsCount = plants.Count;
                int leftPlantPesticide = plants.Peek();

                for (int i = 0; i < dayBeginPlantsCount; i++)
                {
                    int currentPlantPesticide = plants.Dequeue();

                    // if plant has less ot equal pesticide amount than left-side plant it survives
                    if (currentPlantPesticide <= leftPlantPesticide)
                    {
                        plants.Enqueue(currentPlantPesticide);
                    }

                    leftPlantPesticide = currentPlantPesticide;
                }

                if (plants.Count == dayBeginPlantsCount)
                { // no plants died - exit loop
                    break;
                }
                countDays++;
            }
            Console.WriteLine(countDays.ToString());
        }
    }
}
