using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;

        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (Animals.Count == 10)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (Animals.Any(x => x.Key == animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            else
            {
                animals.Add(animal.Name, animal);
            }
        }

        public void Adopt(string animalName, string owner)
        {
            if (animals.Any(x => x.Key == animalName))
            {
                var adoptedAnimal = Animals.First(x => x.Key == animalName);
                adoptedAnimal.Value.Owner = owner;
                adoptedAnimal.Value.IsAdopt = true;
                animals.Remove(adoptedAnimal.Key);
            }
            else
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }
    }
}