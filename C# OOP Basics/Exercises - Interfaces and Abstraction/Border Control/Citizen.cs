using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ISociety, IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthday { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }

        public override string ToString()
        {
            return this.Birthday;
        }
    }
}