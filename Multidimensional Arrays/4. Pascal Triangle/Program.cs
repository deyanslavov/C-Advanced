﻿namespace _4.Pascal_Triangle
{
    using System;

    class Program
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];

            for (long i = 0; i < n; i++)
            {
                triangle[i] = new long[i + 1];
                triangle[i][0] = 1;
                triangle[i][triangle[i].Length - 1] = 1;

                for (long j = 1; j < triangle[i].Length - 1; j++)
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];

                }
            }
            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
