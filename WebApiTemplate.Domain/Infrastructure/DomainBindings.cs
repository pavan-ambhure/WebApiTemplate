using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Contracts.Interfaces.Managers;
using WebApiTemplate.Domain.Managers;

namespace WebApiTemplate.Domain.Infrastructure
{
    public  class DomainBindings
    {
        /// <summary>
        /// Registers
        /// </summary>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();

          
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
