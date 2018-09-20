using System;
using System.Collections.Generic;

namespace _9_SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string text = "";
            for (int i = 0; i < operationsCount; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    // appends to text
                    case "1":
                        stack.Push(text);
                        text += command[1];
                        break;
                    // removes last n characters from text
                    case "2":
                        stack.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(command[1]));
                        break;
                    // returns n-th character from text
                    case "3":
                        Console.WriteLine(text[int.Parse(command[1]) - 1].ToString());
                        break;
                    // undo last append or removes command
                    case "4":
                        text = stack.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}