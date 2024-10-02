using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entities.Entities
{
    public class User
    {
        public Guid Id { get; set; } =Guid.NewGuid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "User";
        public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; } =false;
        public string EmailConfirmationToken { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
