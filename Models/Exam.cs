using System;

namespace ASPNetMVCTesting.Models
{
    public class Exam
    {
        public int ID { get; private set; }
        public Course Course { get; set; }
        public DateTime ExamDate { get; set; }
        private Exam() { }
        public Exam(Course course, DateTime examDate)
        {
            this.Course = course;
            this.ExamDate = examDate;
        }
    }
}