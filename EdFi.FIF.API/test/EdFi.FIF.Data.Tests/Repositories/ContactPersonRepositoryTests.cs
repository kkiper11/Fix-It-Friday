// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.FIF.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using Shouldly;
using System.Data.Common;
using System.Linq;

namespace EdFi.FIF.Data.Tests.Repositories
{
    public class ContactPersonRepositoryTests : FIFRepositoryConfiguration, IDisposable
    {
        private readonly DbConnection _connection;

        public ContactPersonRepositoryTests()
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
        public void Get_ContactPersons_returns_ContactPersons()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new ContactPersonRepository(context);
                var result = repository.All().Result;

                result.Count.ShouldBe(3);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).UniqueKey.ShouldBe("1"),
                            () => result.ElementAt(0).ContactPersonKey.ShouldBe("1"),
                            () => result.ElementAt(0).StudentKey.ShouldBe("1"),
                            () => result.ElementAt(0).ContactFirstName.ShouldBe("David"),
                            () => result.ElementAt(0).ContactLastName.ShouldBe("Roberts"),
                            () => result.ElementAt(0).RelationshipToStudent.ShouldBe("Father"),
                            () => result.ElementAt(0).StreetNumberName.ShouldBe("384"),
                            () => result.ElementAt(0).State.ShouldBe("TX"),
                            () => result.ElementAt(0).PostalCode.ShouldBe("71357"),
                            () => result.ElementAt(0).ApartmentRoomSuiteNumber.ShouldBe("123"),
                            () => result.ElementAt(0).PhoneNumber.ShouldBe("123-123-7413"),
                            () => result.ElementAt(0).PrimaryEmailAddress.ShouldBe("droberts@gmail.com"),
                            () => result.ElementAt(0).IsPrimaryContact.ShouldBe(true),
                            () => result.ElementAt(0).PreferredContactMethod.ShouldBe("email"),
                            () => result.ElementAt(0).BestTimeToContact.ShouldBe("Any time in the morning"),
                            () => result.ElementAt(0).ContactNotes.ShouldBe("no notes"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(1).UniqueKey.ShouldBe("2"),
                            () => result.ElementAt(1).ContactPersonKey.ShouldBe("2"),
                            () => result.ElementAt(1).StudentKey.ShouldBe("1"),
                            () => result.ElementAt(1).ContactFirstName.ShouldBe("Casey"),
                            () => result.ElementAt(1).ContactLastName.ShouldBe("Johnson"),
                            () => result.ElementAt(1).RelationshipToStudent.ShouldBe("Mother"),
                            () => result.ElementAt(1).StreetNumberName.ShouldBe("384"),
                            () => result.ElementAt(1).State.ShouldBe("TX"),
                            () => result.ElementAt(1).PostalCode.ShouldBe("71357"),
                            () => result.ElementAt(1).ApartmentRoomSuiteNumber.ShouldBe("123"),
                            () => result.ElementAt(1).PhoneNumber.ShouldBe("123-123-7414"),
                            () => result.ElementAt(1).PrimaryEmailAddress.ShouldBe("cjohnson@gmail.com"),
                            () => result.ElementAt(1).IsPrimaryContact.ShouldBe(false),
                            () => result.ElementAt(1).PreferredContactMethod.ShouldBe("email"),
                            () => result.ElementAt(1).BestTimeToContact.ShouldBe("From 9am to 11am"),
                            () => result.ElementAt(1).ContactNotes.ShouldBe("Some notes."));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(2).UniqueKey.ShouldBe("3"),
                            () => result.ElementAt(2).ContactPersonKey.ShouldBe("2"),
                            () => result.ElementAt(2).StudentKey.ShouldBe("2"),
                            () => result.ElementAt(2).ContactFirstName.ShouldBe("John"),
                            () => result.ElementAt(2).ContactLastName.ShouldBe("Simpson"),
                            () => result.ElementAt(2).RelationshipToStudent.ShouldBe("Brother"),
                            () => result.ElementAt(2).StreetNumberName.ShouldBe("385"),
                            () => result.ElementAt(2).State.ShouldBe("TX"),
                            () => result.ElementAt(2).PostalCode.ShouldBe("71356"),
                            () => result.ElementAt(2).ApartmentRoomSuiteNumber.ShouldBe("124"),
                            () => result.ElementAt(2).PhoneNumber.ShouldBe("123-123-8413"),
                            () => result.ElementAt(2).PrimaryEmailAddress.ShouldBe("jsimpson@gmail.com"),
                            () => result.ElementAt(2).IsPrimaryContact.ShouldBe(true),
                            () => result.ElementAt(2).PreferredContactMethod.ShouldBe("email"),
                            () => result.ElementAt(2).BestTimeToContact.ShouldBe("From 10am to 2pm"),
                            () => result.ElementAt(2).ContactNotes.ShouldBe("no notes"));
            }
        }

        [Test]
        public void Get_ContactPerson_returns_ContactPerson()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new ContactPersonRepository(context);
                var result = repository.Get("1").Result;

                result.ShouldSatisfyAllConditions(
                    () => result.UniqueKey.ShouldBe("1"),
                            () => result.ContactPersonKey.ShouldBe("1"),
                            () => result.StudentKey.ShouldBe("1"),
                            () => result.ContactFirstName.ShouldBe("David"),
                            () => result.ContactLastName.ShouldBe("Roberts"),
                            () => result.RelationshipToStudent.ShouldBe("Father"),
                            () => result.StreetNumberName.ShouldBe("384"),
                            () => result.State.ShouldBe("TX"),
                            () => result.PostalCode.ShouldBe("71357"),
                            () => result.ApartmentRoomSuiteNumber.ShouldBe("123"),
                            () => result.PhoneNumber.ShouldBe("123-123-7413"),
                            () => result.PrimaryEmailAddress.ShouldBe("droberts@gmail.com"),
                            () => result.IsPrimaryContact.ShouldBe(true),
                            () => result.PreferredContactMethod.ShouldBe("email"),
                            () => result.BestTimeToContact.ShouldBe("Any time in the morning"),
                            () => result.ContactNotes.ShouldBe("no notes"));
            }
        }

        [Test]
        public void Get_ContactPerson_returns_null_when_it_does_not_exist()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new ContactPersonRepository(context);
                var result = repository.Get("999").Result;

                result.ShouldBeNull();
            }
        }

        [Test]
        public void Get_FirstContactPersonByStudent_returns_ContactPerson()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new ContactPersonRepository(context);
                var result = repository.GetFirstContactByStudent("1").Result;

                result.ShouldSatisfyAllConditions(
                    () => result.UniqueKey.ShouldBe("1"),
                            () => result.ContactPersonKey.ShouldBe("1"),
                            () => result.StudentKey.ShouldBe("1"),
                            () => result.ContactFirstName.ShouldBe("David"),
                            () => result.ContactLastName.ShouldBe("Roberts"),
                            () => result.RelationshipToStudent.ShouldBe("Father"),
                            () => result.StreetNumberName.ShouldBe("384"),
                            () => result.State.ShouldBe("TX"),
                            () => result.PostalCode.ShouldBe("71357"),
                            () => result.ApartmentRoomSuiteNumber.ShouldBe("123"),
                            () => result.PhoneNumber.ShouldBe("123-123-7413"),
                            () => result.PrimaryEmailAddress.ShouldBe("droberts@gmail.com"),
                            () => result.IsPrimaryContact.ShouldBe(true),
                            () => result.PreferredContactMethod.ShouldBe("email"),
                            () => result.BestTimeToContact.ShouldBe("Any time in the morning"),
                            () => result.ContactNotes.ShouldBe("no notes"));
            }
        }

        [Test]
        public void Get_byContactOtherStudents_returns_ContactPerson()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var repository = new ContactPersonRepository(context);
                var result = repository.GetByContactOtherStudents("2", "1").Result;

                result.Count.ShouldBe(1);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).UniqueKey.ShouldBe("3"),
                            () => result.ElementAt(0).ContactPersonKey.ShouldBe("2"),
                            () => result.ElementAt(0).StudentKey.ShouldBe("2"),
                            () => result.ElementAt(0).ContactFirstName.ShouldBe("John"),
                            () => result.ElementAt(0).ContactLastName.ShouldBe("Simpson"),
                            () => result.ElementAt(0).RelationshipToStudent.ShouldBe("Brother"),
                            () => result.ElementAt(0).StreetNumberName.ShouldBe("385"),
                            () => result.ElementAt(0).State.ShouldBe("TX"),
                            () => result.ElementAt(0).PostalCode.ShouldBe("71356"),
                            () => result.ElementAt(0).ApartmentRoomSuiteNumber.ShouldBe("124"),
                            () => result.ElementAt(0).PhoneNumber.ShouldBe("123-123-8413"),
                            () => result.ElementAt(0).PrimaryEmailAddress.ShouldBe("jsimpson@gmail.com"),
                            () => result.ElementAt(0).IsPrimaryContact.ShouldBe(true),
                            () => result.ElementAt(0).PreferredContactMethod.ShouldBe("email"),
                            () => result.ElementAt(0).BestTimeToContact.ShouldBe("From 10am to 2pm"),
                            () => result.ElementAt(0).ContactNotes.ShouldBe("no notes"));
            }
        }
    }
}
