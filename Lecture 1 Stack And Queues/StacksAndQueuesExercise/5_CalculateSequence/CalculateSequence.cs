using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_CalculateSequence
{
    class CalculateSequence
    {
        static void Main(string[] args)
        {
            Queue<decimal> sequence = new Queue<decimal>();
            Queue<decimal> result = new Queue<decimal>();
            decimal currenElement = decimal.Parse(Console.ReadLine());

            result.Enqueue(currenElement);
            while (result.Count < 50)
            {
                sequence.Enqueue(currenElement + 1);
                sequence.Enqueue(2 * currenElement + 1);
                sequence.Enqueue(currenElement + 2);
                currenElement = sequence.Dequeue();
                result.Enqueue(currenElement);
            }
            Console.WriteLine(string.Join(" ", result.ToArray()));
        }
    }
}
