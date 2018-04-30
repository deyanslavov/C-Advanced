namespace P03
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"\{.*?\[(?<country>[A-Z]{3}\s[A-Z]{2})\   .*?\[(?<seats>[A-Z][\d]{1,2})\].*?\}|\[.*?\{(?<country>[A-Z]{3}\s[A-Z]{2})\}.*?\{(?<seats>[A-Z]\d{1,2})\}.*?\]";

            string location = Console.ReadLine();
            string input = Console.ReadLine();


            List<string> substrings = GetSubtrings(input);
            List<string> matches = new List<string>();
            List<string> seats = new List<string>();

            foreach (var @string in substrings)
            {
                Match regex = Regex.Match(@string, pattern);
                if (regex.Success && regex.ToString().Contains(location))
                {
                    string seat = regex.Groups["seats"].Value;
                    seats.Add(seat);
                }
            }
            Console.WriteLine($"You are traveling to {location} on seats {seats[0]} and {seats[1]}.");
        }

        private static List<string> GetSubtrings(string input)
        {
            var result = new List<string>();

            int start = int.MinValue;
            int end = int.MinValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    start = i;
                }
                if (input[i] == '}' && start != int.MinValue)
                {
                    end = i;
                }
                if (start != int.MinValue && end != int.MinValue && start < end)
                {
                    string substring = input.Substring(start, end - start+ 1);
                    result.Add(substring);
                    start = int.MinValue;
                    end = int.MinValue;
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    start = i;
                }
                if (input[i] == ']' && start != int.MinValue)
                {
                    end = i;
                }
                if (start != int.MinValue && end != int.MinValue)
                {
                    string substring = input.Substring(start, end - start + 1);
                    result.Add(substring);
                    start = int.MinValue;
                    end = int.MinValue;
                }
            }
            return result;
        }
    }
}
