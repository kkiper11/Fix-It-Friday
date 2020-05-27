// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.FIF.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using Shouldly;
using System;
using System.Data.Common;
using System.Linq;

namespace EdFi.FIF.Data.Tests.Repositories
{
    public class StudentContactRepositoryTests : FIFRepositoryConfiguration, IDisposable
    {
        private readonly DbConnection _connection;

        public StudentContactRepositoryTests()
        : base(
            new DbContextOptionsBuilder<FIFContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options)
        {
            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose() => _connection.Dispose();

        [Test]
        public void Get_all_student_contacts_returns_student_contacts()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new StudentContactRepository(context);
                var result = repository.All().Result;

                result.Count.ShouldBe(3);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).StudentSchoolKey.ShouldBe("1-1"),
                            () => result.ElementAt(0).ContactPersonKey.ShouldBe("1"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(1).StudentSchoolKey.ShouldBe("1-1"),
                            () => result.ElementAt(1).ContactPersonKey.ShouldBe("2"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(2).StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ElementAt(2).ContactPersonKey.ShouldBe("2"));
            }
        }

        [Test]
        public void Get_studentcontacts_by_StudentSchoolKey_returns_studentcontacts()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new StudentContactRepository(context);
                var result = repository.GetByStudent("1-1").Result;

                result.Count.ShouldBe(2);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).StudentSchoolKey.ShouldBe("1-1"),
                            () => result.ElementAt(0).ContactPersonKey.ShouldBe("1"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(1).StudentSchoolKey.ShouldBe("1-1"),
                            () => result.ElementAt(1).ContactPersonKey.ShouldBe("2"));
            }
        }

        [Test]
        public void Get_studentcontacts_by_ContactPersonKey_returns_studentcontacts()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new StudentContactRepository(context);
                var result = repository.GetByContact("2").Result;

                result.Count.ShouldBe(2);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).StudentSchoolKey.ShouldBe("1-1"),
                            () => result.ElementAt(0).ContactPersonKey.ShouldBe("2"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(1).StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ElementAt(1).ContactPersonKey.ShouldBe("2"));
            }
        }

        [Test]
        public void Get_all_studentcontacts_by_StudentSchoolKey_and_ContactPersonKey_returns_studentcontacts()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new StudentContactRepository(context);
                var result = repository.Get("2-1","2").Result;

                result.ShouldSatisfyAllConditions(
                    () => result.StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ContactPersonKey.ShouldBe("2"));
            }
        }
    }
}
