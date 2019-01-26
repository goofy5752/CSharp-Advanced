using AnimalCentre.Models.Entities.Animals;
using System.Collections;
using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        string History();
        void DoService(IAnimal animal, int procedureTime);
    }
}
