using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data.Repositories
{
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly FIFContext _db;

        public ContactPersonRepository(FIFContext db)
        {
            _db = db;
        }
        public async Task<List<ContactPerson>> All()
        {
            return await _db.Contacts.AsNoTracking().ToListAsync();
        }
        public async Task<ContactPerson> Get(string uniqueKey)
        {
            return await _db.Contacts.AsNoTracking().FirstOrDefaultAsync(p => p.UniqueKey == uniqueKey);
        }
        public async Task<ContactPerson> GetFirstContactByStudent(string studentKey)
        {
            return await _db.Contacts.AsNoTracking().FirstOrDefaultAsync(p => p.StudentKey == studentKey);
        }
    }
}
