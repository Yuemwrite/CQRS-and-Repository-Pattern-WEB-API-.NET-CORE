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
    public class RegionRepository : EfEntityRepositoryBase<Region, NorthwindContext>, IRegionRepository
    {
        public RegionRepository(NorthwindContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<RegionWithTerritoriesDto>> RegionTerritoriesList()
        {
            var result = await (from region in Context.Region
                               join territory in Context.Territories
                               on region.RegionId equals territory.RegionId
                               select new RegionWithTerritoriesDto()
                               {
                                   RegionId = region.RegionId,
                                   RegionDescription = region.RegionDescription,
                                   TerritoryId = territory.TerritoryId,
                                   TerritoryDescription = territory.TerritoryDescription,

                               }).ToListAsync();
            return result;
        }

    }
}
