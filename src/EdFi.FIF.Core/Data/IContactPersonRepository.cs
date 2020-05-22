using System.Threading.Tasks;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Core.Data
{
    public interface IContactPersonRepository
    {
        Task<ContactPerson> Get(string uniqueKey);
        Task<ContactPerson> GetFirstContactByStudent(string studentKey);
    }
}