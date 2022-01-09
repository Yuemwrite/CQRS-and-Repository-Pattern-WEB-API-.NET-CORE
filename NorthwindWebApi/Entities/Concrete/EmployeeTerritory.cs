using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class EmployeeTerritory : IEntity
{
    #region Primary Key
    public int Id { get; set; } /* Bu Id değeri hiç bir yerde kullanılmıyor. Listelemede Primary Key alanının elde edilmesi için oluşturuldu. */
    #endregion

    #region ForeignKey
    public int EmployeeId { get; set; }
    public string TerritoryId { get; set; }
    public Territory Territory { get; set; }
    public Employee Employee { get; set; }

    #endregion
}
