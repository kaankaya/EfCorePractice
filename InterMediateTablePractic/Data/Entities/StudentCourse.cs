namespace InterMediateTablePractic.Data.Entities
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }

        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }
}
