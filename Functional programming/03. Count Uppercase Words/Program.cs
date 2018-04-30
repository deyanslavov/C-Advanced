namespace _03.Count_Uppercase_Words
{
    using System;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> isUppercaseWord = n => char.IsUpper(n[0]);

            foreach (var word in input)
            {
                if (isUppercaseWord(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
