using System;
using System.Collections.Generic;

namespace ASPNetMVCTesting.Models
{
    public class Student
    {
        public string StudentNumber { get; private set; }
        public string FullName { get; private set; }
        private List<Registration> ListOfRegistrations;

        public Student() { }
        public Student(string StudentNumber, string FullName)
        {
            this.StudentNumber = StudentNumber;
            this.FullName = FullName;
        }

        public IEnumerable<Registration> AllRegistrations
        {
            get
            {
                return ListOfRegistrations;
            }
        }

        public void ExamRegistration(Exam exam)
        {
            var registration = new Registration(this, exam);
            ListOfRegistrations.Add(registration);
        }
    }




}