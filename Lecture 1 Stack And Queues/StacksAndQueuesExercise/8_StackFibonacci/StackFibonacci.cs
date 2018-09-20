using System;
using System.Collections;
using System.Collections.Generic;

namespace _8_StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<decimal> fibo = new Stack<decimal>(count);
            fibo.Push(0);

            fibo.Push(1);
            count -= 1;
            while (count > 0)
            {
                decimal a = fibo.Pop();
                decimal b = fibo.Peek();
                fibo.Push(a);
                fibo.Push(a + b);
                count--;
            }
            Console.WriteLine(fibo.Peek());
        }
    }
}
