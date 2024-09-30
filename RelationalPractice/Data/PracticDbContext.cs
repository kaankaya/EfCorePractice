using Microsoft.EntityFrameworkCore;
using RelationalPractice.Data.Entities;

namespace RelationalPractice.Data
{
    public class PracticDbContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PracticRelation;Trusted_Connection=true;TrustServerCertificate=true"); //connectionString
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //İlişkileri tanımlama
            //Model builder i BookEntity Üzerinden yapıyoruz çünkü,Foreign Key Tanımlaması BookEntity içerisinde
            modelBuilder.Entity<BookEntity>()
                        .HasOne(b => b.Author) // her kitabın bir yazarı var o yüzden has one
                        .WithMany(b => b.Books) //Bir yazarın birden fazla kitabı olabilir WithMany
                        .HasForeignKey(b => b.AuthorId); //Kitapların yazarı AuthorId İle Belirlenir.

            //Tablo ve Property isimlendirmelerini Uygun yaparsanız yukarıdaki kodu yazmaasınız bile güncel entityFrameworkCore teknolojisi bağlantıyı yapacaktır.
        }
    }
}
