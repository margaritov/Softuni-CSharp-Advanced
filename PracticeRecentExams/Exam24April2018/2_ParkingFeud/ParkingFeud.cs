using System;
using System.Linq;

namespace _2_ParkingFeud
{
    class ParkingFeud
    {
        static int cols = 0;
        static int rows = 0;
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = size[0];
            cols = size[1];

            int entrance = int.Parse(Console.ReadLine());
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string samSpot = input[entrance - 1];
                int currentSamSteps = GetSteps(entrance, samSpot);
                ;
            }


        }

        private static int GetSteps(int inputRow, string samSpot)
        {
            int targetRow = int.Parse(samSpot.Substring(1));
            int targetCol = samSpot[0] - 'A' + 1;
            int currentSteps = 0;
            bool isRight = true;
            while (targetRow != inputRow && targetRow - 1 != inputRow)
            {
                currentSteps += cols + 1;
            }
            if (inputRow > targetRow)
            {
                inputRow--;
            }
            if (inputRow < targetRow)
            {
                inputRow++;
            }
            isRight = !isRight;
            if (isRight)
            {
                currentSteps += targetCol;
            }
            else
            {
                currentSteps += cols - targetCol + 1;
            }
            return currentSteps;
        }
    }
}
