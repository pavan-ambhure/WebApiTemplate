using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Services.Contract.Request;

namespace WebApiTemplate.Services.Validation
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(x => x.UserName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Name can not be empty");

            RuleFor(x => x.Password)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Password can not be empty");
        }
    }
}
