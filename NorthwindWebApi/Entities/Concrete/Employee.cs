using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        #region Primary Key
        public int EmployeeId { get; set; }

        #endregion

        #region Columns
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public int ReportsTo { get; set; }

        #endregion

        #region Foreign Key
        public ICollection<Order> Orders { get; set; }

        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }

        #endregion
    }
}
