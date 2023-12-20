using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayrollManagementSys.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Data.Mappings
{
    public class DepartmanMap : IEntityTypeConfiguration<Departman>
    {
        public void Configure(EntityTypeBuilder<Departman> builder)
        {
            builder.HasData(new Departman()
            {
                Id = 1,
                Name = "DenemeDepartman",
                
            },
            new Departman()
            {
                Id = 2,
                Name = "DenemeDepartman1",
                
            });

        }
    }
}
