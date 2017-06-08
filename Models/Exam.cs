using System;
using System.Collections.Generic;

namespace ASPNetMVCTesting.Models
{
    public class Exam
    {
        public int ID { get; private set; }
        public Course Course { get; set; }
        public DateTime ExamDate { get; set; }
        /*
        private Exam() { }
        public Exam(Course Course, DateTime ExamDate)
        {
            this.Course = Course;
            this.ExamDate = ExamDate;
        }
        */
        private List<Registration> ListOfRegistrations;
        public IEnumerable<Registration> AllRegistrations
        {
            get
            {
                return ListOfRegistrations;
            }
        }

    }
}