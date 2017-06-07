using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNetMVCTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetMVCTesting.Services
{
    public class Database : DbContext, ICoursesService
    {
        public DbSet<Course> Courses { get; private set; }
        public DbSet<Exam> Exams { get; private set; }

        public async Task CreateNewCourse(Course course)
        {
            Courses.Add(course);
            await SaveChangesAsync();
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

            ModBuilder.Entity<Exam>()
            .HasOne(exam => exam.Course)
            .WithMany(course => course.Exams);
        }



    }
}