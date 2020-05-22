using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data.Repositories
{
    public class StaffSectionAssociationRepository : IStaffSectionAssociationRepository
    {
        private readonly FIFContext _db;

        public StaffSectionAssociationRepository(FIFContext db)
        {
            _db = db;
        }

        public async Task<List<StaffSectionAssociation>> All()
        {
            return await _db.StaffSectionAssociations.AsNoTracking().ToListAsync();
        }

        public async Task<StaffSectionAssociation> GetBySection(string sectionKey)
        {
            return await _db.StaffSectionAssociations.AsNoTracking().FirstOrDefaultAsync(p => p.SectionKey == sectionKey);
        }

        public async Task<StaffSectionAssociation> GetByStaff(int staffKey)
        {
            return await _db.StaffSectionAssociations.AsNoTracking().FirstOrDefaultAsync(p => p.StaffKey == staffKey);
        }
    }
}
