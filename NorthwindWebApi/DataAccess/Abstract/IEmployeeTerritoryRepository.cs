using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeTerritoryRepository : IEntityRepository<EmployeeTerritory>
    {
        Task<IEnumerable<TerritoriesEmployeeDto>> GetTerritoriesWithEmployeeList();

        Task<IEnumerable<EmployeeTerritoriesDto>> GetEmployeeTerritoriesList();
        
    }
}
