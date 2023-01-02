using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Services.Concrete;
using WebApiTemplate.Services.Contract.Request;
using WebApiTemplate.Services.Interfaces;
using WebApiTemplate.Services.Validation;

namespace WebApiTemplate.Services.Infrastructure
{
    public class ServiceBindings
    {
        /// <summary>
        /// Registers
        /// </summary>
        public static void Register(IServiceCollection services)
        {

            #region Services
            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Automaapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region Validators
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
            services.AddScoped<IValidator<UserLoginRequest>, UserLoginRequestValidator>();
            #endregion
        }
    }
}
