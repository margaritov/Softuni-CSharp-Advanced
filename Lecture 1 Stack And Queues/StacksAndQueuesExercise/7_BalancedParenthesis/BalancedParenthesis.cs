using System;
using System.Collections;
using System.Collections.Generic;

namespace _7_BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            var inputData = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;

            foreach (char ch in inputData)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')

                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    switch (ch)
                    {
                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                            }
                            break;
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                            }
                            break;
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            if (isBalanced == true && stack.Count > 0)
            {
                isBalanced = false;
            }
            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
