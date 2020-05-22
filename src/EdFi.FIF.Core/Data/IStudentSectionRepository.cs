using System.Threading.Tasks;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Core.Data
{
    public interface IStudentSectionRepository
    {
        Task<StudentSection> Get(string studentSectionKey);
        Task<StudentSection> GetByStudent(string studentKey);
        Task<StudentSection> GetBySection(string sectionKey);
    }
}