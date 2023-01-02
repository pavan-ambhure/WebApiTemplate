using WebApiTemplate.Services.Contract.Request;
using WebApiTemplate.Services.Contract.Response;

namespace WebApiTemplate.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUserAsync(CreateUserRequest createUser);
        Task<string> AuthenticateAsync(UserLoginRequest userLogin);
    }
}
