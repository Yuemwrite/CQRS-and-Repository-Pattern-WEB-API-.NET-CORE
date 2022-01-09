using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<IEnumerable<ProductWithCategoryDto>> GetProductsWithCategoryList();

        Task<ProductWithCategoryDto> GetProductWithCategory(int productId);

        Task<IEnumerable<ProductWithSupplierDto>> GetProductWithSupplierList();

        Task<IEnumerable<ProductSupplierCategoryDto>> GetProductSupplierCategoryList();

        
    }
}
