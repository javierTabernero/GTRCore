using GTR.Domain.Model.Data;
using GTR.Domain.Validations;
using GTR.Repository.Repositories;
using System.Collections.Generic;

namespace GTR.Domain.Logic.Validations
{
    public class PostValidator : /*BaseValidator,*/ IPostValidator
    {
        private readonly IPostRepository _postRepository;

        public PostValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetValidationMessages(Repository.Model.Post repositoryEntityToValidate, User usuario)
        {
            //_validationMessages.Clear();

            //ValidateIfReportIsDefault(repositoryEntityToValidate.IsShared, repositoryEntityToValidate.IsDefault, usuario);
            //ValidateTmpReportAllowFranquiciaAndUser(repositoryEntityToValidate.CodigoFranquicia, repositoryEntityToValidate.CodigoUsuarioCreacion, usuario);

            //ValidateMandatoryString(LambdaExtensions.GetPropertyName(() => repositoryEntityToValidate.Nombre), repositoryEntityToValidate.Nombre);

            //return _validationMessages;

            List<KeyValuePair<string, string>> validationMessages = new List<KeyValuePair<string, string>>();
            return validationMessages;
        }

        public IEnumerable<KeyValuePair<string, string>> GetDeleteValidationMessages(int idRepositoryEntityToDelete, User usuario)
        {
            //_validationMessages.Clear();

            //Repository.Model.Reports report = _reportRepository.GetById(idRepositoryEntityToDelete);
            //ValidateIfReportIsDefault(report.IsShared, report.IsDefault, usuario);

            //return _validationMessages;

            List<KeyValuePair<string, string>> validationMessages = new List<KeyValuePair<string, string>>();
            return validationMessages;
        }

        public IEnumerable<KeyValuePair<string, string>> GetLogicDeleteValidationMessages(Repository.Model.Post report, User usuario)
        {
            //_validationMessages.Clear();
            //ValidadeIsNotStoredProcedure(LambdaExtensions.GetPropertyName(() => report.ReportType), report.ReportType);
            //ValidateIfReportIsDefault(report.IsShared, report.IsDefault, usuario);
            //ValidateTmpReportAllowFranquiciaAndUser(report.CodigoFranquicia, report.CodigoUsuarioCreacion, usuario);

            //return _validationMessages;

            List<KeyValuePair<string, string>> validationMessages = new List<KeyValuePair<string, string>>();
            return validationMessages;
        }
    }
}
