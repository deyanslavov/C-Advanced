using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var lostElements = new List<int>();

            while (input.Count != 1)
            {

                for (int i = 0; i < input.Count; i++)
                {
                    if (input.Count == 2 && i == input.Count - 1 || input.Count == 1 || Math.Abs(lostElements.Count - input.Count) == 1)
                    {
                        continue;
                    }
                    int diff = 0;
                    int attacker = i;
                    int target = input[i];
                    if (lostElements.Contains(i))
                    {
                        continue;
                    }
                    if (target >= input.Count)
                    {
                        target %= input.Count;
                    }
                    diff = Math.Abs(attacker - target);
                    if (attacker == target)
                    {
                        lostElements.Add(attacker);
                        Console.WriteLine($"{attacker} performed harakiri");
                    }
                    else
                    {
                        if (diff % 2 == 0)
                        {
                            lostElements.Add(target);
                            Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        }
                        else
                        {
                            lostElements.Add(attacker);
                            Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        }
                    }
                }
                lostElements = lostElements.Distinct().OrderBy(a => a).ToList();
                for (int i = lostElements.Count - 1; i >= 0; i--)
                {
                    input.RemoveAt(lostElements[i]);
                }
                lostElements.Clear();
            }

        }
    }
}
