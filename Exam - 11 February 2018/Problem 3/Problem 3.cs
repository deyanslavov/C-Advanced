using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            StringBuilder output = new StringBuilder();
            Regex numbersRegex = new Regex(@"\[[^\d]*(?<nums>\d+)[^\d]*\]|\{[^\d]*(?<nums>\d+)[^\d]*\}");
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                sb.Append(input);
            }
            var matches = numbersRegex.Matches(sb.ToString());
            foreach (Match item in matches)
            {
                var nums = item.Groups["nums"].Value;
                if (nums.Length % 3 == 0)
                {
                    for (int i = 0; i < nums.Length; i+=3)
                    {
                        var number = (char)((int.Parse(nums.Substring(i, 3)) - item.Length));
                        output.Append(Convert.ToChar(number));
                    }
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}
