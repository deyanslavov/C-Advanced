namespace _1.Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];
            var sum = 0;

            for (int row = 0; row < sizes[0]; row++)
            {
                var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = input[col];
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
