using System.ComponentModel.DataAnnotations;

namespace JWTTokendemo.Data.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
