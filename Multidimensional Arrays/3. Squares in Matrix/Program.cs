namespace _3.Squares_in_Matrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var squareCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col + 1] && matrix[row, col] == matrix[row + 1, col])
                    {
                        squareCount++;
                    }
                }
            }
            Console.WriteLine(squareCount);
        }
    }
}
