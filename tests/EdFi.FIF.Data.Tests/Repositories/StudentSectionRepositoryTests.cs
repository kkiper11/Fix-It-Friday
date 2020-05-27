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
    public class StudentSectionRepositoryTests : FIFRepositoryConfiguration
    {
        private readonly DbConnection _connection;

        public StudentSectionRepositoryTests()
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
        public void Get_studentSections_returns_studentSections()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var _repository = new StudentSectionRepository(context);
                var result = _repository.All().Result;

                result.Count.ShouldBe(3);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).StudentSectionKey.ShouldBe("1-1"),
                            () => result.ElementAt(0).SchoolKey.ShouldBe("1"),
                            () => result.ElementAt(0).SectionKey.ShouldBe("1"),
                            () => result.ElementAt(0).StudentSchoolKey.ShouldBe("1-1"),
                            () => result.ElementAt(0).StudentKey.ShouldBe("1"),
                            () => result.ElementAt(0).LocalCourseCode.ShouldBe("ACER08"),
                            () => result.ElementAt(0).Subject.ShouldBe("Fine and Performing Arts"),
                            () => result.ElementAt(0).CourseTitle.ShouldBe("Art, Grade 8"),
                            () => result.ElementAt(0).TeacherName.ShouldBe("Joe Doe"),
                            () => result.ElementAt(0).SchoolYear.ShouldBe("2012"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(1).StudentSectionKey.ShouldBe("2-1"),
                            () => result.ElementAt(1).SchoolKey.ShouldBe("1"),
                            () => result.ElementAt(1).SectionKey.ShouldBe("1"),
                            () => result.ElementAt(1).StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ElementAt(1).StudentKey.ShouldBe("2"),
                            () => result.ElementAt(1).LocalCourseCode.ShouldBe("ACER08"),
                            () => result.ElementAt(1).Subject.ShouldBe("Fine and Performing Arts"),
                            () => result.ElementAt(1).CourseTitle.ShouldBe("Art, Grade 8"),
                            () => result.ElementAt(1).TeacherName.ShouldBe("Joe Doe"),
                            () => result.ElementAt(1).SchoolYear.ShouldBe("2012"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(2).StudentSectionKey.ShouldBe("2-2"),
                            () => result.ElementAt(2).SchoolKey.ShouldBe("1"),
                            () => result.ElementAt(2).SectionKey.ShouldBe("2"),
                            () => result.ElementAt(2).StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ElementAt(2).StudentKey.ShouldBe("2"),
                            () => result.ElementAt(2).LocalCourseCode.ShouldBe("ACER31"),
                            () => result.ElementAt(2).Subject.ShouldBe("Fine and Performing Arts"),
                            () => result.ElementAt(2).CourseTitle.ShouldBe("Art Iii Ceramics (1 Unit)"),
                            () => result.ElementAt(2).TeacherName.ShouldBe("Cody Smith"),
                            () => result.ElementAt(2).SchoolYear.ShouldBe("2012"));
            }
        }

        [Test]
        public void Get_studentSections_returns_existing_studentSections()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var _repository = new StudentSectionRepository(context);
                var result = _repository.Get("1-1").Result;

                result.ShouldSatisfyAllConditions(
                    () => result.StudentSectionKey.ShouldBe("1-1"),
                            () => result.SchoolKey.ShouldBe("1"),
                            () => result.SectionKey.ShouldBe("1"),
                            () => result.StudentSchoolKey.ShouldBe("1-1"),
                            () => result.StudentKey.ShouldBe("1"),
                            () => result.LocalCourseCode.ShouldBe("ACER08"),
                            () => result.Subject.ShouldBe("Fine and Performing Arts"),
                            () => result.CourseTitle.ShouldBe("Art, Grade 8"),
                            () => result.TeacherName.ShouldBe("Joe Doe"),
                            () => result.SchoolYear.ShouldBe("2012"));
            }
        }

        [Test]
        public void Get_studentSections_returns_null_when_it_does_not_exist()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var _repository = new StudentSectionRepository(context);
                var result = _repository.Get("1-999").Result;

                result.ShouldBeNull();
            }
        }

        [Test]
        public void Get_studentSections_by_student_returns_existing_studentSections()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var _repository = new StudentSectionRepository(context);
                var result = _repository.GetByStudent("2-1").Result;

                result.Count.ShouldBe(2);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).StudentSectionKey.ShouldBe("2-1"),
                            () => result.ElementAt(0).SchoolKey.ShouldBe("1"),
                            () => result.ElementAt(0).SectionKey.ShouldBe("1"),
                            () => result.ElementAt(0).StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ElementAt(0).StudentKey.ShouldBe("2"),
                            () => result.ElementAt(0).LocalCourseCode.ShouldBe("ACER08"),
                            () => result.ElementAt(0).Subject.ShouldBe("Fine and Performing Arts"),
                            () => result.ElementAt(0).CourseTitle.ShouldBe("Art, Grade 8"),
                            () => result.ElementAt(0).TeacherName.ShouldBe("Joe Doe"),
                            () => result.ElementAt(0).SchoolYear.ShouldBe("2012"));

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(1).StudentSectionKey.ShouldBe("2-2"),
                            () => result.ElementAt(1).SchoolKey.ShouldBe("1"),
                            () => result.ElementAt(1).SectionKey.ShouldBe("2"),
                            () => result.ElementAt(1).StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ElementAt(1).StudentKey.ShouldBe("2"),
                            () => result.ElementAt(1).LocalCourseCode.ShouldBe("ACER31"),
                            () => result.ElementAt(1).Subject.ShouldBe("Fine and Performing Arts"),
                            () => result.ElementAt(1).CourseTitle.ShouldBe("Art Iii Ceramics (1 Unit)"),
                            () => result.ElementAt(1).TeacherName.ShouldBe("Cody Smith"),
                            () => result.ElementAt(1).SchoolYear.ShouldBe("2012"));
            }
        }

        [Test]
        public void Get_studentSections_by_section_returns_existing_studentSections()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                var _repository = new StudentSectionRepository(context);
                var result = _repository.GetBySection("2").Result;

                result.Count.ShouldBe(1);

                result.ShouldSatisfyAllConditions(
                    () => result.ElementAt(0).StudentSectionKey.ShouldBe("2-2"),
                            () => result.ElementAt(0).SchoolKey.ShouldBe("1"),
                            () => result.ElementAt(0).SectionKey.ShouldBe("2"),
                            () => result.ElementAt(0).StudentSchoolKey.ShouldBe("2-1"),
                            () => result.ElementAt(0).StudentKey.ShouldBe("2"),
                            () => result.ElementAt(0).LocalCourseCode.ShouldBe("ACER31"),
                            () => result.ElementAt(0).Subject.ShouldBe("Fine and Performing Arts"),
                            () => result.ElementAt(0).CourseTitle.ShouldBe("Art Iii Ceramics (1 Unit)"),
                            () => result.ElementAt(0).TeacherName.ShouldBe("Cody Smith"),
                            () => result.ElementAt(0).SchoolYear.ShouldBe("2012"));
            }
        }
    }
}
