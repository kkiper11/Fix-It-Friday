using Microsoft.EntityFrameworkCore;
using EdFi.FIF.Core.Models;

namespace EdFi.FIF.Data
{
    public class FIFContext : DbContext
    {
        private readonly string _schema = "fif";

        public FIFContext(DbContextOptions options)
            : base(options)
        {   
        }
        public DbSet<ContactPerson> Contacts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<StudentSchool> Students { get; set; }
        public DbSet<StudentContact> StudentContacts { get; set; }
        public DbSet<StudentSection> StudentSections { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffSectionAssociation> StaffSectionAssociations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentSchool>(eb =>
                {
                    eb.HasKey(s => s.StudentKey);
                    eb.ToTable("StudentSchool".ToLower(), _schema);
                    eb.Property(s => s.StudentSchoolKey).HasColumnName("StudentSchoolKey".ToLower());
                    eb.Property(s => s.StudentKey).HasColumnName("StudentKey".ToLower());
                    eb.Property(s => s.StudentFirstName).HasColumnName("StudentFirstName".ToLower());
                    eb.Property(s => s.StudentMiddleName).HasColumnName("StudentMiddleName".ToLower());
                    eb.Property(s => s.StudentLastName).HasColumnName("StudentLastName".ToLower());
                    eb.Property(s => s.SchoolKey).HasColumnName("SchoolKey".ToLower());
                    eb.Property(s => s.SchoolYear).HasColumnName("SchoolYear".ToLower());
                    eb.Property(s => s.EnrollmentDateKey).HasColumnName("EnrollmentDateKey".ToLower());
                    eb.Property(s => s.GradeLevel).HasColumnName("GradeLevel".ToLower());
                    eb.Property(s => s.LimitedEnglishProficiency).HasColumnName("LimitedEnglishProficiency".ToLower());
                    eb.Property(s => s.IsHispanic).HasColumnName("IsHispanic".ToLower());
                    eb.Property(s => s.Sex).HasColumnName("Sex".ToLower());
                })
                .Entity<ContactPerson>(eb =>
                {
                    eb.HasKey(s => s.StudentKey);
                    eb.ToTable("ContactPerson".ToLower(), _schema);
                    eb.Property(s => s.UniqueKey).HasColumnName("UniqueKey".ToLower());
                    eb.Property(s => s.ContactPersonKey).HasColumnName("ContactPersonKey".ToLower());
                    eb.Property(s => s.StudentKey).HasColumnName("StudentKey".ToLower());
                    eb.Property(s => s.ContactFirstName).HasColumnName("ContactFirstName".ToLower());
                    eb.Property(s => s.ContactLastName).HasColumnName("ContactLastName".ToLower());
                    eb.Property(s => s.RelationshipToStudent).HasColumnName("RelationshipToStudent".ToLower());
                    eb.Property(s => s.StreetNumberName).HasColumnName("StreetNumberName".ToLower());
                    eb.Property(s => s.ApartmentRoomSuiteNumber).HasColumnName("ApartmentRoomSuiteNumber".ToLower());
                    eb.Property(s => s.State).HasColumnName("State".ToLower());
                    eb.Property(s => s.PostalCode).HasColumnName("PostalCode".ToLower());
                    eb.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber".ToLower());
                    eb.Property(s => s.PrimaryEmailAddress).HasColumnName("PrimaryEmailAddress".ToLower());
                    eb.Property(s => s.IsPrimaryContact).HasColumnName("IsPrimaryContact".ToLower());
                })
                .Entity<StudentContact>(eb =>
                {
                    eb.HasKey(s => s.StudentSchoolKey);
                    eb.ToTable("StudentContact".ToLower(), _schema);
                    eb.Property(s => s.StudentSchoolKey).HasColumnName("StudentKey".ToLower());
                    eb.Property(s => s.ContactKey).HasColumnName("ContactKey".ToLower());
                })
                .Entity<StudentSection>(eb =>
                {
                    eb.HasKey(s => s.StudentKey);
                    eb.ToTable("StudentSection".ToLower(), _schema);
                    eb.Property(s => s.StudentSectionKey).HasColumnName("StudentSectionKey".ToLower());
                    eb.Property(s => s.StudentKey).HasColumnName("StudentKey".ToLower());
                    eb.Property(s => s.SectionKey).HasColumnName("SectionKey".ToLower());
                    eb.Property(s => s.LocalCourseCode).HasColumnName("LocalCourseCode".ToLower());
                    eb.Property(s => s.Subject).HasColumnName("Subject".ToLower());
                    eb.Property(s => s.CourseTitle).HasColumnName("CourseTitle".ToLower());
                    eb.Property(s => s.TeacherName).HasColumnName("TeacherName".ToLower());
                    eb.Property(s => s.StudentSectionStartDateKey).HasColumnName("StudentSectionStartDateKey".ToLower());
                    eb.Property(s => s.StudentSectionEndDateKey).HasColumnName("StudentSectionEndDateKey".ToLower());
                    eb.Property(s => s.SchoolKey).HasColumnName("SchoolKey".ToLower());
                    eb.Property(s => s.SchoolYear).HasColumnName("SchoolYear".ToLower());
                })
                .Entity<Staff>(eb =>
                {
                    eb.HasKey(s => s.StaffKey);
                    eb.ToTable("Staff".ToLower(), _schema);
                    eb.Property(s => s.StaffKey).HasColumnName("StaffKey".ToLower());
                    eb.Property(s => s.PersonalTitlePrefix).HasColumnName("PersonalTitlePrefix".ToLower());
                    eb.Property(s => s.FirstName).HasColumnName("FirstName".ToLower());
                    eb.Property(s => s.MiddleName).HasColumnName("MiddleName".ToLower());
                    eb.Property(s => s.LastSurname).HasColumnName("LastSurname".ToLower());
                    eb.Property(s => s.StaffUniqueId).HasColumnName("StaffUniqueId".ToLower());
                })
                .Entity<StaffSectionAssociation>(eb =>
                {
                    eb.HasKey(s => s.StaffKey);
                    eb.ToTable("StaffSectionAssociation".ToLower(), _schema);
                    eb.Property(s => s.StaffKey).HasColumnName("StaffKey".ToLower());
                    eb.Property(s => s.SectionKey).HasColumnName("SectionKey".ToLower());
                    eb.Property(s => s.BeginDate).HasColumnName("BeginDate".ToLower());
                    eb.Property(s => s.EndDate).HasColumnName("EndDate".ToLower());
                })
                .Entity<Section>(eb =>
                {
                    eb.HasKey(s => s.SectionKey);
                    eb.ToTable("Section".ToLower(), _schema);
                    eb.Property(s => s.SectionKey).HasColumnName("SectionKey".ToLower());
                    eb.Property(s => s.SchoolKey).HasColumnName("SchoolKey".ToLower());
                    eb.Property(s => s.LocalCourseCode).HasColumnName("LocalCourseCode".ToLower());
                    eb.Property(s => s.SessionName).HasColumnName("SessionName".ToLower());
                    eb.Property(s => s.SectionIdentifier).HasColumnName("SectionIdentifier".ToLower());
                    eb.Property(s => s.SchoolYear).HasColumnName("SchoolYear".ToLower());
                })
                    ;
        }
    }
}
