using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Territory : IEntity
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }

        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
