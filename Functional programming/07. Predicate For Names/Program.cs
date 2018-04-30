namespace _07.Predicate_For_Names
{
    using System;

    class Program
    {
        static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            var strings = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> condition = n => n.Length <= length;

            foreach (var word in strings)
            {
                if (condition(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
