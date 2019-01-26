namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;
    using System;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            if (type == "Short")
            {
                return new Short(name);
            }
            else if (type == "Medium")
            {
                return new Medium(name);
            }
            else
            {
                return new Long(name);
            }
        }
    }




}
