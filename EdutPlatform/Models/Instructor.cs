using System.ComponentModel.DataAnnotations;

namespace EdutPlatform.Models
{
    public class Instructor :BaseModel<int>
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        //hangi dersleri veriyor

        public List<Course> Courses { get; set; }


    }
}
