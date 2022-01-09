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
    public class ProductRepository : EfEntityRepositoryBase<Product, NorthwindContext>, IProductRepository
    {
        public ProductRepository(NorthwindContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductWithCategoryDto>> GetProductsWithCategoryList()
        {
            var result = await (from product in Context.Products
                                join categories in Context.Categories
                                    on product.CategoryId equals categories.CategoryId
                                select new ProductWithCategoryDto()
                                {
                                    ProductId = product.ProductId,
                                    CategoryName = categories.CategoryName,
                                    ProductName = product.ProductName,
                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ProductSupplierCategoryDto>> GetProductSupplierCategoryList()
        {
            var result = await (from product in Context.Products
                                join category in Context.Categories
                                on product.CategoryId equals category.CategoryId
                                join supplier in Context.Suppliers
                                on product.SupplierId equals supplier.SupplierId
                                select new ProductSupplierCategoryDto()
                                {
                                    ProductId = product.ProductId,
                                    ProductName = product.ProductName,
                                    CategoryName = category.CategoryName,
                                    CompanyName = supplier.CompanyName
                                }).ToListAsync();
            return result;
        }

        

        public async Task<ProductWithCategoryDto> GetProductWithCategory(int productId)
        {
            var result = await (from product in Context.Products
                                join category in Context.Categories
                                on product.CategoryId equals category.CategoryId
                                where product.ProductId == productId
                                select new ProductWithCategoryDto()
                                {
                                    ProductId = product.ProductId,
                                    CategoryName = category.CategoryName,
                                    ProductName = product.ProductName
                                }).FirstOrDefaultAsync();

            return result;
                
                
        }

        public async Task<IEnumerable<ProductWithSupplierDto>> GetProductWithSupplierList()
        {
            var result = await (from product in Context.Products
                                join supplier in Context.Suppliers
                                on product.SupplierId equals supplier.SupplierId
                                select new ProductWithSupplierDto()
                                {
                                    ProductId = product.ProductId,
                                    ProductName= product.ProductName,
                                    SupplierId = supplier.SupplierId,
                                    CompanyName = supplier.CompanyName,
                                    ContactName = supplier.ContactName,
                                    ContactTitle = supplier.ContactTitle,
                                }).ToListAsync();

            return result;
        }
    }
}
