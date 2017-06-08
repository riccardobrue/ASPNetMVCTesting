using System.Threading.Tasks;
using ASPNetMVCTesting.Models;

namespace ASPNetMVCTesting.Services
{
    public interface IExamsService
    {
        Task<Exam> GetExamFromID(int ID);
    }
}