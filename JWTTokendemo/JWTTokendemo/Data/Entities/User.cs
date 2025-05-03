using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JWTTokendemo.Data.Entities
{
    [Index(nameof(Email), Name = "IX_Unique_Email", IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
       [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; }
        public string  Lastname { get; set; }

        [Required(ErrorMessage = "Password is required.")]
         public string Password { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [MaxLength(10, ErrorMessage = "Mobile number can't exceed 20 characters.")]
        [Phone(ErrorMessage = "Invalid Mobile number format.")]
        public string Mobile { get; set; }
    }
}
