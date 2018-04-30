namespace _2.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());
            
            while (stack.Count > 1)
            {
                var firstN = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondN = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((firstN + secondN).ToString());
                }
                else
                {
                    stack.Push((firstN - secondN).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
