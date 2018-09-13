using GTR.Domain.Model.Data;
using System.Collections.Generic;

namespace GTR.Domain.Validations
{
    public interface IBlogValidator : IValidator<Repository.Model.Blog>
    {
        IEnumerable<KeyValuePair<string, string>> GetLogicDeleteValidationMessages(Repository.Model.Blog blog, User usuario);
    }
}