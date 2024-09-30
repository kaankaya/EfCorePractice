using System.ComponentModel.DataAnnotations;

namespace RelationalPractice.Data.Entities
{
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int AuthorId { get; set; }

        //Her kitap sadece bir yazar tarafından yazılmıştır
        public AuthorEntity Author { get; set; }
    }
}
