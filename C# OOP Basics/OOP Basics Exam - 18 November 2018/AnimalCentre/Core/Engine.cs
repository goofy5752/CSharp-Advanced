using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre
{
    public class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine().Split();
            var animalCentre = new AnimalCentre();
            List<IAnimal> createdAnimals = new List<IAnimal>();
            List<IAnimal> adoptedAnimals = new List<IAnimal>();
            while (input[0] != "End")
            {
                try
                {
                    switch (input[0])
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(animalCentre.RegisterAnimal(input[1], input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5])));
                            if (input[1] == "Lion")
                            {
                                createdAnimals.Add(new Lion(input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5])));
                            }
                            else if (input[1] == "Cat")
                            {
                                createdAnimals.Add(new Cat(input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5])));
                            }
                            else if (input[1] == "Dog")
                            {
                                createdAnimals.Add(new Dog(input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5])));
                            }
                            else
                            {
                                createdAnimals.Add(new Pig(input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5])));
                            }
                            break;
                        case "Chip":
                            Console.WriteLine(animalCentre.Chip(input[1], int.Parse(input[2])));
                            break;
                        case "Vaccinate":
                            Console.WriteLine(animalCentre.Vaccinate(input[1], int.Parse(input[2])));
                            break;
                        case "Fitness":
                            Console.WriteLine(animalCentre.Fitness(input[1], int.Parse(input[2])));
                            break;
                        case "Play":
                            Console.WriteLine(animalCentre.Play(input[1], int.Parse(input[2])));
                            break;
                        case "DentalCare":
                            Console.WriteLine(animalCentre.DentalCare(input[1], int.Parse(input[2])));
                            break;
                        case "NailTrim":
                            Console.WriteLine(animalCentre.NailTrim(input[1], int.Parse(input[2])));
                            break;
                        case "Adopt":
                            if (createdAnimals.Any(x => x.Name == input[1]))
                            {
                                var adoptedAnimal = createdAnimals.First(x => x.Name == input[1]);
                                adoptedAnimal.Owner = input[2];
                                adoptedAnimals.Add(adoptedAnimal);
                                Console.WriteLine(animalCentre.Adopt(input[1], input[2]));
                            }
                            else
                            {
                                Console.WriteLine(animalCentre.Adopt(input[1], input[2]));
                            }

                            break;
                        case "History":
                            Console.WriteLine(animalCentre.History(input[1]));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }

                input = Console.ReadLine().Split();
            }
            var dict = new SortedDictionary<string, List<string>>();
            foreach (var item in adoptedAnimals.OrderByDescending(x => x.Name))
            {
                if (!dict.ContainsKey(item.Owner))
                {
                    dict.Add(item.Owner, new List<string>());
                }
                dict[item.Owner].Add(item.Name);
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"--Owner: {item.Key}");
                Console.Write($"    - Adopted animals: {string.Join(" ", item.Value.OrderBy(x => x))}");
                Console.WriteLine();
            }
        }
    }
}