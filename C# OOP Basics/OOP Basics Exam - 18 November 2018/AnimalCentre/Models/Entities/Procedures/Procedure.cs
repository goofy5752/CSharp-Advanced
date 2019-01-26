using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        protected List<IAnimal> ProcedureHistory
        {
            get { return procedureHistory; }
            set { procedureHistory = value; }
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public abstract string History();
    }
}