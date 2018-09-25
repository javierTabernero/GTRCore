using GTR.CrossCutting.Enums;
using GTR.Domain.Model.Data;

namespace GTR.Service.Services.Account
{
    public interface IUserService
    {
        User Get(string email);

        void Login(string email, string password);

        void Register(string name, string email, string password, Role role);
    }
}