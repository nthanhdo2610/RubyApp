using Microsoft.EntityFrameworkCore;
using RubyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubyApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> Users => Set<AppUser>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Paths.EnsureDirs();
            optionsBuilder.UseSqlite($"Data Source={Paths.DbFile};Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<AppUser>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Username).IsUnique();
                e.Property(x => x.Username).HasMaxLength(100).IsRequired();
                e.Property(x => x.PasswordHash).IsRequired();
            });
        }
    }
}

