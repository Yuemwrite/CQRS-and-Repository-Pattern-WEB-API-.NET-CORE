using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class RegionWithTerritoriesDto
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
    }
}
