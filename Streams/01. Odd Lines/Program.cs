namespace _01.Odd_Lines
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("..//..//text.txt"))
            {
                int counter = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}
