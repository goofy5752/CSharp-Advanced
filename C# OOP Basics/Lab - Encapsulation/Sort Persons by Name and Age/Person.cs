using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length > 3)
                {
                    firstName = value;
                }
                else
                {
                    //throw new Exception("First name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length > 3)
                {
                    lastName = value;
                }
                else
                {
                    //throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    //throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
            }
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value > 460)
                {
                    salary = value;
                }
                else
                {
                    //throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.salary += this.salary * percentage / 100;
            }
            else
            {
                this.salary += this.salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} gets {this.salary:F2} leva.";
        }
    }
}