using AnimalCentre.Models.Contracts;
using System.Text;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                ProcedureHistory.Add(animal);
                animal.Energy -= 8;
                animal.ProcedureTime -= procedureTime;
                animal.IsVaccinated = true;
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