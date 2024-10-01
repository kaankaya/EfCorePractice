using EdutPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace EdutPlatform.Data
{
    public class EduPlatformContext : DbContext
    {
        public EduPlatformContext(DbContextOptions<EduPlatformContext> options) : base(options)
        {
            
        }

        public DbSet<Course>  Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                         .HasOne(c => c.Instructor) //Course ın bir tane Instructoru vardır
                         .WithMany(i => i.Courses) //bir eğitmenden birden fazla course verebiliri
                         .HasForeignKey(c => c.InstructorId);
            modelBuilder.Entity<Enrollment>()
                        .HasOne(e => e.Student) //enrolment bir student olur
                        .WithMany(e => e.Enrollments) //birden fazla enrollment sahip olur
                        .HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<Enrollment>()
                        .HasOne(e => e.Course) //bir enrolment bir course eşit
                        .WithMany(c => c.Enrollments)
                        .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>()
                        .Property(c => c.Price) //hangi propertyde işlem yapacağımı belirttim.
                        .HasPrecision(18, 2); //decimal tanımladım precision ile 

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, FirstName = "A" , LastName = "B", Email ="a@hotmail.com" }
                );
        }
    }
}
