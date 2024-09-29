using System.ComponentModel.DataAnnotations;

namespace CodeFirstBasic.Data.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Platform { get; set; }
        [Range(0,10)]
        public decimal Rating { get; set; }
    }
}
