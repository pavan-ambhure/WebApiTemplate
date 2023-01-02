using WebApiTemplate.Contracts.Models.DTOs;

namespace WebApiTemplate.Contracts.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<UserDTO> CreateAsync(UserDTO UserDto);

        Task<string> AuthenticateAsync(UserDTO UserDto);
    }
}
