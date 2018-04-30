namespace _13.TriFunction
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
           
            Func<char, int> SumAllChars = a => a;
            Func<int, bool> CheckIfSumIsGreater = a => a >= n;
            var sum = 0;

            foreach (var name in names)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    sum += SumAllChars(name[i]);
                }
                if (CheckIfSumIsGreater(sum))
                {
                    Console.WriteLine(name);
                    break;
                }            
                sum = 0;
            }
        }
    }
}
