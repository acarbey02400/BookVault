using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class BookShelfConfiguration : BaseConfiguration<BookShelf>
    {
        public override void Configure(EntityTypeBuilder<BookShelf> a)
        {
            base.Configure(a);

            a.ToTable("BookShelfs").HasKey(p => p.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.ShelfCode).HasColumnName("ShelfCode");
            a.Property(p => p.IsDeleted).HasColumnName("IsDeleted");
            a.Property(p => p.IsActive).HasColumnName("IsActive");
            a.Property(p => p.Location).HasColumnName("Location");
        }
    }
}
