using ASPNetMVCTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetMVCTesting.Services
{
    public class Database : DbContext
    {
        public DbSet<Course> Courses { get; private set; }
        public DbSet<Exam> Exams { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptBuilder)
        {
            OptBuilder.UseSqlite(@"Data Source=..\..\..\mydb.db;");
        }

        protected override void OnModelCreating(ModelBuilder ModBuilder)
        {
            ModBuilder.Entity<Course>().ToTable("Courses").HasKey(course => course.ID);
            ModBuilder.Entity<Exam>().ToTable("Exams").HasKey(exam => exam.ID);

            ModBuilder.Entity<Exam>()
            .HasOne(exam => exam.Course)
            .WithMany(course => course.Exams);
        }



    }
}