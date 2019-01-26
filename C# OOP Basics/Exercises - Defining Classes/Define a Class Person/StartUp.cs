using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family person = new Family();
            var list = person.people;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person personn = new Person(input[0], int.Parse(input[1]));
                person.AddMember(personn);
            }
            Console.WriteLine(person.GetOldestMember());
        }
    }
}