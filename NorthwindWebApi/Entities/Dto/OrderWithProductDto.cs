using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class OrderWithProductDto
    {
        public int OrderId { get; set; }
        public string ShipName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
