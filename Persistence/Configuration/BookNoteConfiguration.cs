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
    public class BookNoteConfiguration:BaseConfiguration<BookNote>
    {
        public override void Configure(EntityTypeBuilder<BookNote> a)
        {
            base.Configure(a);

            a.ToTable("BookNotes").HasKey(p => p.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.IsShared).HasColumnName("IsShared");
            a.Property(p => p.IsDeleted).HasColumnName("IsDeleted");
            a.Property(p => p.IsActive).HasColumnName("IsActive");
            a.Property(p => p.BookId).HasColumnName("BookId");
            a.Property(p => p.Description).HasColumnName("Description");
            a.HasMany(p => p.SharedUsers);
        }
    }
}
