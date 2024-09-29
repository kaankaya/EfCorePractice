using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {

        public LibraryContext (DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        public DbSet<Book>  Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.Title).IsRequired().HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PublicationYear).HasColumnName("Year");


                entity.HasMany(e=> e.Reviews)
                      .WithOne(e=>e.Book)
                      .HasForeignKey(e=>e.BookId)
                      .OnDelete(DeleteBehavior.Cascade); //kitabım silindiğinde buna ait reviewler temizlenecektir.

                entity.HasOne(e => e.Detail)
                      .WithOne(e => e.Book)
                      .HasForeignKey<BookDetail>(e => e.BookId);

                entity.HasMany(e => e.Authors)
                      .WithMany(e => e.Books)
                      .UsingEntity(e => e.ToTable("BookAuthors"));

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(e => e.Books)
                      .WithOne(e => e.Category)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews");
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.ReviewerName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Rating).HasColumnName("Stars");
            });


        }
    }
}
