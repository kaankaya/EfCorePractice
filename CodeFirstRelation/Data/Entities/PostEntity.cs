using System.ComponentModel.DataAnnotations;

namespace CodeFirstRelation.Data.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Title { get; set; }
        [Required]
        [StringLength(600)]
        public string Content { get; set; }
        public int UserId { get; set; } //Bir Kullanıcının birden fazla yazısı olabilir
        public UserEntity User { get; set; }  //bir yazının bir kullanıcısı olur
    }
}
