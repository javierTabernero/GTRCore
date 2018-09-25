using GTR.Domain.Model.Data;

namespace GTR.Identity
{
    interface IUserIdentity
    {
        User GetActiveUser();
    }
}