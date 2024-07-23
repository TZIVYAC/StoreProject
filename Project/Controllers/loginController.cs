using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MODELS.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public struct Login
{
    public string Mail { get; set; }
    public string Id { get; set; }
    public Login(string mail, string id)
    {
        Mail = mail;
        Id = id;
    }
}

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICostumerService _costumer;

        public LoginController(IConfiguration config, ICostumerService costumer)
        {
            _config = config;
            _costumer = costumer;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login loginRequest)
        {
            var costumerFind = await _costumer.GetCostumerById(loginRequest.Id);

            if (costumerFind != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, costumerFind.Id),
                };

                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Issuer"],
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

                return Ok(new { token });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
