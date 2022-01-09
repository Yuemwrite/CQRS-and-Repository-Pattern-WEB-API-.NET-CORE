using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configurations;
public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        #region Primary Key
        builder.HasKey(_=>_.ProductId);
        #endregion

        #region Columns

        builder.Property(_=>_.ProductName).HasMaxLength(40).IsRequired();
        builder.Property(_=>_.QuantityPerUnit).HasMaxLength(20);
        builder.Property(_=>_.UnitPrice);
        builder.Property(_=>_.UnitsInStock);
        builder.Property(_=>_.UnitsOnOrder);
        builder.Property(_=>_.ReorderLevel);
        builder.Property(_=>_.Discontinued);


        #region Category CategoryId -> CategoryId
        builder.Property(_=>_.CategoryId);
        builder
            .HasOne(_ => _.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(fk=>fk.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
        #endregion

        #region Supplier SupplierId -> SupplierId
        builder.Property(_ => _.SupplierId);
        builder
            .HasOne(_ => _.Supplier)
            .WithMany(c => c.Products)
            .HasForeignKey(fk => fk.SupplierId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion


        #endregion

    }
}
