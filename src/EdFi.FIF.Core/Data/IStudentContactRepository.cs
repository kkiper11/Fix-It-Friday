using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Core.Data
{
    public interface IStudentContactRepository
    {
        Task<List<StudentContact>> All();
        Task<StudentContact> Get(string studentKey, string contactKey);
        Task<List<StudentContact>> GetByStudent(string studentKey);
        Task<List<StudentContact>> GetByContact(string contactKey);
    }
}