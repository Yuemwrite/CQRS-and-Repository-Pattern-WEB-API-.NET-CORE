

using Business.Handlers.Employees.ValidationRules;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.Repository;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("connectionStr"),
                    sqlOptions =>
                    {
                        sqlOptions
                            .EnableRetryOnFailure(
                                maxRetryCount: 1,
                                maxRetryDelay: TimeSpan.FromSeconds(10),
                                errorNumbersToAdd: null);
                    });
                // options.EnableSensitiveDataLogging();
                // options.EnableDetailedErrors();
            }, ServiceLifetime.Transient, ServiceLifetime.Singleton);
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services.AddTransient<ICustomerRepository, CustomerRepository>()
                           .AddTransient<ICategoryRepository, CategoryRepository>()
                           .AddTransient<IProductRepository, ProductRepository>()
                           .AddTransient<IShipperRepository, ShipperRepository>()
                           .AddTransient<IOrderRepository, OrderRepository>()
                           .AddTransient<IEmployeeRepository, EmployeeRepository>()
                           .AddTransient<ISupplierRepository, SupplierRepository>()
                           .AddTransient<IRegionRepository, RegionRepository>()
                           .AddTransient<ITerritoryRepository, TerritoryRepository>()
                           .AddTransient<IEmployeeTerritoryRepository, EmployeeTerritoryRepository>()
                           .AddTransient<IOrderDetailsRepository, OrderDetailRepository>();
                           
                           
        }
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly())
                 .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
