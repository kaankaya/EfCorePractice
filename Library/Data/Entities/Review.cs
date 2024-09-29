using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        [ForeignKey(nameof(BookId))]  //burada Sen artık bir foreign key sin ve bookId senin hangi kitap oldugnu belirtiyor
        public Book Book { get; set; }
    }
}
