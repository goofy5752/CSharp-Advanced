using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type partTypee = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == partType + "Part");
            var partInstance = (IPart)Activator.CreateInstance(partTypee, model, weight, price, additionalParameter);
            return partInstance;
        }
    }
}
