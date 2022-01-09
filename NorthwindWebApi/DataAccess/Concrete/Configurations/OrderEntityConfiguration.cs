using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            #region Primary Key
            builder.HasKey(_=>_.OrderId);
            #endregion

            #region Columns

            builder.Property(_=>_.ShipName).HasMaxLength(40);
            builder.Property(_ => _.ShipAddress).HasMaxLength(60);
            builder.Property(_ => _.ShipCity).HasMaxLength(15);
            builder.Property(_ => _.ShipRegion).HasMaxLength(40);
            builder.Property(_ => _.ShipPostalCode).HasMaxLength(40);
            builder.Property(_=>_.ShipCountry).HasMaxLength(15);

            #region Sipper ShipperId -> ShipperId
            builder.Property(_=>_.ShipperId);
            builder
                .HasOne(_=>_.Shipper)
                .WithMany(_=>_.Orders)
                .HasForeignKey(fk=>fk.ShipperId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Employee EmployeeId -> EmployeeId
            builder.Property(_=>_.EmployeeId);
            builder
                .HasOne(_ => _.Employee)
                .WithMany(_ => _.Orders)
                .HasForeignKey(fk => fk.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Customer CustomerId -> CustomerId
            builder.Property(_=>_.CustomerId);
            builder
                .HasOne(_ => _.Customer)
                .WithMany(_ => _.Orders)
                .HasForeignKey(_ => _.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #endregion
        }
    }
}
