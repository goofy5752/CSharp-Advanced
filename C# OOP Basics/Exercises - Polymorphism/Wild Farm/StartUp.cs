using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammal;
using WildFarm.Animals.Mammal.Felines;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listOfAnimals = new List<Animal>();
            int counter = 0;
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }
                counter++;
                if (counter == 1)
                {
                    if (input[0] == "Cat")
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        string livingRegion = input[3];
                        string breed = input[4];
                        listOfAnimals.Add(new Cat(name, weight, livingRegion, breed));
                    }
                    else if (input[0] == "Tiger")
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        string livingRegion = input[3];
                        string breed = input[4];
                        listOfAnimals.Add(new Tiger(name, weight, livingRegion, breed));
                    }
                    else if (input[0] == "Dog")
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        string livingRegion = input[3];
                        listOfAnimals.Add(new Dog(name, weight, livingRegion));
                    }
                    else if (input[0] == "Mouse")
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        string livingRegion = input[3];
                        listOfAnimals.Add(new Mouse(name, weight, livingRegion));
                    }
                    else if (input[0] == "Owl")
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        double wingSize = double.Parse(input[3]);
                        listOfAnimals.Add(new Owl(name, weight, wingSize));
                    }
                    else
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        double wingSize = double.Parse(input[3]);
                        listOfAnimals.Add(new Hen(name, weight, wingSize));
                    }
                }
                else
                {
                    var last = listOfAnimals.Last();
                    last.Eat(input[0], int.Parse(input[1]));
                    counter = 0;
                }
            }
            foreach (var item in listOfAnimals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}