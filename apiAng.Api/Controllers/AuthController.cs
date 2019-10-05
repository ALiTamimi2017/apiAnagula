using apiAng.Api.Data;
using Microsoft.AspNetCore.Mvc;
using apiAng.Api.Model;
using System.Threading.Tasks;
using apiAng.Api.DTO;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace apiAng.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public IAuthRepository _Repository { get; }

        public IConfiguration _conf { get; }
        public AuthController(IAuthRepository _Repository, IConfiguration _conf)
        {
            this._Repository = _Repository;
            this._conf = _conf;

        }




        [HttpPost("register")]

        public async Task<IActionResult> register(UserRegisterDto model)
        {

            model.UserName = model.UserName.ToLower();
           if (await _Repository.UserExsit(model.UserName))
             {
             return BadRequest("کاربری با این نام موجود می باشد ");

            }

            var add = new User
            {
                Name = model.UserName
            };
            var creatUser = await _Repository.Register(add, model.Password);

            return StatusCode(201);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDTO model)
        {
            var loginUser = await _Repository.Login(model.UserName.ToLower(), model.Passwrod);
            if (loginUser == null)
            {
                return Unauthorized();
            }
            var claims = new[]{
                    new Claim(ClaimTypes.NameIdentifier,loginUser.id.ToString()),
                    new Claim(ClaimTypes.Name, loginUser.Name)
        };
            var Kay = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf.GetSection("AppSettings:Token").Value));
            var Card = new SigningCredentials(Kay, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesctions = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = Card
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = TokenHandler.CreateToken(tokenDesctions);
            return Ok(new
            {
                Token = TokenHandler.WriteToken(Token)
            });

        }
    }
}