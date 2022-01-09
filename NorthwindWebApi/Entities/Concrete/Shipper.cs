using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Shipper : IEntity
    {
        #region Primary Key
        public int ShipperId { get; set; }
        #endregion

        #region Columns
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        #endregion

        #region Foreign Key
        public ICollection<Order> Orders { get; set; }
        #endregion
    }
}
