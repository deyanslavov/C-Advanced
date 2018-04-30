namespace _9.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<List<int>> matrix = new List<List<int>>();

            FillMatrix(matrix,dimensions[0], dimensions[1]);
            var commands = Console.ReadLine();

            while (commands != "Nuke it from orbit")
            {
                var tokens = commands.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = tokens[0];
                int col = tokens[1];
                int radius = tokens[2];

                Crossfire(matrix, row, col, radius);
                MoveMatrix(matrix);
                commands = Console.ReadLine();
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void Crossfire(List<List<int>> matrix, int row, int col, int radius)
        {
            int targetRow = row;
            int targetCol = col;
            int radiuss = radius;
            // update horizontal cells
            if (targetRow >= 0 && targetRow < matrix.Count)
            {
                for (int coll = Math.Max(0, targetCol - radiuss); coll <= Math.Min(targetCol + radiuss, matrix[targetRow].Count - 1); coll++)
                {
                    matrix[targetRow][coll] = 0;
                }
            }
            // update vertical cells
            if (targetCol >= 0 && targetCol < matrix[0].Count)
            {
                for (int roww = Math.Max(0, targetRow - radiuss); roww <= Math.Min(targetRow + radiuss, matrix.Count - 1); roww++)
                {
                    if (targetCol < matrix[roww].Count)
                    {
                        matrix[roww][targetCol] = 0;
                    }
                }
            }
        }

        private static void MoveMatrix(List<List<int>> matrix)
        {
            for (int r = 0; r < matrix.Count; r++)
            {
                var currentRowValues = matrix[r].Where(n => n > 0).ToList();
                if (currentRowValues.Count > 0)
                {
                    currentRowValues.RemoveAll(n => n == 0);
                    matrix[r] = currentRowValues;
                }
                else
                {
                    matrix.RemoveAt(r);
                    r--;
                }
            }
        }

        private static void FillMatrix(List<List<int>> matrix, int lengthRow, int lengthCol)
        {
            int cellValue = 1;
            for (int i = 0; i < lengthRow; i++)
            {
                matrix.Add(new List<int>());
                for (int j = 0; j < lengthCol; j++)
                {
                    matrix[i].Add(cellValue);
                    cellValue++;
                }
            }
        }
    }
}
