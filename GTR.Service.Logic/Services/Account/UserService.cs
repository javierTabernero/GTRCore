using GTR.CrossCutting.Enums;
using GTR.Domain.Model.Data;
using GTR.Domain.Services.Account;
using GTR.Service.Services.Account;
using System;
using System.Globalization;

namespace GTR.Service.Logic.Services.Account
{
    public class UserService : IUserService
    {
        private readonly IUserLogic _userLogic;

        public UserService(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public User Get(string email)
        {
            User user = _userLogic.Get(email);

            return user;
        }

        public void Login(string email, string password)
        {
            _userLogic.Login(email, password);
        }

        public void Register(string name, string email, string password, Role role)
        {
            _userLogic.Register(name, email, password, role);
        }
    }
}