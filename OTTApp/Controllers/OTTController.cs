using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTTApp.Models;
using OTTApp.Respo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
namespace OTTApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTTController : ControllerBase
    {
        [Authorize]
        [Route("GetList")]
        [HttpGet]
        public List<MovieList> getlist()
        {
            return OTT_DataAccess.getList();
        }
        [Authorize]
        [Route("GetListByType")]
        [HttpPost]
        public List<MovieList> getlistbyTye(GetListReq getList)
        {
            return OTT_DataAccess.getListByType(getList);
        }

        [Route("AddMovies")]
        [HttpPost]
        public string AddMovies(MovieListReq movieListReq )
        {
            return OTT_DataAccess.insertMovies(movieListReq);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginReq loginReq)
        { 
            bool IsTrue = OTT_DataAccess.CheckUserDetails(loginReq);
            if (IsTrue)
            {
                var token = GenerateToken(loginReq.Username);
                return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else {
                return Unauthorized("Invalid Credentials");
            }
        }
        [Authorize]
        [HttpGet("getusername")]
        public string getusername()
        {
            string username = User.FindFirst(ClaimTypes.Name)?.Value.ToString();

            return "Welcome back " + username;
        }

        private JwtSecurityToken GenerateToken(string username)
        {
            var claims = new List<Claim>
            { 
                new Claim(ClaimTypes.Name, username), 
            };
            var token = new JwtSecurityToken(
                issuer:"",
                audience : "",
                claims : claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hvkjhkjhxkj5644645645frrhgfh5y456546hvkuhxcuk")),  SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }

}
