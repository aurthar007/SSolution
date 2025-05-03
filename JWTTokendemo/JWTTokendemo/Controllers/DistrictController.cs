using JWTTokendemo.Data;
using JWTTokendemo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace JWTTokendemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DistrictController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/District/AddDistrict
        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(District district)
        {
            // Validate the district model before adding
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Districts.Add(district);
            _context.SaveChanges();
            return Ok("District added successfully!");
        }

        // GET: api/District/GetAllDistricts
        [HttpGet("GetAllDistricts")]
        public IActionResult GetAllDistricts()
        {
            var districts = _context.Districts
                .Select(d => new
                {
                    Id = d.Id,
                    Name = d.Name,
                    StateName = _context.States
                        .Where(s => s.Id == d.StateId)
                        .Select(s => s.Name)
                        .FirstOrDefault(),
                    CountryName = _context.Countries
                        .Where(c => c.Id == d.CountryId)
                        .Select(c => c.Name)
                        .FirstOrDefault()
                })
                .ToList();

            return Ok(districts);
        }

        // PUT: api/District/UpdateDistrict/{id}
        [HttpPut("UpdateDistrict/{id}")]
        public IActionResult UpdateDistrict(int id, District updatedDistrict)
        {
            // Check if the district exists in the database
            var district = _context.Districts.FirstOrDefault(d => d.Id == id);
            if (district == null)
                return NotFound("District not found.");

            // Update the district fields
            district.Name = updatedDistrict.Name;
            district.CountryId = updatedDistrict.CountryId;
            district.StateId = updatedDistrict.StateId;

            _context.SaveChanges();

            return Ok("District updated successfully!");
        }

        // DELETE: api/District/DeleteDistrict/{id}
        [HttpDelete("DeleteDistrict/{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            var district = _context.Districts.FirstOrDefault(d => d.Id == id);
            if (district == null)
                return NotFound("District not found.");

            _context.Districts.Remove(district);
            _context.SaveChanges();

            return Ok("District deleted successfully!");
        }
    }
}
