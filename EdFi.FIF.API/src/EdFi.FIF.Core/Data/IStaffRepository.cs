using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Core.Data
{
    public interface IStaffRepository
    {
        Task<List<Staff>> All();
        Task<Staff> Get(int staffKey);
    }
}   