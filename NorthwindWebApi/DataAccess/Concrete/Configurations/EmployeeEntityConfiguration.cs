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
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region Primary Key
            builder.HasKey(_=>_.EmployeeId);
            #endregion

            #region Columns
            builder.Property(_=>_.FirstName).HasMaxLength(10).IsRequired();
            builder.Property(_=>_.LastName).HasMaxLength(20).IsRequired();
            builder.Property(_=>_.Title).HasMaxLength(30);
            builder.Property(_ => _.TitleOfCourtesy).HasMaxLength(30);
            builder.Property(_ => _.Address).HasMaxLength(60);
            builder.Property(_ => _.City).HasMaxLength(15);
            builder.Property(_ => _.Region).HasMaxLength(15);
            builder.Property(_ => _.PostalCode).HasMaxLength(10);
            builder.Property(_ => _.Country).HasMaxLength(15);
            builder.Property(_ => _.HomePhone).HasMaxLength(24);
            builder.Property(_ => _.Extension).HasMaxLength(4);
            builder.Property(_ => _.ReportsTo);
            #endregion
        }
    }
}
