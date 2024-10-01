namespace InterMediateTablePractic.Data.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //Dersin alındığı Öğrencilerin listesi
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
