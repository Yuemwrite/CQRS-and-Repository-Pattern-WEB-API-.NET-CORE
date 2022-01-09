using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        #region Primary Key
        public int OrderId { get; set; }
        #endregion

        #region Columns
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        #endregion

        #region ForeignKey
        
        public int ShipperId { get; set; }

        public int EmployeeId { get; set; }

        public string CustomerId { get; set; }
        public Employee Employee { get; set; }


        public Customer Customer { get; set; }

        public Shipper Shipper { get; set; }

        public OrderDetail OrderDetail { get; set; }
        #endregion

    }
}
