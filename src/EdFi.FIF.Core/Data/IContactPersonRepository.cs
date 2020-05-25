using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Core.Data
{
    public interface IContactPersonRepository
    {
        Task<List<ContactPerson>> All();
        Task<ContactPerson> Get(string uniqueKey);
        Task<ContactPerson> GetFirstContactByStudent(string studentKey);
        Task<List<ContactPerson>> GetByContactOtherStudents(string uniqueKey, string studentKey);
    }
}