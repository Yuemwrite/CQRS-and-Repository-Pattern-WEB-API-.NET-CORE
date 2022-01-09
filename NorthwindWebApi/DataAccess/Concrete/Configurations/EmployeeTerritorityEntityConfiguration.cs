using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configurations
{
    public class EmployeeTerritorityEntityConfiguration : IEntityTypeConfiguration<EmployeeTerritory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmployeeTerritory> builder)
        {
            #region Primary Key
            builder.HasKey(_=>_.Id);
            #endregion

            #region ForeignKey

            builder.Property(_=>_.EmployeeId);
            builder
                .HasOne(_=>_.Employee)
                .WithMany(e=>e.EmployeeTerritories)
                .HasForeignKey(fk=>fk.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
