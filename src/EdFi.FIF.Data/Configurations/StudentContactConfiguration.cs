using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdFi.FIF.Data.Configurations
{
    public class StudentContactConfiguration : IEntityTypeConfiguration<StudentContact>
    {
        public void Configure(EntityTypeBuilder<StudentContact> builder)
        {
            builder.HasKey(s => new { s.StudentSchoolKey, s.ContactPersonKey });
            builder.ToTable("StudentContact".ToLower());
            builder.Property(s => s.StudentSchoolKey).HasColumnName("StudentSchoolKey".ToLower());
            builder.Property(s => s.ContactPersonKey).HasColumnName("ContactKey".ToLower());

            builder.HasOne(s => s.ContactPerson).WithMany(s => s.StudentContacts).HasForeignKey(s => s.ContactPersonKey);

            builder.HasOne(s => s.StudentSchool).WithMany(s => s.StudentContacts).HasForeignKey(s => s.StudentSchoolKey);
        }
    }
}