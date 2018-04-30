namespace _06.Reverse_And_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int num = int.Parse(Console.ReadLine());

            Func<int, bool> isDevisibleByN = n => n % num == 0;
            List<int> output = FindNums(input, isDevisibleByN);

            output.Reverse();
            Console.WriteLine(String.Join(" ",output));
        }

        private static List<int> FindNums(List<int> input, Func<int, bool> isDevisibleByN)
        {
            List<int> newList = new List<int>();

            foreach (var num in input)
            {
                if (isDevisibleByN(num) == false)
                {
                    newList.Add(num);
                }
            }

            return newList;
        }
    }
}
