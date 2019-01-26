using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped == true)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            if (animal.ProcedureTime >= procedureTime)
            {
                ProcedureHistory.Add(animal);
                animal.ProcedureTime -= procedureTime;
                animal.Happiness -= 5;
                animal.IsChipped = true;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        public override string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var item in ProcedureHistory)
            {
                sb.AppendLine($"{item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}