﻿namespace _6.Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int numberOfCarsThatCanPass = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var q = new Queue<string>();
            int counter = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    if (numberOfCarsThatCanPass > q.Count)
                    {
                        var iterations = q.Count;
                        for (int i = 0; i < iterations; i++)
                        {
                            counter++;
                            Console.WriteLine(q.Dequeue() + " passed!");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < numberOfCarsThatCanPass; i++)
                        {
                            counter++;
                            Console.WriteLine(q.Dequeue() + " passed!");
                        }
                    }
                }
                else
                {
                    q.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(counter + " cars passed the crossroads.");
        }
    }
}
