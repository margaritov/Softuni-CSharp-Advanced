using System;
using System.Collections.Generic;

namespace _1_Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;
            while (input != "END")
            {
                if (input == "green")
                {
                    int greenLeft = greenLightSeconds;
                    int freeLeft = freeWindowSeconds;

                    while (greenLeft > 0 && cars.Count > 0)
                    {
                        int nextCarLength = cars.Peek().Length;
                        if (nextCarLength > greenLeft + freeLeft)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{cars.Peek()} was hit at {cars.Peek()[greenLeft + freeLeft]}.");
                            return;
                        }
                        else
                        {
                            if (greenLeft > 0)
                            {
                                greenLeft -= cars.Peek().Length;

                            }
                            cars.Dequeue();
                            carsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
