﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot
    {
        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }
    }
}
