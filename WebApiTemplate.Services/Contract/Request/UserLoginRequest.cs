namespace WebApiTemplate.Services.Contract.Request
{
    public class UserLoginRequest
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
