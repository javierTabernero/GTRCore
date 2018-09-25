using GTR.CrossCutting.Enums;
using System;
using System.Globalization;

namespace GTR.Repository.Model.Data.Users
{
    public class User
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public string Email { get; }

        public string Password { get; set; }

        public Role Role { get; }

        public string Country { get; set; }

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