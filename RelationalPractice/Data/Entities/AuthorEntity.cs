using System.ComponentModel.DataAnnotations;

namespace RelationalPractice.Data.Entities
{
    public class AuthorEntity
    {
        [Key]
        public int Id { get; set; } //benzersiz kimliği
        [Required]
        [StringLength(70)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(80)]
        public string LastName { get; set; }

        //bir yazarın birden fazla kitabı olabilir
        public List<BookEntity> Books { get; set; }
    }
}
