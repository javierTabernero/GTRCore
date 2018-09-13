using GTR.Domain.Model.Data;
using System.Collections.Generic;

namespace GTR.Domain.Validations
{
    public interface IValidator<TRepositoryEntity>
         where TRepositoryEntity : class
    {
        IEnumerable<KeyValuePair<string, string>> GetValidationMessages(TRepositoryEntity repositoryEntityToValidate, User usuario);
        IEnumerable<KeyValuePair<string, string>> GetDeleteValidationMessages(int idRepositoryEntityToDelete, User usuario);
    }
}