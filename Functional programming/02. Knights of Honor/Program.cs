namespace _02.Knights_of_Honor
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Action<string> Print = x => Console.WriteLine($"Sir {x}");
            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x => Print(x));
        }
    }
}
