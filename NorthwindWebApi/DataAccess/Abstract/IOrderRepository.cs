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
    public interface IOrderRepository : IEntityRepository<Order>
    {
        Task<IEnumerable<OrderWithShipperDto>> GetOrdersWithShipperList();
        Task<OrderWithShipperDto> GetOrderWithShipper(int orderId);

        Task<IEnumerable<OrderWithEmployeeDto>> GetOrdersWithEmployeeList();

        Task<IEnumerable<OrderShipperEmployeeDto>> GetOrderShipperEmployeeList();

        Task<OrderCustomerShipperEmployeeDto> GetOrderCustomerShipperEmployee(int orderId);

        Task<IEnumerable<OrderWithCustomerDto>> GetOrdersWithCustomerList();

        

        
        
    }
}
