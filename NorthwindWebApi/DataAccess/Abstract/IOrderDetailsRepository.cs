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
    public interface IOrderDetailsRepository : IEntityRepository<OrderDetail>
    {
        Task<IEnumerable<OrderWithProductDto>> GetOrderWithProductList();

        Task<IEnumerable<CustomerWithProductDto>> GetCustomerWithProductList();

        Task<IEnumerable<CustomerOrderEmployeeProductCategorySupplierDto>> GetCustomerOrderEmployeeProductCategorySupplierList();
    }
}
