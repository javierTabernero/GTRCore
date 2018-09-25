using GTR.CrossCutting.Enums;
using GTR.Domain.Model.Data;
using System;

namespace GTR.Domain.Services.Account
{
    public interface IUserLogic
    {
        User Get(Guid id);

        User Get(string email);

        void Login(string email, string password);

        void Register(string name, string email, string password, Role role);
    }
}