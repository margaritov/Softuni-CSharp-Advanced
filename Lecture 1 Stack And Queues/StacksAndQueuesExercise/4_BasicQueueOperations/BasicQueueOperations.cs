using System;
using System.Collections.Generic;
using System.Linq;
namespace _4_BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int elementsToEnque = parameters[0];
            int elementsToDeque = parameters[1];
            int elementToFind = parameters[2];
            int smallestElement = int.MaxValue;
            var data = Console.ReadLine().Split(' ').Select(int.Parse);
            Queue<int> q = new Queue<int>(data);
            while (elementsToDeque > 0)
            {
                var element = q.Dequeue();
                                elementsToDeque--;
            }

            string result = "0";
            if (q.Count > 0)
            {
                foreach (var el in q)
                {
                    if (el < smallestElement)
                    {
                        smallestElement = el;
                    }
                }

                if (q.Contains(elementToFind) == true)
                {
                    result = "true";
                }
                else
                {
                    result = smallestElement.ToString();
                }
            }
            Console.WriteLine(result);
        }
    }
}
