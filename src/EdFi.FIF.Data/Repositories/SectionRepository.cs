using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly FIFContext _db;

        public SectionRepository(FIFContext db)
        {
            _db = db;
        }

        public async Task<List<Section>> All()
        {
            return await _db.Sections.AsNoTracking().ToListAsync();
        }

        public async Task<Section> Get(string sectionKey)
        {
            return await _db.Sections.AsNoTracking().FirstOrDefaultAsync(p => p.SectionKey == sectionKey);
        }

        public async Task<List<Section>> GetBySectionList(List<StaffSectionAssociation> staffSectionAssociations)
        {
            return await _db.Sections.AsNoTracking().Where(x => staffSectionAssociations.Select(p => p.SectionKey).Contains(x.SectionKey)).ToListAsync();
        }
    }
}
