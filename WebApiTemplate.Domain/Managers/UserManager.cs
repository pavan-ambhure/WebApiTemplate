using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiTemplate.Contracts.Enums;
using WebApiTemplate.Contracts.Interfaces.Managers;
using WebApiTemplate.Contracts.Interfaces.Repositories;
using WebApiTemplate.Contracts.Models;
using WebApiTemplate.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;
using System.Text.Json;
namespace WebApiTemplate.Domain.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private IMapper _mapper { get; }
        public UserManager(IConfiguration config,IUserRepository userRepository, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> CreateAsync(UserDTO UserDto)
        {
            var userEntity = _mapper.Map<User>(UserDto);

            var user = await _userRepository.GetUserbyEmailAsync(userEntity.UserEmail);
            if (user.UserEmail != "")
            {
                throw new ServiceException("User Exist with same email");
            }
            user = await _userRepository.CreateAsync(userEntity);
            return _mapper.Map<UserDTO>(UserDto);
        }

        public async Task<string> AuthenticateAsync(UserDTO UserDto)
        {

            var userEntity = _mapper.Map<User>(UserDto);

            var user = await _userRepository.GetUserAsync(userEntity);
            if (user == null)
            {
                throw new ServiceException("User not found");
            }
            var token = GenerateToken(user);
            return token;

        }

        // To generate token
        private string GenerateToken(User user)
        {
       
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(user)),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Role, Convert.ToString((UserRole)user.Role))
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
