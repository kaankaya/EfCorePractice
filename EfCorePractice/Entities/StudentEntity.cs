using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.Entities
{
    public class StudentEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
