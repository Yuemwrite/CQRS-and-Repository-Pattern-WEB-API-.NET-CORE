using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class OrderWithShipperDto
    {
        public int OrderId { get; set;}
        public int ShipperId { get; set;}
        public string CompanyName { get; set;}
        public string Phone { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCountry { get; set; }
    }
}
