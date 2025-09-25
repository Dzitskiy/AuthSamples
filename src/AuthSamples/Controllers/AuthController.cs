using AuthSamples.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthSamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<bool> Login(AuthDto dto)
        {
            //TODO: Find user in DB
            // If user not found -> Registration
            // If user found -> Login
                       

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, dto.Login));
            claims.Add(new Claim(ClaimTypes.Email, "mail@mail.ru"));
            claims.Add(new Claim(ClaimTypes.Role, dto.Login));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            return true;
        }

        [HttpPost]
        [Route("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);  
        }
    }
}
