using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repository
{
    public class TerritoryRepository : EfEntityRepositoryBase<Territory, NorthwindContext>, ITerritoryRepository
    {
        public TerritoryRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
