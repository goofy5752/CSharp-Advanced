using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<string>();
            var openingBrackets = new char[] { ')', '}', ']' };
            for (int i = 0; i < input.Length; i++)
            {
                char currentBracket = input[i];
                if (currentBracket == '(' || currentBracket == '[' || currentBracket == '{')
                {
                    stack.Push(currentBracket.ToString());
                }
                if (stack.Count == 0)
                {
                    break;
                }
                if (openingBrackets.Contains(currentBracket))
                {
                    if (!(stack.Peek().Equals(currentBracket)))
                    {
                        stack.Pop();
                    }
                    if (stack.Count == 0)
                    {
                        break;
                    }
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}