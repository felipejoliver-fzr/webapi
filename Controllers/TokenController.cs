using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("webapi/[Controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken ([FromBody] Funcionario request)
        {
            //nesse if devo criar a validacao com o banco
            if(request.Email == "email1@email.com" && request.Senha == "12345")
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, request.Nome)
                    //new Claim(ClaimTypes.Role, "Administrador")
                };

                var key = new SymmetricSecurityKey (
                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken (
                    issuer: "teste",
                    audience: "teste",
                    claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                    signingCredentials:creds
                );

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            } else{
                return BadRequest("Credenciais inválidas...");
            }
        }
    }
}