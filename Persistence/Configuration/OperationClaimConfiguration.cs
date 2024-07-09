using Core.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class OperationClaimConfiguration:BaseConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> a)
        {
            base.Configure(a);
          
              a.ToTable("OperationClaims").HasKey(p => p.Id);
              a.Property(p => p.Id).HasColumnName("Id");
              a.Property(p => p.Name).HasColumnName("Name");
              a.HasMany(p => p.UserOperationClaims);
           

        }
    }
}
