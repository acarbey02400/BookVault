using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.UserOperationClaims);
            });
            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(p => p.User);
                a.HasOne(p => p.OperationClaim);
            });
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.HasMany(p => p.UserOperationClaims);
            });
        }
    }
}
