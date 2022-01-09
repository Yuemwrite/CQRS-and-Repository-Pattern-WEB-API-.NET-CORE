using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        #region Primary Key
        public int CategoryId { get; set; }
        #endregion

        #region Columns
        public string CategoryName { get; set; }

        public string Description { get; set; }

        #endregion

        #region Foreign Key
        public ICollection<Product> Products { get; set; }
        #endregion

    }
}