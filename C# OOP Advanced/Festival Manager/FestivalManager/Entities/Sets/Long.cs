using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        public Long(string name) : base(name)
        {
            this.MaxDuration = TimeSpan.FromMinutes(60);
        }
    }
}
