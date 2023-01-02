using AutoMapper;
using FluentValidation;
using Microsoft.VisualBasic;
using WebApiTemplate.Contracts.Interfaces.Managers;
using WebApiTemplate.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;
using WebApiTemplate.Services.Contract.Request;
using WebApiTemplate.Services.Contract.Response;
using WebApiTemplate.Services.Helper;
using WebApiTemplate.Services.Interfaces;

namespace WebApiTemplate.Services.Concrete
{
    /// <summary>
    /// Service layer will validate the request/response
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager = null!;
        private readonly IValidator<CreateUserRequest> _createUserRequestValidator;
        private readonly IValidator<UserLoginRequest> _userLoginRequestValidator;
        private IMapper _mapper { get;}
        public UserService(IUserManager userManager, IMapper mapper,
            IValidator<CreateUserRequest> createUserRequestValidator,
            IValidator<UserLoginRequest> userLoginRequestValidator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _createUserRequestValidator = createUserRequestValidator;
            _userLoginRequestValidator= userLoginRequestValidator;

        }
        public async Task<UserResponse> CreateUserAsync(CreateUserRequest createUser)
        {
            if (createUser == null)
            {               
                throw new ServiceException("Empty request");
            }
            var validationResult = await _createUserRequestValidator.ValidateAsync(createUser);
            ValidationHelper.CheckValidationResult(validationResult);
            var userDto = _mapper.Map<UserDTO>(createUser);
            userDto = await _userManager.CreateAsync(userDto);
            return _mapper.Map<UserResponse>(userDto);
        }

        public async Task<string> AuthenticateAsync(UserLoginRequest userLogin)
        {

            if (userLogin == null)
            {
                throw new ServiceException("Empty request");
            }
            var validationResult = await _userLoginRequestValidator.ValidateAsync(userLogin);
            ValidationHelper.CheckValidationResult(validationResult);
            var userDto = _mapper.Map<UserDTO>(userLogin);
            var token = await _userManager.AuthenticateAsync(userDto);
            return token;


        }
    }
}
