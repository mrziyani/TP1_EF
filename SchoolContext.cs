using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TP1_EF.Dto;
using TP1_EF.models;

namespace TP1_EF
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        // Mapped for SQL view and stored procedure
        public DbSet<TeacherSubjectViewModel> V_Teacher_Subject { get; set; }
        public DbSet<StudentDto> StudentDto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapping Fluent API from separate classes
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolContext).Assembly);

            // Mapping view
            modelBuilder.Entity<TeacherSubjectViewModel>()
                .HasNoKey()
                .ToView("V_Teacher_Subject");

            // Mapping stored procedure result (no key, no table)
            modelBuilder.Entity<StudentDto>()
                .HasNoKey();
        }
    }
}
