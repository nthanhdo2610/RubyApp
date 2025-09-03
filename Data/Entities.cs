using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubyApp.Data
{
    public enum UserRole { SuperAdmin = 1, User = 2 }

    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = ""; // PBKDF2|iters|salt|hash
        public UserRole Role { get; set; } = UserRole.User;
        public bool MustChangePassword { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginUtc { get; set; }
    }
}