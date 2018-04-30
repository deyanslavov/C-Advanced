namespace _3.Group_Numbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] zero = input.Where(a => Math.Abs(a) % 3 == 0).ToArray();
            int[] one = input.Where(a => Math.Abs(a) % 3 == 1).ToArray();
            int[] two = input.Where(a => Math.Abs(a) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));
        }
    }
}
