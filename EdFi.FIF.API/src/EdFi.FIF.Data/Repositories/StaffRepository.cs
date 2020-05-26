using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly FIFContext _db;

        public StaffRepository(FIFContext db)
        {
            _db = db;
        }
        public async Task<List<Staff>> All()
        {
            return await _db.Staffs.AsNoTracking().ToListAsync();
        }
        public async Task<Staff> Get(int staffKey)
        {
            return await _db.Staffs.AsNoTracking().FirstOrDefaultAsync(p => p.StaffKey == staffKey);
        }
    }
}
