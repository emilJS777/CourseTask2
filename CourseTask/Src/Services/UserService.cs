using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using CourseTask.Src.Models;
using CourseTask.Src.Repositories;
using CourseTask.Src.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace CourseTask.Src.Services
{
	public class UserService : IUserService
	{
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
		public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
		{
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
		}

        // To generate token
        private string GenerateToken(string id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id),
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private string ValidationAddress(string address)
        {
            var changedAddress = address
            .Replace("Avenue No", "AVE")
            .Replace("Avenue No.", "AVE")
            .Replace("No.", "")
            .Replace(".", "")
            .Replace("Number", "")
            .Replace("Boulevard", "BLVD")
            .Replace("Street", "ST")
            .Replace("Circle", "CIR")
            .Replace("#", "")
            .ToUpper();
            var regex = new Regex(@"\s+");
            changedAddress = regex.Replace(changedAddress, " ").Trim();
            return changedAddress;
        }

        public bool? Create(RegistrationViewModel registrationViewModel)
        {
            var user = userRepository.Get(registrationViewModel.UserName);
            if (user != null)
                return false;

            registrationViewModel.Profile.Address = ValidationAddress(registrationViewModel.Profile.Address);
            userRepository.Create(mapper.Map<UserModel>(registrationViewModel));
            return true;
        }

        public bool? Delete(int id)
        {
            var user = userRepository.Get(id);
            if (user == null)
                return null;
            userRepository.Delete(user);
            return true;
        }

        public UserViewModel? Get(int id)
        {
            var user = userRepository.Get(id);
            if (user == null)
                return null;
            return mapper.Map<UserViewModel>(user);
        }

        public List<UserViewModel> Get()
        {
            List<UserModel> users = userRepository.Get();
            return mapper.Map<List<UserViewModel>>(users);
        }

        public bool? Update(int id, RegistrationViewModel registrationViewModel)
        {
            var user = userRepository.Get(id);
            if (user == null)
                return null;
            if (userRepository.GetByNameExcludeId(registrationViewModel.UserName, id) != null)
                return false;

            registrationViewModel.Profile.Address = ValidationAddress(registrationViewModel.Profile.Address);
            userRepository.Update(mapper.Map(registrationViewModel, user));
            return true;
        }

        public string? Login(LoginViewModel loginViewModel)
        {
            var user = userRepository.Get(loginViewModel.UserName);
            if (user == null || BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.PasswordHash) == false)
                return null;

            var token = GenerateToken(user.Id.ToString());
            return token;
        }
    }
}

