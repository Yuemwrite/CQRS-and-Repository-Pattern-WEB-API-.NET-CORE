using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion

        #region Columns
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public short UnitPrice { get; set; }
        public short Quantity { get; set; }

        public decimal Discount { get; set; }

        #endregion

        #region Foreign Key
        public Product Product { get; set; }
        public Order Order { get; set; }
        #endregion
    }
}
