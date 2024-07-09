using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class RefreshTokenConfiguration:BaseConfiguration<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> a)
        {
            base.Configure(a);
            a.ToTable("RefreshTokens").HasKey(p => p.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            a.Property(p => p.Expires).HasColumnName("Expires");
            a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
            a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            a.Property(p => p.Revoked).HasColumnName("Revoked");
            a.Property(p => p.Token).HasColumnName("Token");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.HasOne(u => u.User);


        }
    }
}
