using GTR.Domain.Logic.Validations.Base;
using GTR.Domain.Model.Data;
using GTR.Domain.Validations;
using GTR.Repository.Repositories;
using System.Collections.Generic;

namespace GTR.Domain.Logic.Validations
{
    public class BlogValidator : BaseValidator, IBlogValidator
    {
        private readonly IBlogRepository _blogRepository;

        public BlogValidator(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetValidationMessages(Repository.Model.Blog repositoryEntityToValidate, User usuario)
        {
            _validationMessages.Clear();

            AddValidationMessageIfInvalidMandatoryTextAndLength(nameof(repositoryEntityToValidate.Url), repositoryEntityToValidate.Url, 100, 5);

            return _validationMessages;
        }

        public IEnumerable<KeyValuePair<string, string>> GetDeleteValidationMessages(int idRepositoryEntityToDelete, User usuario)
        {
            _validationMessages.Clear();
            
            return _validationMessages;
        }

        public IEnumerable<KeyValuePair<string, string>> GetLogicDeleteValidationMessages(Repository.Model.Blog report, User usuario)
        {
            _validationMessages.Clear();

            return _validationMessages;
        }
    }
}