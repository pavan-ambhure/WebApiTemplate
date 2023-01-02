using WebApiTemplate.Contracts.Enums;

namespace WebApiTemplate.Services.Contract.Request
{
    public class CreateUserRequest
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// User email
        /// </summary>
        public string UserEmail { get; set; } = string.Empty;

        /// <summary>
        /// User Role
        /// </summary>
        public UserRole Role { get; set; }

    }
}
