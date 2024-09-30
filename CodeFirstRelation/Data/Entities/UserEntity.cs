using System.ComponentModel.DataAnnotations;

namespace CodeFirstRelation.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        public List<PostEntity> Posts { get; set; } //bir kullanıcının birden fazla yazısı olabilir
    }
}
