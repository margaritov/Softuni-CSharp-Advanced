using System;
using System.Collections.Generic;

namespace _3_TicketTrouble
{
    class TicketTrouble
    {
        static void Main(string[] args)
        {
            string text = @"BUL SF
1d2ajsd/.{1d9823{BUL SF}10eu2{A11}12das}2fsdf[a2d{BUL SF}12e0dd1rrwg{A11}af/zc,s]d1d0429{d12dasd[LUB SF]123asdAS[A15]fsdf}21ijp3diasd{[BUL SF][B11]}112edasd";

            Console.WriteLine(test);

            List<string> tickets = new List<string>();

            tickets = Extract(text);
        }

        private static List<string> Extract(string text)
        {
            Stack<int> indexes = new Stack<int>();
            int index = 0;
            while (1)
            {
                if (text[index]=='{')
                {
                    indexes.Push(index);
                }

                index++;
            }
        }
    }
}
