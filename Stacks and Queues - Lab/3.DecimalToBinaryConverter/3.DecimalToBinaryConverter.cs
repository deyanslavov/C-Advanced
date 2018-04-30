namespace _3.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var converter = new Stack<int>();
            var reminder = 0;
            var num = int.Parse(Console.ReadLine());

            
            if (num == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                while (num > 0)
                {
                    reminder = num % 2;
                    num /= 2;
                    converter.Push(reminder);
                }
                Console.WriteLine(string.Join("", converter));
            }
        }
    }
}
