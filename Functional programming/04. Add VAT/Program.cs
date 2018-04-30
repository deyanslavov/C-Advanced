namespace _04.Add_VAT
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Func<double,double> vat = n => n * 1.2;

            Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(vat)
                .ToList()
                .ForEach(m => Console.WriteLine($"{m:f2}"));
        }
    }
}
