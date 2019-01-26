using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoaster
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var employ = new Employee();
            var dict = employ.dict;
            var finalDepartment = employ.finalDepartment;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 5)
                {
                    foreach (var item in input[4].ToCharArray())
                    {
                        if (char.IsDigit(item))
                        {
                            Employee employee = new Employee(input[0], double.Parse(input[1]), "n/a", int.Parse(input[4]));
                            
                            if (!dict.ContainsKey(input[3]))
                            {
                                dict.Add(input[3], new List<Employee>());
                            }
                            dict[input[3]].Add(employee);
                            if (!finalDepartment.ContainsKey(input[3]))
                            {
                                finalDepartment.Add(input[3], double.Parse(input[1]));
                            }
                            else
                            {
                                finalDepartment[input[3]] += double.Parse(input[1]);
                            }
                            break;
                        }
                        else
                        {
                            Employee employee = new Employee(input[0], double.Parse(input[1]), input[4], -1);
                            if (!dict.ContainsKey(input[3]))
                            {
                                dict.Add(input[3], new List<Employee>());
                            }
                            dict[input[3]].Add(employee);
                            if (!finalDepartment.ContainsKey(input[3]))
                            {
                                finalDepartment.Add(input[3], double.Parse(input[1]));
                            }
                            else
                            {
                                finalDepartment[input[3]] += double.Parse(input[1]);
                            }
                            break;
                        }
                    }
                }
                else if (input.Length == 4)
                {
                    Employee employee = new Employee(input[0], double.Parse(input[1]), "n/a", -1);
                    if (!dict.ContainsKey(input[3]))
                    {
                        dict.Add(input[3], new List<Employee>());
                    }
                    dict[input[3]].Add(employee);
                    if (!finalDepartment.ContainsKey(input[3]))
                    {
                        finalDepartment.Add(input[3], double.Parse(input[1]));
                    }
                    else
                    {
                        finalDepartment[input[3]] += double.Parse(input[1]);
                    }
                }
                else
                {
                    Employee employee = new Employee(input[0], double.Parse(input[1]), input[4], int.Parse(input[5]));
                    if (!dict.ContainsKey(input[3]))
                    {
                        dict.Add(input[3], new List<Employee>());
                    }
                    dict[input[3]].Add(employee);
                    if (!finalDepartment.ContainsKey(input[3]))
                    {
                        finalDepartment.Add(input[3], double.Parse(input[1]));
                    }
                    else
                    {
                        finalDepartment[input[3]] += double.Parse(input[1]);
                    }
                }
            }
            string finalDepartmentt = "";
            foreach (var item in finalDepartment.OrderByDescending(x => x.Value))
            {
                finalDepartmentt = item.Key;
                break;
            }
            Console.WriteLine($"Highest Average Salary: {finalDepartmentt}");
            foreach (var item in dict[finalDepartmentt].OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{item.Name} {item.Salary:F2} {item.Email} {item.Age}");
            }
            
        }
    }
}