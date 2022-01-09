using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repository
{
    public class EmployeeTerritoryRepository : EfEntityRepositoryBase<EmployeeTerritory, NorthwindContext>, IEmployeeTerritoryRepository
    {
        public EmployeeTerritoryRepository(NorthwindContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeTerritoriesDto>> GetEmployeeTerritoriesList()
        {
            var result = await (from territory in Context.Territories
                                join empTer in Context.EmployeeTerritories
                                on territory.TerritoryId equals empTer.TerritoryId
                                join emp in Context.Employees
                                on empTer.EmployeeId equals emp.EmployeeId
                                select new EmployeeTerritoriesDto()
                                {
                                    TerritoryId = empTer.TerritoryId,
                                    EmployeeId = empTer.EmployeeId
                                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<TerritoriesEmployeeDto>> GetTerritoriesWithEmployeeList()
        {
            var result = await ( from terrotiries in Context.Territories
                                 join empTer in Context.EmployeeTerritories
                                 on terrotiries.TerritoryId equals empTer.TerritoryId
                                 join emp in Context.Employees
                                 on empTer.EmployeeId equals emp.EmployeeId
                                 select new TerritoriesEmployeeDto()
                                 {
                                     EmployeeId = empTer.EmployeeId,
                                     FirstName = emp.FirstName,
                                     LastName = emp.LastName,
                                     TerritoryId = empTer.TerritoryId,
                                     TerritoryDescription = terrotiries.TerritoryDescription,
                                     RegionId = terrotiries.RegionId
                                 }).ToListAsync();

            return result;
        }
    }
}
