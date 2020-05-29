// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.FIF.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdFi.FIF.Core.Data
{
    public interface IStudentContactRepository
    {
        Task<IReadOnlyList<StudentContact>> All();
        Task<StudentContact> Get(string studentKey, string contactKey);
        Task<IReadOnlyList<StudentContact>> GetByStudent(string studentKey);
        Task<IReadOnlyList<StudentContact>> GetByContact(string contactKey);
    }
}
