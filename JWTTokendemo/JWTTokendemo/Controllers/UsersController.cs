using JWTTokendemo.Data;
using JWTTokendemo.Data.Entities;
using JWTTokendemo.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTTokendemo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var exists = _context.Users.Any(x=>x.Email == user.Email);
            if(exists)
            {
                return Ok("duplicate");
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("User registered succesfully!");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest login)
        {
            var userData = _context.Users.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if (userData == null)
                return Ok(new { token = "", name = "", role = "", success = "400" });
            
            var userRole = _context.UserRoles.FirstOrDefault(x=>x.UserId == userData.Id);

            if (userRole == null)
                return Ok(new { token = "", name = "", role = "", success = "401" });

            var role = _context.Roles.Find(userRole.RoleId).Name;

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: null,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:ExpiresInHours"])),
                signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = jwt, user = userData, role = role, success = "200" });
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAll()
        {
            var users = _context.Users.Select(u => new {u.Id,u.Email,u.Firstname}).ToList();
            //var users = _context.Users.ToList();
            //List<UserDdlResponse> response = new List<UserDdlResponse>();
            //foreach (var user in users)
            //{
            //    UserDdlResponse userDdl = new UserDdlResponse();
            //    userDdl.Id = user.Id;
            //    userDdl.Email = user.Email;
            //    response.Add(userDdl);
            //}
            return Ok(users);
        }

    }
}