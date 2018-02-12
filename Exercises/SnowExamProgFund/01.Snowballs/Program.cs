using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger currentResult = 0;
            BigInteger bestResult = 0;
            double snow = 0.00;
            double time = 0.00;
            double quality = 0.00;

            for (int i = 0; i < n; i++)
            {
                double snowballSnow = double.Parse(Console.ReadLine());
                double snowballTime = double.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                currentResult = BigInteger.Pow((BigInteger)(snowballSnow / snowballTime), snowballQuality);
                if (currentResult > bestResult)
                {
                    bestResult = currentResult;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {bestResult} ({quality})");
        }
    }
}
