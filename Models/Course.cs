using System.Collections.Generic;

namespace ASPNetMVCTesting.Models
{
    public class Course
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Professor { get; set; }
        public List<Exam> Exams { get; set; }
        private Course() { }
        public Course(string name, string professor)
        {
            this.Name = name;
            this.Professor = professor;
        }
    }
}