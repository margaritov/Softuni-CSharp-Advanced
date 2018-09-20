using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2_BasicOperations
{
    class BasicOperations
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> numsStack = new Stack<int>();
            int countToPush = inputData[0];
            int countToPop = inputData[1];
            int elementToFind = inputData[2];
            int smallestElement = int.MaxValue;
            bool isFound = false;
            int index = 0;
            while (numsStack.Count() < countToPush)
            {
                numsStack.Push(nums[index++]);
            }

            while (countToPop > 0)
            {
                numsStack.Pop();
                countToPop--;
            }

            string result = "0";

            if (numsStack.Count > 0)
            {
                foreach (var currentElement in numsStack)
                {
                    if (currentElement == elementToFind)
                    {
                        isFound = true;
                    }
                    if (currentElement < smallestElement)
                    {
                        smallestElement = currentElement;
                    }
                }
                if (isFound)
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
