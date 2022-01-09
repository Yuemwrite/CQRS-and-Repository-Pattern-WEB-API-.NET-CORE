using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class EmployeeTerritoriesDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}
