using GTR.Domain.Model.Data;
using GTR.Domain.Model.Validations;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GTR.Domain.Logic.Validations.Base
{
    public class BaseValidator
    {
        protected List<KeyValuePair<string, string>> _validationMessages = new List<KeyValuePair<string, string>>();

        protected void AddMessageException(string sourceFieldName, string errorMessage)
        {
            _validationMessages.Add(new KeyValuePair<string, string>(sourceFieldName, errorMessage));
        }

        protected bool AddValidationMessageIfHasValue(string fieldName, int? valueToValidate)
        {
            bool wereAddedMessages = true;

            if (valueToValidate.HasValue)
            {
                wereAddedMessages = false;
            }
            else
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }

            return wereAddedMessages;
        }

        protected bool AddValidationMessageIfInvalidMasterId(string fieldName, int? valueToValidate, Func<int, bool> FuntionToGetMasterValue)
        {
            bool wereAddedMessages = true;

            if (valueToValidate.HasValue)
            {
                if (!FuntionToGetMasterValue(valueToValidate.Value))
                {
                    AddMessageException(fieldName, Resources.Resources.Resources.InvalidNotExist);
                }
                else
                {
                    wereAddedMessages = false;
                }
            }
            else
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }

            return wereAddedMessages;
        }

        protected bool AddValidationMessageIfInvalidMasterId(string fieldName, int? valueToValidate, User user, Func<int, User, bool> FuntionToGetMasterValue)
        {
            bool wereAddedMessages = true;

            if (valueToValidate.HasValue)
            {
                if (!FuntionToGetMasterValue(valueToValidate.Value, user))
                {
                    AddMessageException(fieldName, Resources.Resources.Resources.InvalidNotExist);
                }
                else
                {
                    wereAddedMessages = false;
                }
            }
            else
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }

            return wereAddedMessages;
        }

        protected bool AddValidationMessageIfInvalidMandatoryTextAndLength(string fieldName, string valueToValidate, int maxLength, int minLength = 0)
        {
            bool addedMessages = true;

            if (string.IsNullOrWhiteSpace(valueToValidate))
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }
            else if (valueToValidate.Trim().Length < minLength || valueToValidate.Trim().Length > maxLength)
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidLengthField);
            }
            else
            {
                addedMessages = false;
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfInvalidMandatoryBytes(string fieldName, byte[] valueToValidate)
        {
            bool addedMessages = true;

            if (valueToValidate.Length <= 0)
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }
            else
            {
                addedMessages = false;
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfInvalidOpcionalTextAndLength(string fieldName, object valueToValidate, int maxLength, int minLength)
        {
            bool addedMessages = false;

            if ((valueToValidate != null) && !string.IsNullOrEmpty(valueToValidate.ToString()))
            {
                int valueToValidateLength = valueToValidate.ToString().Trim().Length;
                if ((valueToValidateLength < minLength || valueToValidateLength > maxLength))
                {
                    if (minLength == maxLength)
                    {
                        AddMessageException(valueToValidate.ToString(), $"{Resources.Resources.Resources.InvalidFixedLengthField}|{maxLength.ToString()}");
                    }
                    else
                    {
                        AddMessageException(valueToValidate.ToString(), $"{Resources.Resources.Resources.InvalidLengthFieldWidthMax}|{maxLength.ToString()}");
                    }

                    addedMessages = true;
                }
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfInvalidMandatoryDate(string fieldName, DateTime? valueToValidate)
        {
            bool addedMessages = true;

            if (!valueToValidate.HasValue || (valueToValidate.Value == DateTime.MinValue))
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }
            else
            {
                addedMessages = false;
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfInvalidMandatoryInt(string fieldName, int? valueToValidate)
        {
            bool addedMessages = true;

            if (!valueToValidate.HasValue || (valueToValidate.Value < 0))
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }
            else
            {
                addedMessages = false;
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfInvalidMandatoryBool(string fieldName, bool? valueToValidate)
        {
            bool addedMessages = true;

            if (!valueToValidate.HasValue)
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }
            else
            {
                addedMessages = false;
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfValueToValidateNotBool(string fieldName, object valueToValidate)
        {
            bool addedMessages = true;
            bool parseValueToValidate;

            if (bool.TryParse(valueToValidate.ToString(), out parseValueToValidate))
            {
                addedMessages = false;
            }
            else
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidDataType);

            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfValueToValidateNotDecimal(string fieldName, object valueToValidate)
        {
            bool addedMessages = true;
            decimal parseValueToValidate = decimal.Zero;

            if (decimal.TryParse(valueToValidate.ToString(), out parseValueToValidate))
            {
                addedMessages = false;
            }
            else
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidDataType);
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfValueToValidateNotDateTime(string fieldName, object valueToValidate)
        {
            bool addedMessages = true;
            DateTime parseValueToValidate = DateTime.MinValue;

            if (valueToValidate != null && Convert.ToString(valueToValidate).Contains(@"|"))
            {
                string[] valuesToValidateSplitted = valueToValidate.ToString().Split('|');

                foreach (string valueToValidateSplitted in valuesToValidateSplitted)
                {
                    if (DateTime.TryParse(valueToValidateSplitted.ToString(), out parseValueToValidate))
                    {
                        addedMessages = false;
                    }
                    else
                    {
                        AddMessageException(fieldName, Resources.Resources.Resources.InvalidDataType);
                    }
                }
            }
            else
            {
                if (valueToValidate != null && DateTime.TryParse(valueToValidate.ToString(), out parseValueToValidate))
                {
                    addedMessages = false;
                }
                else
                {
                    AddMessageException(fieldName, Resources.Resources.Resources.InvalidDataType);
                }
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfValueToValidateNotInt(string fieldName, object valueToValidate)
        {
            bool addedMessages = true;
            int parseValueToValidate = 0;

            string[] values = valueToValidate.ToString().Split(',');

            foreach (string item in values)
            {
                if (int.TryParse(item, out parseValueToValidate))
                {
                    addedMessages = false;
                }
                else
                {
                    AddMessageException(fieldName, Resources.Resources.Resources.InvalidDataType);
                }
            }

            return addedMessages;
        }

        protected bool AddValidationMessageIfValueToValidateNotDouble(string fieldName, object valueToValidate)
        {
            bool addedMessages = true;
            double parseValueToValidate = 0;

            if (double.TryParse(valueToValidate.ToString(), out parseValueToValidate))
            {
                addedMessages = false;
            }
            else
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidDataType);
            }

            return addedMessages;
        }

        protected void ValidateMandatoryString(string fieldName, string valueToValidate)
        {
            if (string.IsNullOrEmpty(valueToValidate) || valueToValidate.Trim().Length == 0)
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidEmptyField);
            }
        }

        protected void ValidateBetweenDates(DatesBetweenToValidate datesBetweenToValidate)
        {
            if (!datesBetweenToValidate.IsAnual)
            {
                ValidateBetweenDatesByDays(datesBetweenToValidate);
            }
            else
            {
                ValidateBetweenDatesByMonth(datesBetweenToValidate);
            }
        }

        private void ValidateBetweenDatesByDays(DatesBetweenToValidate datesBetweenToValidate)
        {
            long daydiff = CrossCutting.DateTime.DateTimeDiff.DateDiffDay(datesBetweenToValidate.FechaInicio, datesBetweenToValidate.FechaFin);

            if (datesBetweenToValidate.FechaInicio > datesBetweenToValidate.FechaFin)
            {
                AddMessageException(datesBetweenToValidate.NombreCampo, Resources.Resources.Resources.InvalidBetweenDates);
            }
            else if (!datesBetweenToValidate.IsOnDemand && daydiff > datesBetweenToValidate.NumeroDias)
            {
                AddMessageException(datesBetweenToValidate.NombreCampo, datesBetweenToValidate.MensajeError);
            }
        }

        private void ValidateBetweenDatesByMonth(DatesBetweenToValidate datesBetweenToValidate)
        {
            long mesdiff = CrossCutting.DateTime.DateTimeDiff.DateDiffMonth(datesBetweenToValidate.FechaInicio, datesBetweenToValidate.FechaFin);

            if (datesBetweenToValidate.FechaInicio > datesBetweenToValidate.FechaFin)
            {
                AddMessageException(datesBetweenToValidate.NombreCampo, Resources.Resources.Resources.InvalidBetweenDates);
            }
            else if (mesdiff >= datesBetweenToValidate.NumeroMeses)
            {
                AddMessageException(datesBetweenToValidate.NombreCampo, datesBetweenToValidate.MensajeError);
            }
        }

        protected bool IsValidTime(object timeValue)
        {
            if (timeValue == null)
            {
                return false;
            }

            Regex checktime = new Regex(@"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$");

            return checktime.IsMatch(timeValue.ToString());
        }

        protected bool AddValidationTime(string fieldName, object valueToValidate)
        {
            bool addedMessages = true;

            if (IsValidTime(valueToValidate))
            {
                addedMessages = false;
            }
            else
            {
                AddMessageException(fieldName, Resources.Resources.Resources.InvalidValueTime);
            }

            return addedMessages;
        }
    }
}