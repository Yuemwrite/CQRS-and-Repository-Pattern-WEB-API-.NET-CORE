using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class CustomerWithProductDto
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
