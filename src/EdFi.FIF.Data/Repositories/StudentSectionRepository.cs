using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data.Repositories
{
    public class StudentSectionRepository : IStudentSectionRepository
    {
        private readonly FIFContext _db;

        public StudentSectionRepository(FIFContext db)
        {
            _db = db;
        }
        public async Task<List<StudentSection>> All()
        {
            return await _db.StudentSections.AsNoTracking().ToListAsync();
        }

        public async Task<StudentSection> Get(string studentSectionKey)
        {
            return await _db.StudentSections.AsNoTracking().FirstOrDefaultAsync(p => p.StudentSectionKey == studentSectionKey);
        }

        public async Task<StudentSection> GetByStudent(string studentKey)
        {
            return await _db.StudentSections.AsNoTracking().FirstOrDefaultAsync(p => p.StudentSectionKey == studentKey);
        }

        public async Task<StudentSection> GetBySection(string sectionKey)
        {
            return await _db.StudentSections.AsNoTracking().FirstOrDefaultAsync(p => p.SectionKey == sectionKey);
        }
    }
}
