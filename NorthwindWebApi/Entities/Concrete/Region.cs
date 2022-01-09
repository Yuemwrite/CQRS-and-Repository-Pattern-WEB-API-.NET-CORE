using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Region : IEntity
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; set; }

        
    }
}
