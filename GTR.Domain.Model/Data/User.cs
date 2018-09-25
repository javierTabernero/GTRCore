using GTR.CrossCutting.Enums;
using System;
using System.Globalization;

namespace GTR.Domain.Model.Data
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        //Plain text
        public string Password { get; set; }

        public Role Role { get; set; }

        public string Country { get; set; }

        public User() { }

        public User(string name, string email, string password, Role role, string country)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email.ToLowerInvariant();
            Password = password;
            Role = role;
            Country = country;
        }
    }
}