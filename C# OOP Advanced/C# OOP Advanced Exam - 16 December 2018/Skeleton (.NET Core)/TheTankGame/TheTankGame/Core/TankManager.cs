namespace TheTankGame.Core
{
    using Contracts;
    using Entities.Parts.Contracts;
    using Entities.Vehicles.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Factories.Contracts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Factories.Contracts;
    using Utils;

    public class TankManager : IManager
    {
        private readonly IDictionary<string, IVehicle> vehicles;
        private readonly IDictionary<string, IPart> parts;
        private readonly IList<string> defeatedVehicles;
        private readonly IBattleOperator battleOperator;
        private readonly IAssembler assembler;
        //hmmm
        private readonly IVehicleFactory vehicleFactory;
        private readonly IPartFactory partFactory;

        public TankManager(IBattleOperator battleOperator)
        {
            this.battleOperator = battleOperator;

            this.vehicles = new Dictionary<string, IVehicle>();
            this.parts = new Dictionary<string, IPart>();
            this.defeatedVehicles = new List<string>();
            this.vehicleFactory = new VehicleFactory();
            this.partFactory = new PartFactory();
            this.assembler = new VehicleAssembler();
        }

        public string AddVehicle(IList<string> arguments)
        {
            string vehicleType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            IVehicle vehicle = vehicleFactory.CreateVehicle(vehicleType, model, weight, price, attack, defense, hitPoints);

            this.vehicles.Add(vehicle.Model, vehicle);

            return string.Format(
                GlobalConstants.VehicleSuccessMessage,
                vehicleType,
                vehicle.Model);
        }

        public string AddPart(IList<string> arguments)
        {
            string vehicleModel = arguments[0];
            string partType = arguments[1];
            string model = arguments[2];
            double weight = double.Parse(arguments[3]);
            decimal price = decimal.Parse(arguments[4]);
            int additionalParameter = int.Parse(arguments[5]);

            IPart part = partFactory.CreatePart(partType, model, weight, price, additionalParameter);

            parts.Add(part.Model, part);

            if (part.GetType().Name == "ArsenalPart")
            {
                vehicles[vehicleModel].AddArsenalPart(part);
            }
            else if (part.GetType().Name == "ShellPart")
            {
                vehicles[vehicleModel].AddShellPart(part);
            }
            else
            {
                vehicles[vehicleModel].AddEndurancePart(part);
            }
            return string.Format(
                GlobalConstants.PartSuccessMessage,
                partType,
                part.Model,
                vehicleModel);
        }

        public string Inspect(IList<string> arguments)
        {
            string model = arguments[0];
            string result = string.Empty;

            if (vehicles.ContainsKey(model))
            {
                result = vehicles[model].ToString();
            }
            else
            {
                result = parts[model].ToString();
            }
            return result;
        }

        public string Battle(IList<string> arguments)
        {
            string attackerVehicleModel = arguments[0];
            string targetVehicleModel = arguments[1];

            string winnerVehicleModel = this.battleOperator.Battle(this.vehicles[attackerVehicleModel], this.vehicles[targetVehicleModel]);

            if (winnerVehicleModel == attackerVehicleModel)
            {
                defeatedVehicles.Add(targetVehicleModel);
                vehicles.Remove(targetVehicleModel);
            }
            else
            {
                defeatedVehicles.Add(attackerVehicleModel);
                vehicles.Remove(attackerVehicleModel);
            }
            return string.Format(
                GlobalConstants.BattleSuccessMessage,
                attackerVehicleModel,
                targetVehicleModel,
                winnerVehicleModel);
        }

        public string Terminate(IList<string> arguments)
        {

            StringBuilder finalResult = new StringBuilder();

            finalResult.Append("Remaining Vehicles: ");

            if (this.vehicles.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ", this.vehicles.Keys));
            }
            else
            {
                finalResult.AppendLine("None");
            }

            finalResult.Append("Defeated Vehicles: ");

            if (this.defeatedVehicles.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ", this.defeatedVehicles));
            }
            else
            {
                finalResult
                    .AppendLine("None");
            }

            finalResult
                .Append("Currently Used Parts: ")
                .Append(this.parts.Count);

            return finalResult.ToString();
        }
    }
}