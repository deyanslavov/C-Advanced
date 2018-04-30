namespace _02.Sum_Numbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine($"{input.Length}\n{input.Sum()}");
        }
    }
}
