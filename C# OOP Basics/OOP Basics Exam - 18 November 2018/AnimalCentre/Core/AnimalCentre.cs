using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities;
using AnimalCentre.Models.Entities.Animals;
using AnimalCentre.Models.Entities.Procedures;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre
{
    public class AnimalCentre
    {
        Hotel hotel = new Hotel();
        IProcedure chip = new Chip();
        IProcedure dentalCare = new DentalCare();
        IProcedure fitness = new Fitness();
        IProcedure nailTrim = new NailTrim();
        IProcedure play = new Play();
        IProcedure vaccinate = new Vaccinate();
        HashSet<IAnimal> animals = new HashSet<IAnimal>();


        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Lion":
                    var lion = new Lion(name, energy, happiness, procedureTime);
                    hotel.Accommodate(lion);
                    animals.Add(lion);
                    break;
                case "Cat":
                    var cat = new Cat(name, energy, happiness, procedureTime);
                    hotel.Accommodate(cat);
                    animals.Add(cat);
                    break;
                case "Dog":
                    var dog = new Dog(name, energy, happiness, procedureTime);
                    hotel.Accommodate(dog);
                    animals.Add(dog);
                    break;
                case "Pig":
                    var pig = new Pig(name, energy, happiness, procedureTime);
                    hotel.Accommodate(pig);
                    animals.Add(pig);
                    break;
            }
            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = animals.First(x => x.Name == name);
            chip.DoService(animal, procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = animals.First(x => x.Name == name);
            vaccinate.DoService(animal, procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = animals.First(x => x.Name == name);
            fitness.DoService(animal, procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animal = animals.First(x => x.Name == name);
            play.DoService(animal, procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = animals.First(x => x.Name == name);
            dentalCare.DoService(animal, procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = animals.First(x => x.Name == name);
            nailTrim.DoService(animal, procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            bool isChipped = false;
            if (animals.Any(x => x.Name == animalName))
            {
                var animal = animals.First(x => x.Name == animalName);
                if (animal.IsChipped == true)
                {
                    isChipped = true;
                }
                else
                {
                    isChipped = false;
                }
            }
            else
            {
                hotel.Adopt(animalName, owner);
            }
            if (isChipped)
            {
                hotel.Adopt(animalName, owner);
                return $"{owner} adopted animal with chip";
            }
            else
            {
                hotel.Adopt(animalName, owner);
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            switch (type)
            {
                case "Chip":
                    return chip.History();
                case "DentalCare":
                    return dentalCare.History();
                case "Fitness":
                    return fitness.History();
                case "Play":
                    return play.History();
                case "Vaccinate":
                    return vaccinate.History();                
                default: return nailTrim.History();
            }
        }
    }
}