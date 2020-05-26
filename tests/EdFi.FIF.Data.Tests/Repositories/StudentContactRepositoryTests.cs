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
    public class StudentContactRepositoryTests : FIFRepositoryTest
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

        [Test]
        public void Get_all_studentcontacts_returns_studentcontacts()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var _repository = new StudentContactRepository(context);
                var result = _repository.All().Result;

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
                var _repository = new StudentContactRepository(context);
                var result = _repository.GetByStudent("1-1").Result;

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
                var _repository = new StudentContactRepository(context);
                var result = _repository.GetByContact("2").Result;

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
                var _repository = new StudentContactRepository(context);
                var result = _repository.Get("2-1","2").Result;

                result.ShouldSatisfyAllConditions(
                    () => result.StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ContactPersonKey.ShouldBe("2"));
            }
        }
    }
}
