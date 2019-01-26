using System.Collections.Generic;

namespace CompanyRoaster
{
    public class Employee
    {
        public Dictionary<string, List<Employee>> dict = new Dictionary<string, List<Employee>>();
        public Dictionary<string, double> finalDepartment = new Dictionary<string, double>();
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary, string email, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
            this.Salary = salary;
        }
        public Employee()
        {

        }
    }
}