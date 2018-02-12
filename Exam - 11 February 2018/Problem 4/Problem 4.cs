using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, string>>();

            int infoIndex = int.Parse(Console.ReadLine());

            string line;
            while ((line = Console.ReadLine()) != "end transmissions")
            {
                var nameToken = line.Split(new[] { '=', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                string name = nameToken[0];
                if (!data.ContainsKey(name))
                {
                    data.Add(name, new Dictionary<string, string>());
                }
                string[] otherData = nameToken.Skip(1).ToArray();
                for (int i = 0; i < otherData.Length; i+=2)
                {
                    var key = otherData[i];
                    var value = otherData[i+1];
                    if (!data[name].ContainsKey(key))
                    {
                        data[name].Add(key, value);
                    }
                    else
                    {
                        data[name][key] = value;
                    }
                }
            }
            var killCommand = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Info on {killCommand[1]}:");
            var sum = 0;
            foreach (var kvp in data[killCommand[1]].OrderBy(a => a.Key))
            {
                sum += kvp.Key.Length + kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"Info index: {sum}");
            if (sum >= infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoIndex - sum} more info.");
            }
        }
    }
}
