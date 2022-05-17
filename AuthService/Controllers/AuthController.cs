using AuthService.Models;
using AuthService.Repository;
using AuthService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserService userService;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        public AuthController(IUserService userService)
        {
           
            this.userService = userService;
        }


        /// <summary>
        /// Post method for Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Login([FromBody] LoginCredentials login)
        {
            
            
          
            _log4net.Info("Login initiated!");
            IActionResult response = Unauthorized();

            var user = userService.AuthenticateUser(login);
            if (user == null)
            {
                return Unauthorized(new CustomResponse(401, "Invalid Credential"));
            }
            else
            {
                var tokenString = userService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        /// <summary>
        /// Authenticate Request
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Authenticate()
        {
            return Ok(true);
        }



    }
}
