namespace _03.Custom_Min_Function
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Func<int[], int> Jucie = x => x.Min();
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Console.WriteLine(Jucie(input));
        }
    }
}
