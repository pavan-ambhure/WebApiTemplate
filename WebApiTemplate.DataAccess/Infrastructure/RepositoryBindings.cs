using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Contracts.Interfaces.Repositories;
using WebApiTemplate.DataAccess.Concrete;
using WebApiTemplate.DataAccess.Configuration;

namespace WebApiTemplate.DataAccess.Infrastructure
{
    public static class RepositoryBindings
    {
        /// <summary>
        /// Registers
        /// </summary>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<WebApiDBContext>();

        }
    }
}
