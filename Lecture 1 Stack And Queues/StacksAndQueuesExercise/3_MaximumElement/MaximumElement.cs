using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace _3_MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            Stack<int> data = new Stack<int>();
            Stack<int> maximum = new Stack<int>();
            int queriesCount = int.Parse(Console.ReadLine());
            while (queriesCount-- > 0)
            {

                int[] command = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                switch (command[0])
                {
                    case 1:
                        data.Push(command[1]);
                        if (maximum.Count() == 0 || command[1] > maximum.Peek())
                        {
                            maximum.Push(command[1]);
                        }
                        break;
                    case 2:
                        int lastElement = data.Pop();
                        if (lastElement == maximum.Peek())
                        {
                            maximum.Pop();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maximum.Peek());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
