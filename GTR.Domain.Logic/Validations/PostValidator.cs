using GTR.Domain.Logic.Validations.Base;
using GTR.Domain.Model.Data;
using GTR.Domain.Validations;
using GTR.Repository.Repositories;
using System.Collections.Generic;

namespace GTR.Domain.Logic.Validations
{
    public class PostValidator : BaseValidator, IPostValidator
    {
        private readonly IPostRepository _postRepository;

        public PostValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetValidationMessages(Repository.Model.Post repositoryEntityToValidate, User usuario)
        {
            _validationMessages.Clear();

            AddValidationMessageIfInvalidMandatoryTextAndLength(nameof(repositoryEntityToValidate.Title), repositoryEntityToValidate.Title, 100, 5);
            AddValidationMessageIfInvalidMandatoryTextAndLength(nameof(repositoryEntityToValidate.Content), repositoryEntityToValidate.Content, 100, 5);

            return _validationMessages;
        }

        public IEnumerable<KeyValuePair<string, string>> GetDeleteValidationMessages(int idRepositoryEntityToDelete, User usuario)
        {
            List<KeyValuePair<string, string>> validationMessages = new List<KeyValuePair<string, string>>();
            return validationMessages;
        }

        public IEnumerable<KeyValuePair<string, string>> GetLogicDeleteValidationMessages(Repository.Model.Post report, User usuario)
        {
            List<KeyValuePair<string, string>> validationMessages = new List<KeyValuePair<string, string>>();
            return validationMessages;
        }
    }
}