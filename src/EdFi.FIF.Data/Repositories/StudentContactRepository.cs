using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data.Repositories
{
    public class StudentContactRepository : IStudentContactRepository
    {
        private readonly FIFContext _db;

        public StudentContactRepository(FIFContext db)
        {
            _db = db;
        }
        public async Task<List<StudentContact>> All()
        {
            return await _db.StudentContacts.AsNoTracking().ToListAsync();
        }
        public async Task<StudentContact> Get(string studentKey, string contactKey)
        {
            return await _db.StudentContacts.AsNoTracking().FirstOrDefaultAsync(p => p.StudentSchoolKey == studentKey && p.ContactKey == contactKey);
        }
        public async Task<List<StudentContact>> GetByStudent(string studentKey)
        {
            return await _db.StudentContacts.AsNoTracking().Where(p => p.StudentSchoolKey == studentKey).ToListAsync();
        }
        public async Task<List<StudentContact>> GetByContact(string contactKey)
        {
            return await _db.StudentContacts.AsNoTracking().Where(p => p.ContactKey == contactKey).ToListAsync();
        }
    }
}
