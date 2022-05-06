using AuthService.Data.Entities;
using AuthService.Models;
using AuthService.Models;
using AuthService.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthService.Service
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepo repo;

        public UserService(IConfiguration config, IUserRepo repo)
        {
            _config = config;
            this.repo = repo;
        }

        public LoginCredentials AuthenticateUser(LoginCredentials cred)
        {
            User user = repo.GetUserCred(new User() { Username=cred.Username,Password=cred.Password});
            if (user != null)
                return cred;
            else
                return null;
        }
        public string GenerateJSONWebToken(LoginCredentials userInfo)
        {
            //_log4net.Info("Token Is Generated!");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);


        }

    }

    
}

