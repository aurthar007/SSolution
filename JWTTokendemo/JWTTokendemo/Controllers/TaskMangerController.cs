using JWTTokendemo.Data;
using JWTTokendemo.Data.Entities;
using JWTTokendemo.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTTokendemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskMangerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TaskMangerController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet("GetAllTaskList")]
        public IActionResult GetAll()
        {
            var tasks = _context.TaskManagers.Include(t => t.User).Include(t => t.Status)
                .Select(t => new TaskRequest
                {
                    Id = t.Id,
                    TaskName = t.TaskName,
                    FirstName = t.User.Firstname,
                    StatusName = t.Status.StatusName,
                    TaskDescription = t.TaskDescription,
                    UserId = t.User.Id,
                    StatusId = t.Status.Id,
                })
                .ToList();

            return Ok(tasks);
        }

        [HttpGet("GetAllTaskListByUserId/{id}")]
        public IActionResult GetAllTaskListByUserId(int id)
        {
            var tasks = _context.TaskManagers.Include(t => t.User).Include(t => t.Status).Where(x=>x.UserId == id)
                .Select(t => new TaskRequest
                {
                    Id = t.Id,
                    TaskName = t.TaskName,
                    FirstName = t.User.Firstname,
                    StatusName = t.Status.StatusName,
                    TaskDescription = t.TaskDescription,
                    UserId = t.User.Id,
                    StatusId = t.Status.Id,
                })
                .ToList();

            return Ok(tasks);
        }


        [HttpPost("AddTask")]
        public IActionResult AddTask(TaskRequest request)
        {
            
                var newTask = new TaskManager
                {
                    TaskName = request.TaskName,
                    TaskDescription=request.TaskDescription,
                    UserId = request.UserId,
                    StatusId = request.StatusId
                };

                _context.TaskManagers.Add(newTask);
                _context.SaveChanges();

                return Ok("Added new task successfully!");
            
        }
        [HttpPut("UpdateTask/{id}")]
        public IActionResult UpdateTask(int id, TaskRequest request)
        {
            var taskToUpdate = _context.TaskManagers.FirstOrDefault(t => t.Id == id);

            if (taskToUpdate == null)
            {
                return NotFound("Task not found!");
            }

            // Update properties of the task
            taskToUpdate.TaskName = request.TaskName;
            taskToUpdate.TaskDescription = request.TaskDescription;
            taskToUpdate.UserId = request.UserId;
            taskToUpdate.StatusId = request.StatusId;

            // Save changes to the database
            _context.TaskManagers.Update(taskToUpdate);
            _context.SaveChanges();

            return Ok("Task updated successfully!");
        }

        [HttpDelete("DeleteTask/{id}")]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _context.TaskManagers.FirstOrDefault(t => t.Id == id);

            if (taskToDelete == null)
            {
                return NotFound("Task not found!");
            }

            _context.TaskManagers.Remove(taskToDelete);
            _context.SaveChanges();

            return Ok("Task deleted successfully!");
        }







    }
}
