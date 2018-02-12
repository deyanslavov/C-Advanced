using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital_With_Classes
{
    class Doctor
    {
        public string Name { get; set; }
        public List<string> Patients { get; set; }

        public Doctor(string name, List<string> patients)
        {
            this.Name = name;
            this.Patients = patients;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var hospital = new Dictionary<string, List<Doctor>>();
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
                            foreach (var dp in item.Patients)
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
                            foreach (var item in hospital[output[0]])
                            {
                                printList.AddRange(item.Patients);
                            }
                            if (printList.Count - 1 < room * 3 - 3)
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
                            var r = hospital.Values.Where(a => a.Any(b => b.Name == doc));
                            foreach (var item in hospital.Values.Where(a => a.Any( b => b.Name == doc)))
                            {
                                foreach (var wabamama in item)
                                {
                                    patientsResult.AddRange(wabamama.Patients);
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
                    var doc = new Doctor(doctor, new List<string>()) { Name = doctor, Patients = new List<string>() };


                    if (!hospital.ContainsKey(department))
                    {
                        hospital.Add(department, new List<Doctor>());
                    }
                    if (hospital.ContainsKey(department))
                    {
                        int sum = 0;
                        foreach (var dep in hospital[department])
                        {
                            sum += dep.Patients.Count;
                        }
                        if (sum < 60)
                        {
                            if (!hospital[department].Any(a => a.Name == doc.Name))
                            {
                                hospital[department].Add(doc);
                                doc.Patients.Add(patient);
                            }
                            else
                            {
                                doc.Patients.Add(patient);
                            }
                        }
                    }
                }  
            }
        }
    }
}
