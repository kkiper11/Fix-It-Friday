using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdFi.FIF.Data.Configurations
{
    public class StudentSchoolConfiguration : IEntityTypeConfiguration<StudentSchool>
    {
        public void Configure(EntityTypeBuilder<StudentSchool> builder)
        {
            builder.HasKey(s => s.StudentKey);
            builder.ToTable("Clients", "identity");

            builder.Property(s => s.StudentSchoolKey).HasColumnName("StudentSchoolKey".ToLower());
            builder.Property(s => s.StudentKey).HasColumnName("StudentKey".ToLower());
            builder.Property(s => s.StudentFirstName).HasColumnName("StudentFirstName".ToLower());
            builder.Property(s => s.StudentMiddleName).HasColumnName("StudentMiddleName".ToLower());
            builder.Property(s => s.StudentLastName).HasColumnName("StudentLastName".ToLower());
            builder.Property(s => s.SchoolKey).HasColumnName("SchoolKey".ToLower());
            builder.Property(s => s.SchoolYear).HasColumnName("SchoolYear".ToLower());
            builder.Property(s => s.EnrollmentDateKey).HasColumnName("EnrollmentDateKey".ToLower());
            builder.Property(s => s.GradeLevel).HasColumnName("GradeLevel".ToLower());
            builder.Property(s => s.LimitedEnglishProficiency).HasColumnName("LimitedEnglishProficiency".ToLower());
            builder.Property(s => s.IsHispanic).HasColumnName("IsHispanic".ToLower());
            builder.Property(s => s.Sex).HasColumnName("Sex".ToLower());
        }
    }
}
