using JWTTokendemo.Data;
using JWTTokendemo.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JWTTokendemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
                return Ok("Add Role succesfully!");
            }
            catch (Exception)
            {
                return Ok("Error while add role");
            }
            
        }

        [HttpPut("UpdateRole/{id}")]
        public IActionResult UpdateRole(Role role)
        {
            try
            {
                _context.Roles.Update(role);
                _context.SaveChanges();
                return Ok("Updated Role succesfully!");
            }
            catch (Exception)
            {
                return Ok("Error while updating role");
            }

        }
        [HttpDelete("DeleteRole/{id}")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                var role = _context.Roles.Find(id);
                _context.Roles.Remove(role);
                _context.SaveChanges();
                return Ok("Deleted Role succesfully!");
            }
            catch (Exception)
            {
                return Ok("Error while Deleting role");
            }

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_context.Roles.ToList());
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
