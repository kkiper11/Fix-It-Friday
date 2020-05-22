using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data.Repositories
{
    public class StudentSchoolRepository : IStudentSchoolRepository
    {
        private readonly FIFContext _db;

        public StudentSchoolRepository(FIFContext db)
        {
            _db = db;            
        }
        public async Task<List<StudentSchool>> All()
        {
            return await _db.Students.AsNoTracking().ToListAsync();
        }
        public async Task<StudentSchool> Get(string studentSchoolKey)
        {
            return await _db.Students.AsNoTracking().FirstOrDefaultAsync(p => p.StudentKey == studentSchoolKey);
        }
        public async Task<StudentSchool> GetByStudent(string studentKey)
        {
            return await _db.Students.AsNoTracking().FirstOrDefaultAsync(p => p.StudentKey == studentKey);
        }
        public async Task<List<StudentSchool>> GetBySchool(string schoolKey)
        {
            return await _db.Students.AsNoTracking().Where(p => p.SchoolKey == schoolKey).ToListAsync();
        }

    }
}
