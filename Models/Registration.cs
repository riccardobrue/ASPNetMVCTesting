namespace ASPNetMVCTesting.Models
{
    public class Registration
    {
        public int ID { get; private set; }
        public Student Student { get; private set; }
        public Exam Exam { get; private set; }

        public Registration(Student student, Exam exam)
        {
            this.Student = student;
            this.Exam = exam;
        }
    }
}