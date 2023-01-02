using WebApiTemplate.Contracts.Models;

namespace WebApiTemplate.Contracts.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity);

        Task<User> GetUserbyEmailAsync(string email);

        Task<User> GetUserAsync(User entity);
    }
}
