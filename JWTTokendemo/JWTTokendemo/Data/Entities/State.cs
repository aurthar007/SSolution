using System.ComponentModel.DataAnnotations;

namespace JWTTokendemo.Data.Entities
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public int CountryId {  get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
