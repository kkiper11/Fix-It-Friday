using System.Collections.Generic;
using System.Linq;
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
    }
}
