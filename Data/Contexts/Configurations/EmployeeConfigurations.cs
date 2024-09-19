using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<EmployeeViewModel>
    {
        public void Configure(EntityTypeBuilder<EmployeeViewModel> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
        }
    }
}
