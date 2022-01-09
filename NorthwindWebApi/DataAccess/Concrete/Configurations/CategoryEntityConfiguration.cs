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
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Primary Key
            builder.HasKey(_ => _.CategoryId);
            #endregion

            #region Columns
            builder.Property(_ => _.CategoryName).HasMaxLength(64).IsRequired();
            builder.Property(_ => _.Description).HasMaxLength(32);
            #endregion

        }
    }
}
