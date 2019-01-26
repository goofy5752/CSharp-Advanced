using System;
using System.Collections.Generic;
using System.Text;

namespace FerrariProj
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string name)
        {
            this.Name = name;
        }

        public string Model => "488-Spider";

        public string Name { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{Model}/{Brakes()}/{GasPedal()}/{Name}";
        }
    }
}