using System.ComponentModel.DataAnnotations;

namespace ASPNetMVCTesting.Models.Requests
{
    public class CourseCreationData
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string ProfessorName { get; set; }
    }
}