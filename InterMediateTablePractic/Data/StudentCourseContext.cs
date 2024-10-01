using InterMediateTablePractic.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterMediateTablePractic.Data
{
    public class StudentCourseContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ara Tablo Tanımı
            modelBuilder.Entity<StudentCourse>()
                        .HasKey(sc => new { sc.StudentId, sc.CourseId }); //Birincil anahtar olarak iki sütun
        }
    }
}
