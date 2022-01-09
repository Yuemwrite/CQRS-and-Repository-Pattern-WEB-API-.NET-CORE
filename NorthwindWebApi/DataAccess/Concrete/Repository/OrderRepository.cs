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
    public class OrderRepository : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
        }

        public async Task<OrderCustomerShipperEmployeeDto> GetOrderCustomerShipperEmployee(int orderId)
        {
            var result = await (from order in Context.Orders
                                join emp in Context.Employees
                                on order.EmployeeId equals emp.EmployeeId
                                join shipper in Context.Shippers
                                on order.ShipperId equals shipper.ShipperId
                                join customer in Context.Customers
                                on order.CustomerId equals customer.CustomerId
                                where order.OrderId == orderId
                                select new OrderCustomerShipperEmployeeDto()
                                {
                                    EmployeeId = order.EmployeeId,
                                    ShipName = order.ShipName,
                                    ShipperId = shipper.ShipperId

                                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<OrderShipperEmployeeDto>> GetOrderShipperEmployeeList()
        {
            var result = await (from order in Context.Orders
                                join shipper in Context.Shippers
                                on order.ShipperId equals shipper.ShipperId
                                join employee in Context.Employees
                                on order.EmployeeId equals employee.EmployeeId
                                select new OrderShipperEmployeeDto()
                                {
                                    OrderId = order.OrderId,
                                    ShipName = order.ShipName,
                                    ShipAddress = order.ShipAddress,
                                    ShipperId  = shipper.ShipperId,
                                    CompanyName = shipper.CompanyName,
                                    Phone = shipper.Phone,
                                    EmployeeId = employee.EmployeeId,
                                    FirstName = employee.FirstName,
                                    LastName = employee.LastName,
                                    Country  = employee.Country
                                }).ToListAsync();

                     return result;
        }

        public async Task<IEnumerable<OrderWithCustomerDto>> GetOrdersWithCustomerList()
        {
            var result = await (from order in Context.Orders
                                join customer in Context.Customers
                                on order.CustomerId equals customer.CustomerId
                                select new OrderWithCustomerDto()
                                {
                                    OrderId= order.OrderId,
                                    ShipName= order.ShipName,
                                    CustomerId = customer.CustomerId,
                                    CompanyName= customer.CompanyName
                                }
                                ).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<OrderWithEmployeeDto>> GetOrdersWithEmployeeList()
        {
            var result = await (from order in Context.Orders
                                join employee in Context.Employees
                                on order.EmployeeId equals employee.EmployeeId
                                select new OrderWithEmployeeDto()
                                {
                                    OrderId = order.OrderId,
                                    EmployeeId = employee.EmployeeId,
                                    ShipName = order.ShipName,
                                    ShipCountry = order.ShipCountry,
                                    FirstName = employee.FirstName,
                                    LastName = employee.LastName   
                                }).ToListAsync();
            return result;
        }

       

        public async Task<IEnumerable<OrderWithShipperDto>> GetOrdersWithShipperList()
        {
            var result = await (from order in Context.Orders
                                join shipper in Context.Shippers
                                on order.ShipperId equals shipper.ShipperId
                                select new OrderWithShipperDto()
                                {
                                    OrderId = order.OrderId,
                                    ShipperId = shipper.ShipperId,
                                    ShipAddress = order.ShipAddress,
                                    ShipName = order.ShipName,
                                    ShipCountry = order.ShipCountry,
                                    CompanyName = shipper.CompanyName,
                                    Phone = shipper.Phone
                                }).ToListAsync();

            return result;
        }

        public Task<OrderWithShipperDto> GetOrderWithShipper(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
