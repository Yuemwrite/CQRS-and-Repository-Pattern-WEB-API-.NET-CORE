using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        #region PrimaryKey
        public string CustomerId { get; set; }
        #endregion 

        #region Columns
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string Region { get; set; }

        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        #endregion

        #region Foreign Key
        public ICollection<Order> Orders { get; set; }
        #endregion

    }
}
