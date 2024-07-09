using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Persistence.Configuration
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.IsDeleted);
            builder.Property(e => e.IsActive);
            builder.Property(e => e.CreatedById);
            builder.Property(e => e.UpdatedById);
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);

            builder.HasOne(e => e.CreatedBy).WithMany().HasForeignKey(e => e.CreatedById).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.UpdatedBy).WithMany().HasForeignKey(e => e.UpdatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
