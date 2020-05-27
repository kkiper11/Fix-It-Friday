// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.FIF.Core.Data;
using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdFi.FIF.Data.Repositories
{
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly FIFContext _db;

        public ContactPersonRepository(FIFContext db)
        {
            _db = db;
        }
        public async Task<IReadOnlyList<ContactPerson>> All()
        {
            return await _db.Contacts.OrderBy(x => x.ContactPersonKey).ToListAsync();
        }
        public async Task<ContactPerson> Get(string uniqueKey)
        {
            return await _db.Contacts.FirstOrDefaultAsync(p => p.UniqueKey == uniqueKey);
        }
        public async Task<ContactPerson> GetFirstContactByStudent(string studentKey)
        {
            return await _db.Contacts.FirstOrDefaultAsync(p => p.StudentKey == studentKey);
        }
        public async Task<IReadOnlyList<ContactPerson>> GetByContactOtherStudents(string contactpersonKey, string studentKey)
        {
            return await _db.Contacts.Where(p => p.ContactPersonKey == contactpersonKey && p.StudentKey != studentKey).OrderBy(x => x.ContactPersonKey).ToListAsync();
        }
    }
}
