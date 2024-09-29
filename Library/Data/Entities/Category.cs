namespace Library.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; } //birden fazla kitaba sahip olabilir category
    }
}
