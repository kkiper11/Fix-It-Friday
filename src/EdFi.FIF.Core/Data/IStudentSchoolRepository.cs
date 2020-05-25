using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;
// ReSharper disable IdentifierTypo

namespace EdFi.FIF.Core.Data
{
    public interface IStudentSchoolRepository
    {
        Task<StudentSchool> Get(string studentSchoolKey);
        Task<StudentSchool> GetByStudent(string studentKey);
        Task<List<StudentSchool>> All();
        Task<List<StudentSchool>> GetBySchool(string schoolkey);
    }
}