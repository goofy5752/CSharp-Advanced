﻿using AnimalCentre.Models.Contracts;
using System;
using System.Text;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                ProcedureHistory.Add(animal);
                animal.Happiness -= 3;
                animal.Energy += 10;
                animal.ProcedureTime -= procedureTime;
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