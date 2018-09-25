using GTR.CrossCutting.Enums;
using GTR.Repository.Model.Data.Users;
using GTR.Repository.Repositories.Account;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GTR.Repository.Logic.Repositories.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly static ISet<User> _users = new HashSet<User>
        {
            new User("Javier", "javier@javier.com", "javier", Role.User, "es-ES"),
            new User("John McClane", "poweruser@domain.com", "secret", Role.PowerUser, "fr-FR"),
            new User("Neo", "admin@domain.com", "secret", Role.Admin, "en-US")
        };

        public User Get(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public User Get(string email)
        {
            return _users.SingleOrDefault(x => string.Equals(x.Email, email, StringComparison.InvariantCultureIgnoreCase));
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}