using GTR.Domain.Model.Data;
using System.Collections.Generic;

namespace GTR.Domain.Validations
{
    public interface IPostValidator : IValidator<Repository.Model.Post>
    {
        IEnumerable<KeyValuePair<string, string>> GetLogicDeleteValidationMessages(Repository.Model.Post post, User usuario);
    }
}