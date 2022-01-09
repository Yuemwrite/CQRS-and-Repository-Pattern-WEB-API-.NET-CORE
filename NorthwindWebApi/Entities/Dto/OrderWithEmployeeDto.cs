using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class OrderWithEmployeeDto
    {
        public int OrderId { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
