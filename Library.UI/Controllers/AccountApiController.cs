using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess;
using Library.DTO.User;
using Library.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Library.WebAPI.Controllers
{
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public AccountApiController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        [Route("UserLogin")]
        public async Task<ActionResult> UserLogin([FromBody] UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(request.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    HttpContext.Session.SetString(SessionKeyManager.Login, user.Id.ToString());
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                    var token = new JwtSecurityToken(
                        issuer: "http://google.com",
                        audience: "http://google.com",
                        expires: DateTime.UtcNow.AddHours(1),
                        claims: claims,
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else
                {
                    return BadRequest("Hatalı kullanıcı girişi yaptınız...");
                }
            }
            return BadRequest("Veriler uygun değil");
        }
    }
}
