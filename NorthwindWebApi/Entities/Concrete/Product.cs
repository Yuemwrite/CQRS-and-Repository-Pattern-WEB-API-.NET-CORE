using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        #region PrimaryKey
        public int ProductId { get; set; }
        #endregion

        #region Columns
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }

        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        #endregion

        #region Foreign Key
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
#endregion
    }
}
