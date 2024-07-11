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
    public class UserBookNoteConfiguration:BaseConfiguration<UserBookNote>
    {
        public override void Configure(EntityTypeBuilder<UserBookNote> a)
        {
            base.Configure(a);

            a.ToTable("UserBookNote").HasKey(p => p.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.IsDeleted).HasColumnName("IsDeleted");
            a.Property(p => p.IsActive).HasColumnName("IsActive");
            a.Property(p=>p.UserId).HasColumnName("UserId");
            a.HasOne(p => p.User).WithMany().HasForeignKey(x=>x.UserId);
            a.HasOne(p => p.BookNote).WithMany(x => x.UserBookNotes).HasForeignKey(x=>x.BookNoteId);
        }
    }
}
