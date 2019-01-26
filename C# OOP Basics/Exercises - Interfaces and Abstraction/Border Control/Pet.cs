using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : ISociety
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public override string ToString()
        {
            return this.Birthday;
        }
    }
}