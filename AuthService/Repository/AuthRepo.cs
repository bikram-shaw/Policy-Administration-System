using AuthService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthService.Repository
{
    public class AuthRepo
    {
        private readonly IConfiguration _config;
        // static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthRepo));
        private readonly IUserRepo _repo;

        public AuthRepo(IConfiguration config, IUserRepo repo)
        {
            _config = config;
            _repo = repo;
        }


        /// <summary>
        /// Finding User with matching credentials
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        public LoginCredentials AuthenticateUser(LoginCredentials cred)
        {
            // _log4net.Info("Validating the User!");

            //Validate the User Credentials 
            LoginCredentials user = _repo.GetUserCred(cred);

            return user;
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
