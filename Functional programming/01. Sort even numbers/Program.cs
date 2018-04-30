namespace _01.Sort_even_numbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine(String.Join(", ",Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(a => a % 2 == 0).OrderBy(a => a).ToArray()));
        }
    }
}
