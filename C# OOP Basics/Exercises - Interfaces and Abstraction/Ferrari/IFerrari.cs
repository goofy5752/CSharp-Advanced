using System;
using System.Collections.Generic;
using System.Text;

namespace FerrariProj
{
    public interface IFerrari
    {
        string Name { get; }
        string Model { get; }
        string Brakes();
        string GasPedal();
    }
}