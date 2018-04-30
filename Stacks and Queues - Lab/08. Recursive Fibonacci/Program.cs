namespace _08.Recursive_Fibonacci
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(getFibonacci(n)); 
        }

        private static int getFibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return getFibonacci(n - 1) + getFibonacci(n - 2);
            }
        }
    }
}
