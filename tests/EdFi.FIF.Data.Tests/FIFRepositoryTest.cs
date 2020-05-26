using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EdFi.FIF.Data.Tests
{
    public class FIFRepositoryTest
    {
        protected FIFRepositoryTest(DbContextOptions<FIFContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }
        protected DbContextOptions<FIFContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new FIFContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var contactPeople = new List<ContactPerson>()
                {
                    new ContactPerson()
                    {
                        UniqueKey = "1",
                        ContactPersonKey = "1",
                        StudentKey = "1",
                        ContactFirstName = "David",
                        ContactLastName = "Roberts",
                        RelationshipToStudent = "Father",
                        StreetNumberName = "384",
                        State = "TX",
                        PostalCode = "71357",
                        ApartmentRoomSuiteNumber = "123",
                        PhoneNumber = "123-123-7413",
                        PrimaryEmailAddress = "droberts@gmail.com",
                        IsPrimaryContact = true,
                        PreferredContactMethod = "email",
                        BestTimeToContact = "Any time in the morning",
                        ContactNotes = "no notes"
                    },
                    new ContactPerson()
                    {
                        UniqueKey = "2",
                        ContactPersonKey = "2",
                        StudentKey = "1",
                        ContactFirstName = "Casey",
                        ContactLastName = "Johnson",
                        RelationshipToStudent = "Mother",
                        StreetNumberName = "384",
                        State = "TX",
                        PostalCode = "71357",
                        ApartmentRoomSuiteNumber = "123",
                        PhoneNumber = "123-123-7414",
                        PrimaryEmailAddress = "cjohnson@gmail.com",
                        IsPrimaryContact = false,
                        PreferredContactMethod = "email",
                        BestTimeToContact = "From 9am to 11am",
                        ContactNotes = "Some notes."
                    },
                    new ContactPerson()
                    {
                        UniqueKey = "3",
                        ContactPersonKey = "2",
                        StudentKey = "2",
                        ContactFirstName = "John",
                        ContactLastName = "Simpson",
                        RelationshipToStudent = "Brother",
                        StreetNumberName = "385",
                        State = "TX",
                        PostalCode = "71356",
                        ApartmentRoomSuiteNumber = "124",
                        PhoneNumber = "123-123-8413",
                        PrimaryEmailAddress = "jsimpson@gmail.com",
                        IsPrimaryContact = true,
                        PreferredContactMethod = "email",
                        BestTimeToContact = "From 10am to 2pm",
                        ContactNotes = "no notes"
                    }
                };

                var studentSchools = new List<StudentSchool>()
                {
                    new StudentSchool()
                    {
                        StudentSchoolKey = "1-1",
                        SchoolKey = "1",
                        SchoolYear = "2012",
                        StudentKey = "1",
                        StudentFirstName = "Tommas",
                        StudentLastName = "McCarthy",
                        EnrollmentDateKey = "20120101",
                        GradeLevel = "Ninth grade"
                    },
                    new StudentSchool()
                    {
                        StudentSchoolKey = "2-1",
                        SchoolKey = "1",
                        SchoolYear = "2012",
                        StudentKey = "2",
                        StudentFirstName = "Matthew",
                        StudentLastName = "Simpson",
                        EnrollmentDateKey = "20120101",
                        GradeLevel = "Eighth grade",
                        IsHispanic = true,
                        Sex = "Male"
                    }
                };

                var staff = new List<Staff>()
                {
                    new Staff()
                    {
                        StaffKey = 1,
                        StaffUniqueId = "1",
                        PersonalTitlePrefix = "Sr.",
                        FirstName = "Joe",
                        LastSurname = "Doe",
                        MiddleName = "J."
                    },
                    new Staff()
                    {
                        StaffKey = 2,
                        StaffUniqueId = "2",
                        PersonalTitlePrefix = "Sr.",
                        FirstName = "Cody",
                        LastSurname = "Smith",
                        MiddleName = "C."
                    }
                };

                var sections = new List<Section>()
                {
                    new Section()
                    {
                        SectionKey = "1",
                        SchoolKey = "1",
                        SchoolYear = 2012,
                        SessionName = "Traditional",
                        SectionIdentifier = "21855",
                        LocalCourseCode = "ACER08"
                    },
                    new Section()
                    {
                        SectionKey = "2",
                        SchoolKey = "1",
                        SchoolYear = 2012,
                        SessionName = "Traditional-Spring Semester",
                        SectionIdentifier = "21856",
                        LocalCourseCode = "ACER08"
                    },
                    new Section()
                    {
                        SectionKey = "3",
                        SchoolKey = "2",
                        SchoolYear = 2012,
                        SessionName = "Traditional",
                        SectionIdentifier = "21857",
                        LocalCourseCode = "ACER09"
                    }
                };

                var staffSectionAssociation = new List<StaffSectionAssociation>()
                {
                    new StaffSectionAssociation()
                    {
                        StaffKey = 1,
                        SectionKey = "1",
                        BeginDate = new DateTime(2012,01,01)
                    },
                    new StaffSectionAssociation()
                    {
                        StaffKey = 1,
                        SectionKey = "2",
                        BeginDate = new DateTime(2012,01,01)
                    },
                    new StaffSectionAssociation()
                    {
                        StaffKey = 2,
                        SectionKey = "2",
                        BeginDate = new DateTime(2012,01,01)
                    },
                    new StaffSectionAssociation()
                    {
                        StaffKey = 2,
                        SectionKey = "3",
                        BeginDate = new DateTime(2012,01,01),
                        EndDate = DateTime.Now.AddDays(1)
                    }
                };

                var studentSections = new List<StudentSection>()
                {
                    new StudentSection()
                    {
                        StudentSectionKey = "1-1",
                        SchoolKey = "1",
                        SectionKey = "1",
                        StudentSchoolKey = "1-1",
                        StudentKey = "1",
                        LocalCourseCode = "ACER08",
                        Subject = "Fine and Performing Arts",
                        CourseTitle = "Art, Grade 8",
                        TeacherName = "Joe Doe",
                        SchoolYear = "2012"
                    },
                    new StudentSection()
                    {
                        StudentSectionKey = "2-1",
                        SchoolKey = "1",
                        SectionKey = "1",
                        StudentSchoolKey = "2-1",
                        StudentKey = "2",
                        LocalCourseCode = "ACER08",
                        Subject = "Fine and Performing Arts",
                        CourseTitle = "Art, Grade 8",
                        TeacherName = "Joe Doe",
                        SchoolYear = "2012"
                    },
                    new StudentSection()
                    {
                        StudentSectionKey = "2-2",
                        SchoolKey = "1",
                        SectionKey = "2",
                        StudentSchoolKey = "2-1",
                        StudentKey = "2",
                        LocalCourseCode = "ACER31",
                        Subject = "Fine and Performing Arts",
                        CourseTitle = "Art Iii Ceramics (1 Unit)",
                        TeacherName = "Cody Smith",
                        SchoolYear = "2012"
                    }
                };

                context.AddRange(contactPeople);
                context.AddRange(studentSchools);
                context.AddRange(sections);
                context.AddRange(staff);
                context.AddRange(staffSectionAssociation);
                context.AddRange(studentSections);
                
                context.SaveChanges();
            }
        }
    }
}
