using GTR.CrossCutting.Enums;
using GTR.CrossCutting.Mapping;
using GTR.Domain.Logic.Services.Base;
using GTR.Domain.Model.Data;
using GTR.Domain.Services.Account;
using GTR.Repository.Repositories.Account;
using System;

namespace GTR.Domain.Logic.Services.Account
{
    public class UserLogic : BaseServiceLogic<User, Repository.Model.Data.Users.User>, IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IMapper mapper, IUserRepository userRepository): base(mapper)
        {
            _userRepository = userRepository;
        }

        public User Get(Guid id)
        {
            return GetDomainEntityFromRepositoryEntity(_userRepository.Get(id));
        }

        public User Get(string email)
        {
            return GetDomainEntityFromRepositoryEntity(_userRepository.Get(email));
        }

        public void Login(string email, string password)
        {
            User user = Get(email);

            if (user == null)
            {
                throw new Exception($"User '{email}' was not found.");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid password.");
            }
        }

        public void Register(string name, string email, string password, Role role)
        {
            User user = Get(email);

            if (user != null)
            {
                throw new Exception($"User '{email}' already exists.");
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role.ToString(), true);
            user = new User(name, email, password, userRole, "es_Es");

            Add(user);
        }

        private void Add(User user)
        {
            _userRepository.Add(UserToRepositoryEntity(user));
        }
    }
}