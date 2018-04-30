namespace _02.Line_Numbers
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            string line;
            int counter = 1;

            using (StreamReader reader = new StreamReader("..//..//text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("..//..//result.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {counter}:{line}");
                        counter++;
                    }
                }
            }
        }
    }
}
