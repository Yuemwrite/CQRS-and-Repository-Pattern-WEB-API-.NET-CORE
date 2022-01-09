using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class CustomerOrderEmployeeProductCategorySupplierDto
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public int OrderId { get; set; }
        public string ShipName { get; set; }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public int SupplierId { get; set; }

 

    }
}
