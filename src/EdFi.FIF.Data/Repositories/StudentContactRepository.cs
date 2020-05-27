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
    public class StudentContactRepository : IStudentContactRepository
    {
        private readonly FIFContext _db;

        public StudentContactRepository(FIFContext db)
        {
            _db = db;
        }
        public async Task<IReadOnlyList<StudentContact>> All()
        {
            return await _db.StudentContacts.OrderBy(x => x.StudentSchoolKey).ThenBy(x => x.ContactPersonKey).ToListAsync();
        }
        public async Task<StudentContact> Get(string studentKey, string contactKey)
        {
            return await _db.StudentContacts.FirstOrDefaultAsync(p => p.StudentSchoolKey == studentKey && p.ContactPersonKey == contactKey);
        }
        public async Task<IReadOnlyList<StudentContact>> GetByStudent(string studentKey)
        {
            return await _db.StudentContacts.Where(p => p.StudentSchoolKey == studentKey).OrderBy(x => x.StudentSchoolKey).ThenBy(x => x.ContactPersonKey).ToListAsync();
        }
        public async Task<IReadOnlyList<StudentContact>> GetByContact(string contactKey)
        {
            return await _db.StudentContacts.Where(p => p.ContactPersonKey == contactKey).OrderBy(x => x.StudentSchoolKey).ThenBy(x => x.ContactPersonKey).ToListAsync();
        }
    }
}
