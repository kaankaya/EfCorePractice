using System.ComponentModel.DataAnnotations.Schema;

namespace EdutPlatform.Models
{
    public class Enrollment :BaseModel<int>
    {
        //hangi student aldı
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        //hangi course

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
