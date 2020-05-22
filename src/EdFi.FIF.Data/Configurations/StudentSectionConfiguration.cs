using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdFi.FIF.Data.Configurations
{
    class StudentSectionConfiguration : IEntityTypeConfiguration<StudentSection>
    {
        public void Configure(EntityTypeBuilder<StudentSection> builder)
        {
            builder.HasKey(s => s.StudentKey);
            builder.ToTable("StudentSection".ToLower());
            builder.Property(s => s.StudentSectionKey).HasColumnName("StudentSectionKey".ToLower());
            builder.Property(s => s.StudentKey).HasColumnName("StudentKey".ToLower());
            builder.Property(s => s.SectionKey).HasColumnName("SectionKey".ToLower());
            builder.Property(s => s.LocalCourseCode).HasColumnName("LocalCourseCode".ToLower());
            builder.Property(s => s.Subject).HasColumnName("Subject".ToLower());
            builder.Property(s => s.CourseTitle).HasColumnName("CourseTitle".ToLower());
            builder.Property(s => s.TeacherName).HasColumnName("TeacherName".ToLower());
            builder.Property(s => s.StudentSectionStartDateKey).HasColumnName("StudentSectionStartDateKey".ToLower());
            builder.Property(s => s.StudentSectionEndDateKey).HasColumnName("StudentSectionEndDateKey".ToLower());
            builder.Property(s => s.SchoolKey).HasColumnName("SchoolKey".ToLower());
            builder.Property(s => s.SchoolYear).HasColumnName("SchoolYear".ToLower());
        }
    }
}
