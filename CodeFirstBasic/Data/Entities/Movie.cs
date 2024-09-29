using System.ComponentModel.DataAnnotations;

namespace CodeFirstBasic.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
