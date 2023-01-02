using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Services.Contract.Request;
using WebApiTemplate.Services.Contract.Response;
using WebApiTemplate.Services.Interfaces;

namespace WebApiTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = null!;

        /// <summary>
        /// Constructor that initializes anything needed by the class controller
        /// </summary>
        /// <param name="programService">Business logic for rank injected.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateUserRequest createUser)
        {
            var result = await _userService.CreateUserAsync(createUser);
            return Ok(result);
        }

        [AllowAnonymous]
        /// <summary>
        /// Login user and return token.
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ContentResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest userLogin)
        {
            var result = await _userService.AuthenticateAsync(userLogin);
            return Ok(result);
            
          
        }
    }
}
