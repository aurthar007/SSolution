using System.ComponentModel.DataAnnotations;

namespace JWTTokendemo.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
          public string Name { get; set; }
    }
}
