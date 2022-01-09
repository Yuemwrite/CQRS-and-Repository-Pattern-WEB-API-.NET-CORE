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
    public class ShipperEntityConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            #region Primary Key
            builder.HasKey(_=>_.ShipperId);
            #endregion

            #region Columns
            builder.Property(_=>_.CompanyName).HasMaxLength(40);
            builder.Property(_=>_.Phone).HasMaxLength(24);
            #endregion
        }
    }
}
