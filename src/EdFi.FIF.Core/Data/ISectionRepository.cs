using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Core.Data
{
    public interface ISectionRepository
    {
        Task<List<Section>> All();
        Task<Section> Get(string sectionKey);
    }
}
