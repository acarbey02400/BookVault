using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class UserOperationClaimConfiguration:BaseConfiguration<UserOperationClaim>
    {
        public override void Configure(EntityTypeBuilder<UserOperationClaim> a)
        {
            base.Configure(a);
            a.ToTable("UserOperationClaims").HasKey(p => p.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            a.HasOne(uoc => uoc.User)
            .WithMany(u => u.UserOperationClaims)
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            a.HasOne(p => p.OperationClaim);
        }
    }
}
