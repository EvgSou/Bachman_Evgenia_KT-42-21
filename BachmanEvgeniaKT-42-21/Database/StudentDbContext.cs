using BachmanEvgeniaKT_42_21.Database.Configurations;
using BachmanEvgeniaKT_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace BachmanEvgeniaKT_42_21.Database
{
    public class StudentDbContext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
        {
        
        }
    }
}
