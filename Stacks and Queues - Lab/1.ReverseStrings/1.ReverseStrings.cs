namespace _1.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Stack<char> stack = new Stack<char>();

            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
