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
    public class UserConfiguration:BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> a)
        {
            base.Configure(a);
            a.ToTable("Users").HasKey(p => p.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Status).HasColumnName("Status");
            a.Property(p => p.FirstName).HasColumnName("FirstName");
            a.Property(p => p.Email).HasColumnName("Email");
            a.Property(p => p.LastName).HasColumnName("LastName");
            a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
            a.HasMany(u => u.UserOperationClaims)
            .WithOne(uoc => uoc.User)
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            a.HasMany(x=>x.RefreshTokens).WithOne(p=>p.User).HasForeignKey(p => p.UserId);


        }
    }
}
