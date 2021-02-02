using IGRUSDB_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.EntityFrameworkCore.Extensions;

namespace IGRUSDB_ASP.Data
{
    public class IgrusDbContext : DbContext
    {

        public IgrusDbContext(DbContextOptions<IgrusDbContext> options) : base (options)
        {
            
        }

        public DbSet<CMember> CMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CMember>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Major).IsRequired();
                entity.Property(e => e.Email);
                entity.Property(e => e.Grade).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.Comment).HasMaxLength(100);
            });
        }
    }
}
