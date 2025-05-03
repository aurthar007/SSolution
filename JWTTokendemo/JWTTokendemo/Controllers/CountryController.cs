using JWTTokendemo.Data.Entities;
using JWTTokendemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JWTTokendemo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddCountry")]
        public IActionResult AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return Ok("Add Country succesfully!");
        }
        
        [HttpGet("GetAllCountry")]
        public IActionResult Countries()
        {
            return Ok(_context.Countries.ToList());
        }
        [HttpPut("UpdateCountry/{id}")]
        public IActionResult UpdateCountry(int id, Country updatedCountry)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound("Country not found.");
            }

            country.Name = updatedCountry.Name;
            _context.SaveChanges();

            return Ok("Country updated successfully!");
        }
        [HttpDelete("DeleteCountry/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound("Country not found.");
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();

            return Ok("Country deleted successfully!");
        }

    }
}
