namespace _04.Treasure_Map
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string streetNamePattern = @"([[a-zA-Z]{4})[^a-zA-Z0-9]";
            string streetNumberPattern6 = @"(\d{3}\-\d{6})";
            string streetNumberPattern4 = @"(\d{3}\-\d{4})";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var startIndex = 0;
                var endIndex = 0;
                var listIndexes = new List<int[]>();

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '#' || input[j] == '!')
                    {
                        startIndex = j;
                        if (input[startIndex] == '#')
                        {
                            for (int k = startIndex+1; k < input.Length; k++)
                            {
                                if (input[k] == '!')
                                {
                                    endIndex = k;
                                    break;
                                }
                                else if (input[k] == '#')
                                {
                                    startIndex = k;
                                }
                            }
                        }
                        else
                        {
                            for (int k = startIndex+1; k < input.Length; k++)
                            {
                                if (input[k] == '#')
                                {
                                    endIndex = k;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
