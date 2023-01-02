using FluentValidation.Results;
using System.Text;
using WebApiTemplate.Domain.Errors;

namespace WebApiTemplate.Services.Helper
{
    internal class ValidationHelper
    {
        internal static void CheckValidationResult(ValidationResult validationResult)
        {
            if (validationResult.IsValid == false)
            {
                var errormessages = new StringBuilder("");
                foreach (var error in validationResult.Errors)
                {
                    if (errormessages.Length > 0)
                    {
                        errormessages.Append(" | ");
                    }
                    errormessages.Append(error.ErrorMessage);
                }
                throw new ServiceException(errormessages.ToString());
            }
        }
    }
}
