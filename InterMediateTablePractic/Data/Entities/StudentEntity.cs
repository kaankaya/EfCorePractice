namespace InterMediateTablePractic.Data.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Öğrencinin aldığı Derslerin Listesi
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
