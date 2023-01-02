using FluentValidation;
using WebApiTemplate.Services.Contract.Request;

namespace WebApiTemplate.Services.Validation
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Name can not be empty");

            RuleFor(x => x.UserEmail)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Email can not be empty");

            RuleFor(x => x.Role)
               .Cascade(CascadeMode.Stop)
               .IsInEnum()
               .WithMessage("Invalid role");
        }
    }
}
