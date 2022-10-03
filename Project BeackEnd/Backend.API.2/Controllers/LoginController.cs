using Backend.API._2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.API._2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.API._2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Authantification endpoint
        /// </summary>
        /// <remarks>
        /// Check all existings user information. 
        /// If exists a user with identical <b>username</b> and <b>password</b> - create the <code>JWT Token</code>.
        /// Introduce data by the example bellow.
        /// <br/><b>Login Example:</b>
        /// 
        ///     {
        ///         "userLogin": "Introduce Login",
        ///         "userPassword": "Introduce Password"
        ///     }
        ///
        /// </remarks>
        /// <response code = "200">Successfully token creation!</response>
        /// <response code = "404">User are not found! May be <code>Username</code> or <code>Password</code> are wrong! <br/>Token deconstructed!</response>
        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Login([FromBody] UserModel userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found!");
        }

        private object Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserLogin)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], 
                _config["Jwt:Audience"],
                claims,
                /*expires: DateTime.Now.AddMinutes(10),*/
                signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserModel userLogin)
        {
            var currentUser = Users.users.FirstOrDefault(o =>
            o.UserLogin.ToLower() == userLogin.UserLogin.ToLower() && o.UserPassword == userLogin.UserPassword);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        /*TOKEN: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IlVyYXJhayIsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcwMjI7aHR0cDovL2xvY2FsaG9zdDo1MDIyIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAyMjtodHRwOi8vbG9jYWxob3N0OjUwMjIifQ.r2Ml-0Wf-cNTJLNW9jJ1mEIPYwYfspo8Tz9owkxY5KA*/

    }
}
