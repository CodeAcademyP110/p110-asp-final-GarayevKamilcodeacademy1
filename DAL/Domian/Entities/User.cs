using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domian.Entities
{
    public class User
    {
        public int ID { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get => UserName.Normalize(); } 
        public string Email { get; set; }
        public string NormalizedEmail { get => Email.Normalize(); }
        public bool EmailConfirmed { get; set; } = true;
        public string PasswordHash { get => Password.ToUpper(); }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; } = true;
        public bool TwoFactorEnabled { get; set; } = true;
    }
}
