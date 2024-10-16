using BussinessObject.UpdateModel;
using DataAccessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using Service.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BussinessObject.ViewModel;

namespace Asignment01_02_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountService service = new AccountService();
        public AccountController()
        {
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await service.Login(email,password);
            if (result.Status == 200)
            {
                string role = "Lecturer";
                if(((SystemAccount)result.Data).AccountRole == 1)
                {
                    role = "Staf";
                }
                else if(((SystemAccount)result.Data).AccountRole == 3)
                {
                    role = "Admin";
                }
                var token = GenerateJwtToken(email, role);
                result.Data = new AccountView
                {
                    AccountId = ((SystemAccount)result.Data).AccountId,
                    Token = token
                };
                return Ok(result);
            }
            else return BadRequest(result);
        }
        private string GenerateJwtToken(string email,string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("GZGrzxj6a0G+hO2Fy6K3+n5UzO/GByYhPZ1T3vxA7Zs="));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: "ArticleIssuer",
                audience: "ArticleAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            var result = await service.Register(email, password);
            if (result.Status == 200)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string email, string password, int role)
        {
            var result = await service.CreateAccount(email, password,role);
            if (result.Status == 200)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
        [Authorize(Roles = "Staf")]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(AccountUpdate key)
        {
            var result = await service.UpdateAccount(key);
            if (result.Status == 200)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
