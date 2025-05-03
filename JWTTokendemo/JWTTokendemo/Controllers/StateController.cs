using JWTTokendemo.Data;
using JWTTokendemo.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JWTTokendemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/State/AddState
        [HttpPost("AddState")]
        public IActionResult AddState(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return Ok("State added successfully!");
        }

        // GET: api/State/GetAllStates
        
        [HttpGet("GetAllStates")]
        public IActionResult GetAllStates()
        {
            var states = _context.States
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    CountryName = _context.Countries
                        .Where(c => c.Id == s.CountryId)
                        .Select(c => c.Name)
                        .FirstOrDefault()
                })
                .ToList();

            return Ok(states);
        }


        // PUT: api/State/UpdateState/{id}
        [HttpPut("UpdateState/{id}")]
        public IActionResult UpdateState(int id, State updatedState)
        {
            var state = _context.States.FirstOrDefault(s => s.Id == id);
            if (state == null)
                return NotFound("State not found.");

            state.Name = updatedState.Name;
            state.CountryId = updatedState.CountryId; // assuming you have a CountryId foreign key
            _context.SaveChanges();

            return Ok("State updated successfully!");
        }

        // DELETE: api/State/DeleteState/{id}
        [HttpDelete("DeleteState/{id}")]
        public IActionResult DeleteState(int id)
        {
            var state = _context.States.FirstOrDefault(s => s.Id == id);
            if (state == null)
                return NotFound("State not found.");

            _context.States.Remove(state);
            _context.SaveChanges();

            return Ok("State deleted successfully!");
        }
    }
}
