using System.ComponentModel.DataAnnotations;

namespace EdutPlatform.Models
{
    public class Student : BaseModel<int>
    {
        [StringLength(150)]
        public string FullName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime DateofBirth { get; set; }

        //hangi derslere enrollment

        public List<Enrollment> Enrollments { get; set; }
    }
}
