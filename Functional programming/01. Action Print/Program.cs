namespace _01.Action_Print
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Action<string> Print = x => Console.WriteLine(x);
            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x => Print(x));
        }
    }
}
