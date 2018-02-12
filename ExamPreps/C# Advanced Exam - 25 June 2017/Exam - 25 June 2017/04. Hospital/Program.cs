using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var hospital = new Dictionary<string, Dictionary<string, List<string>>>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Output")
                {
                    var output = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (output.Length == 1)
                    {
                        foreach (var item in hospital[output[0]])
                        {
                            foreach (var dp in item.Value)
                            {
                                Console.WriteLine(dp);
                            }
                        }
                    }
                    else
                    {
                        int room = 0;
                        if (int.TryParse(output[1], out room))
                        {
                            var printList = new List<string>();
                            foreach (var item in hospital[output[0]].Values)
                            {                                
                                foreach (var p in item)
                                {
                                    printList.Add(p);
                                }
                            }
                            if (printList.Count - 1 < room*3-3)
                            {
                                continue;
                            }
                            var result = new List<string>(3);
                            for (int i = room * 3 - 3; i < room * 3; i++)
                            {
                                result.Add(printList[i]);
                            }
                            result = result.OrderBy(a => a).ToList();
                            foreach (var patient in result)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                        else
                        {
                            var doc = output[0] + " " + output[1];
                            var patientsResult = new List<string>();
                            foreach (var item in hospital)
                            {
                                foreach (var a in item.Value)
                                {
                                    if (a.Key == doc)
                                    {
                                        foreach (var p in a.Value)
                                        {
                                            patientsResult.Add(p);
                                        }
                                    }
                                }
                            }
                            patientsResult = patientsResult.OrderBy(a => a).ToList();
                            foreach (var item in patientsResult)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                }
                else
                {
                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var department = tokens[0];
                    var doctor = tokens[1] + " " + tokens[2];
                    var patient = tokens[3];
                    
                    if (!hospital.ContainsKey(department))
                    {
                        hospital.Add(department, new Dictionary<string, List<string>>());
                    }
                    if(hospital.ContainsKey(department))
                    {
                        if (!hospital[department].ContainsKey(doctor))
                        {
                            hospital[department].Add(doctor, new List<string>());
                        }
                        int sum = 0;
                        foreach (var dep in hospital[department])
                        {                            
                            sum += dep.Value.Count;
                        }
                        if (sum < 60)
                        {
                            hospital[department][doctor].Add(patient);
                        }                       
                    }
                }
            }
        }
    }
}
