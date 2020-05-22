using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Core.Data
{
    public interface IStudentSectionRepository
    {
        Task<StudentSection> Get(string studentSectionKey);
        Task<List<StudentSection>> GetByStudent(string studentKey);
        Task<List<StudentSection>> GetBySection(string sectionKey);
    }
}