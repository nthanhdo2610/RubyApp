using Microsoft.EntityFrameworkCore;
using RubyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubyApp.Security
{
    public static class Bootstrapper
    {
        public static void EnsureDatabase()
        {
            using var db = new AppDbContext();
            db.Database.Migrate(); // if Tools/migrations used; otherwise creates schema

            if (!db.Users.Any())
            {
                db.Users.Add(new AppUser
                {
                    Username = "admin",
                    PasswordHash = PasswordHasher.Hash("Admin@123"),
                    Role = UserRole.SuperAdmin,
                    MustChangePassword = true,
                    IsActive = true
                });
                db.SaveChanges();
            }
        }
    }
}
