using System;
using System.Collections.Generic;

namespace GTR.CrossCutting.Exceptions
{
    public class ValidationException : Exception
    {
        private List<KeyValuePair<string, string>> _errorMessages = new List<KeyValuePair<string, string>>();

        public ValidationException() { }

        public ValidationException(string source, string message)
        {
            _errorMessages.Add(new KeyValuePair<string, string>(source, message));
        }

        public ValidationException(IEnumerable<KeyValuePair<string, string>> errorMessages)
        {
            _errorMessages.AddRange(errorMessages);
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException) { }

        public IEnumerable<KeyValuePair<string, string>> Messages
        {
            get { return _errorMessages; }
        }

        public void AddMessage(string source, string message)
        {
            _errorMessages.Add(new KeyValuePair<string, string>(source, message));
        }

        public void AddMessage(KeyValuePair<string, string> validationMessage)
        {
            _errorMessages.Add(validationMessage);
        }
    }
}
