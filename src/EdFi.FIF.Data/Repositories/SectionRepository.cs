using System.Collections.Generic;
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
    }
}
