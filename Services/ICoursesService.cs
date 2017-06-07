using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNetMVCTesting.Models;

namespace ASPNetMVCTesting.Services
{
    public interface ICoursesService
    {
        Task<IEnumerable<Course>> List();
        Task CreateNewCourse(Course course);
    }
}