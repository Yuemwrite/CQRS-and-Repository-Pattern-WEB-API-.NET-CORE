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
    public class OrderDetailEntityConfiguıration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            #region PrimaryKey
            builder.HasKey(_=>_.Id);
            #endregion

            #region Columns

            #region 
            #endregion

            #endregion
        }
    }
}
