using AuthSamples.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AuthSamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestAuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("AnonymousMethod")]
        public JsonResult AnonymousMethod()
        {
            return new JsonResult("Anonymous method");
        }

        [Authorize]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin,Moderator")]
        [HttpPost("RequiringAuthMethod")]
        public JsonResult RequiringAuthMethod()
        {
            return new JsonResult("RequiringAuthMethod");
        }

        //[Authorize]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin,Moderator")]
        [Authorize("AdminOnly")]
        [HttpPost("RequiringAdminMethod")]
        public JsonResult RequiringAdminMethod()
        {
            return new JsonResult("RequiringAdminMethod");
        }

        [HttpPost("GetUserInfoMethod")]
        public UserDto GetUserInfoMethod()
        {

            return new UserDto
            {
                Scheme = HttpContext?.User?.Identity?.AuthenticationType,
                IsAuthenticated = HttpContext?.User?.Identity?.IsAuthenticated ?? false,
                Claims = HttpContext?.User?.Claims.Select(c => new { c.Type, c.Value }).ToList<object>() ?? new List<object>()
            };
        }
    }
}