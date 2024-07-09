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
    public class BookConfiguration:BaseConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> a)
        {
            base.Configure(a);
          
                a.ToTable("Books").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.IsDeleted).HasColumnName("IsDeleted");
                a.Property(p => p.IsActive).HasColumnName("IsActive");
                a.Property(p => p.BookShelfId).HasColumnName("BookShelfId");
                a.Property(p => p.Category).HasColumnName("Category");
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                a.Property(p => p.Price).HasColumnName("Price");
                a.Property(p => p.Stock).HasColumnName("Stock");
                a.HasOne(p => p.BookShelf).WithMany().HasForeignKey(x => x.BookShelfId);
                a.HasMany(p=>p.BookNotes).WithOne(x=>x.Book).HasForeignKey(y=>y.BookId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
