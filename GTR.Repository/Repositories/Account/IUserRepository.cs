using GTR.Repository.Model.Data.Users;
using System;

namespace GTR.Repository.Repositories.Account
{
    public interface IUserRepository
    {
        User Get(Guid id);

        User Get(string email);

        void Add(User user);
    }
}