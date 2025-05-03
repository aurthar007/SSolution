using JWTTokendemo.Data.Entities;

namespace JWTTokendemo.DTO
{
    public class TaskRequest
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string FirstName { get; set; }
        public string StatusName { get; set; }
        public string TaskDescription { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

    }
}
