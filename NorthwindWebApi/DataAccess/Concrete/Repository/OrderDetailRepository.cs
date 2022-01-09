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
    public class OrderDetailRepository : EfEntityRepositoryBase<OrderDetail, NorthwindContext>, IOrderDetailsRepository
    {
        public OrderDetailRepository(NorthwindContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CustomerOrderEmployeeProductCategorySupplierDto>> GetCustomerOrderEmployeeProductCategorySupplierList()
        {
            var result = await (from customer in Context.Customers
                                join order in Context.Orders
                                on customer.CustomerId equals order.CustomerId
                                join employee in Context.Employees
                                on order.EmployeeId equals employee.EmployeeId
                                join orderDetail in Context.OrderDetails
                                on order.OrderId equals orderDetail.OrderId
                                join product in Context.Products
                                on orderDetail.ProductId equals product.ProductId
                                join categories in Context.Categories
                                on product.CategoryId equals categories.CategoryId
                                join supplier in Context.Suppliers
                                on product.SupplierId equals supplier.SupplierId
                                select new CustomerOrderEmployeeProductCategorySupplierDto()
                                {
                                    CustomerId = customer.CustomerId,
                                    OrderId = order.OrderId,
                                    ShipName = order.ShipName,
                                    EmployeeId = employee.EmployeeId,
                                    FirstName = employee.FirstName,
                                    LastName = employee.LastName,
                                    ProductId = product.ProductId,
                                    ProductName = product.ProductName,
                                    CategoryName = categories.CategoryName,
                                    SupplierId = supplier.SupplierId,
                                    CompanyName = supplier.CompanyName
                                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<CustomerWithProductDto>> GetCustomerWithProductList()
        {
            var result = await (from customer in Context.Customers
                                join orders in Context.Orders
                                on customer.CustomerId equals orders.CustomerId
                                join orderDetail in Context.OrderDetails
                                on orders.OrderId equals orderDetail.OrderId
                                join products in Context.Products
                                on orderDetail.ProductId equals products.ProductId
                                select new CustomerWithProductDto()
                                {
                                    CustomerId = customer.CustomerId,
                                    CompanyName = customer.CompanyName,
                                    ProductId = products.ProductId,
                                    ProductName = products.ProductName
                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<OrderWithProductDto>> GetOrderWithProductList()
        {
            var result = await (from order in Context.Orders
                                join orderDetail in Context.OrderDetails
                                on order.OrderId equals orderDetail.OrderId
                                join product in Context.Products
                                on orderDetail.ProductId equals product.ProductId
                                select new OrderWithProductDto()
                                {
                                    OrderId = order.OrderId,
                                    ShipName = order.ShipName,
                                    ProductId = product.ProductId,
                                    ProductName = product.ProductName
                                }).ToListAsync();

            return result;
        }
    }

}
