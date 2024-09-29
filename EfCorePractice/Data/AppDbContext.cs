using EfCorePractice.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; } //dbset tanımından sonra İsimlendirme çoğul takısı eklememiz gerekiyor.Student ise Students olması gerekiyor

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PatikaFirstDb;Trusted_Connection=true;TrustServerCertificate=true");
        }
    }
}
