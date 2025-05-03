using System.ComponentModel.DataAnnotations;

namespace JWTTokendemo.Data.Entities
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        public int  UserId { get; set; }
        public int CountryId {  get; set; }
        public int StateId {  get; set; }   
        public int DistrictId {  get; set; }
        public string Experience {  get; set; }
        public  decimal Salary {  get; set; }
        public string ImageName {  get; set; }
        public string KeySkills {  get; set; }


    }
}
