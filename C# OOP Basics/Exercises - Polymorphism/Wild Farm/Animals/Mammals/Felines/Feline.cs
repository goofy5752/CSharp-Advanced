using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Felines
{
    public abstract class Feline : Animal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
        {
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = livingRegion;
            this.Breed = breed;
        }

        public string LivingRegion { get; set; }
        public string Breed { get; set; }
    }
}