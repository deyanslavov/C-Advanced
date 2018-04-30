namespace P02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<char, int> parkingCols = new Dictionary<char, int>
        {
            { 'A', 1},
            { 'B', 2},
            { 'C', 3},
            { 'D', 4},
            { 'E', 5},
            { 'F', 6},
            { 'G', 7},
            { 'H', 8},
            { 'I', 9},
            { 'J', 10},
            { 'K', 11},
        };

        static void Main()
        {
            int[] parkingRowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = parkingRowsAndCols[0] + parkingRowsAndCols[0] - 1;
            int cols = parkingRowsAndCols[1] + 2;
            int[,] parking = new int[rows, cols];

            int entrance = int.Parse(Console.ReadLine());

            string samSpot = string.Empty;
            int distanceTravelled = 0;
            bool notParked = true;

            while (notParked)
            {
                string[] spots = Console.ReadLine().Split();
                samSpot = spots[entrance - 1];

                int givenRow = int.Parse(samSpot.Substring(1, samSpot.Length - 1));
                int givenCol = parkingCols[samSpot[0]];

                bool conflict = spots.Count(s => s == samSpot) > 1;
                if (conflict)
                {
                    int entranceConflict = FindConflictEntrance(spots, samSpot, entrance);
                    int currentDistance = CalculateDistance(parking, givenRow, givenRow, entrance);
                    if (currentDistance <= CalculateDistance(parking, givenRow, givenRow, entranceConflict))
                    {
                        distanceTravelled += currentDistance;
                        notParked = false;
                    }
                    else
                    {
                        distanceTravelled += currentDistance * 2;
                    }
                }
                else
                {
                    if (givenCol == 1 && givenRow == 1)
                    {
                        distanceTravelled += 1;
                    }
                    else
                    {
                        distanceTravelled += CalculateDistance(parking, givenRow, givenCol, entrance);
                    }
                    notParked = false;
                }
            }
            Console.WriteLine($"Parked successfully at {samSpot}.\nTotal Distance Passed: {distanceTravelled}");
        }

        private static int FindConflictEntrance(string[] spots, string samSpot, int entrance)
        {
            int index = int.MinValue;

            for (int i = 0; i < spots.Length; i++)
            {
                if (spots[i] == samSpot && i != entrance - 1)
                {
                    index = i + 1;
                    break;
                }
            }
            return index;
        }
        private static int CalculateDistance(int[,] parking, int row, int col, int entrance)
        {
            int startingPoint = (entrance * 2) - 1;
            int result = 0;
            for (int i = 0; i <= row/2; i++)
            {
                if (i != row/2)
                {
                    result += parking.GetLength(1) - 1;
                }
                if (i % 2 == 0 && i == row/2)
                {
                    result += col;
                }
                else if (i % 2 == 1 && i == row / 2)
                {
                    result += parking.GetLength(1) - (parking.GetLength(1) - col) - 1;
                }
            }
            result += Math.Abs(row - startingPoint);
            return result;
        }
    }
}
