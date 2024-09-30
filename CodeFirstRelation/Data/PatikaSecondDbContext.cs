using CodeFirstRelation.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstRelation.Data
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CodeFirstDb2;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ilişkileri tanımlıyalım
            modelBuilder.Entity<PostEntity>()   //foreignkey tanımlıyı yeri modelbuilder aldık
                        .HasOne(p => p.User) //bir yazının bir kullanıcısı olur hasone ile tanımladık
                        .WithMany(p => p.Posts) //bir kullanıcının birden fazla yazısı olabilir
                        .HasForeignKey(p => p.UserId); //foreign key imiz UserId
        }
    }
}
