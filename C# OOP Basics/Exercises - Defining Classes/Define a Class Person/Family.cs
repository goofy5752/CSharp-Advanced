using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> people = new List<Person>();

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public string GetOldestMember()
        {
            foreach (var item in people.OrderBy(x => x.Name).Where(x => x.Age > 30))
            {
                Console.WriteLine(item.Name + " - " + item.Age);
            }
            return "";
        }
    }
}