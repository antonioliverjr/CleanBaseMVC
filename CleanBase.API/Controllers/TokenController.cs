using CleanBase.API.ViewModels;
using CleanBase.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;
        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("LoginUser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginInput loginInput)
        {
            var result = await _authenticate.Authenticate(loginInput.Email, loginInput.Password);
            if (result)
            {
                return GenerateToken(loginInput);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Dados de Login invalidos.");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerateToken(LoginInput loginInput)
        {
            var claims = new[]
            {
                new Claim("email", loginInput.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:SecretKey").Value));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(5);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.GetSection("JWT:issuer").Value,
                audience: _configuration.GetSection("JWT:audience").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new UserToken() { Token = new JwtSecurityTokenHandler().WriteToken(token), Expiration = expiration };
        }
    }
}
