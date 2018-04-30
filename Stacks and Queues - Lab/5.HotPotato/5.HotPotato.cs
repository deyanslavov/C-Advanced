namespace _5.HotPotato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(input);

            while (queue.Count > 1)
            {
                for (int i = 0; i < n -1; i++)
                {
                    string name = queue.Dequeue();
                    queue.Enqueue(name);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
