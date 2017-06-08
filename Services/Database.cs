using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetMVCTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetMVCTesting.Services
{
    public class Database : DbContext, ICoursesService, IExamsService
    {
        public DbSet<Course> Courses { get; private set; }
        public DbSet<Exam> Exams { get; private set; }

        public async Task CreateNewCourse(Course course)
        {
            Courses.Add(course);
            await SaveChangesAsync();
        }

        public async Task<Exam> GetExamFromID(int ID)
        {
            return await Exams
            .Include(exam => exam.Course)
            .Where(exam => exam.ID == ID)
            .SingleAsync();
        }

        public async Task<IEnumerable<Course>> List()
        {
            return await Courses.Include(course => course.Exams).ToListAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder OptBuilder)
        {
            OptBuilder.UseSqlite(@"Data Source=..\..\..\mydb.db;");
        }

        protected override void OnModelCreating(ModelBuilder ModBuilder)
        {
            ModBuilder.Entity<Course>().ToTable("Courses").HasKey(course => course.ID);
            ModBuilder.Entity<Exam>().ToTable("Exams").HasKey(exam => exam.ID);
            ModBuilder.Entity<Student>().ToTable("Students").HasKey(student => student.StudentNumber);
            ModBuilder.Entity<Registration>().ToTable("Registrations").HasKey(registration => registration.ID);

            ModBuilder.Entity<Exam>()
            .HasOne(exam => exam.Course)
            .WithMany(course => course.Exams)
            .IsRequired();

            ModBuilder.Entity<Exam>()
            .HasMany(exam => exam.AllRegistrations)
            .WithOne(registration => registration.Exam)
            .IsRequired();

            ModBuilder.Entity<Student>()
            .HasMany(student => student.AllRegistrations)
            .WithOne(registration => registration.Student)
            .IsRequired();
        }



    }
}