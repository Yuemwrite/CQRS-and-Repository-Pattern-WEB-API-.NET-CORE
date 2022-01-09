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
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            #region PrimaryKey
            builder.HasKey(_=>_.SupplierId);
            #endregion

            #region Columns
            builder.Property(_=>_.CompanyName).HasMaxLength(40).IsRequired();
            builder.Property(_ => _.ContactName).HasMaxLength(30);
            builder.Property(_=>_.ContactTitle).HasMaxLength(30);
            builder.Property(_=>_.Address).HasMaxLength(60);
            builder.Property(_=>_.City).HasMaxLength(15);
            builder.Property(_=>_.Region).HasMaxLength(15);
            builder.Property(_=>_.PostalCode).HasMaxLength(10);
            builder.Property(_=>_.Country).HasMaxLength(15);
            builder.Property(_=>_.Phone).HasMaxLength(24);
            builder.Property(_=>_.Fax).HasMaxLength(24);
            #endregion
        }
    }
}
