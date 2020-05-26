using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdFi.FIF.Data.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(s => s.SectionKey);
            builder.ToTable("Section".ToLower());
            builder.Property(s => s.SectionKey).HasColumnName("SectionKey".ToLower());
            builder.Property(s => s.SchoolKey).HasColumnName("SchoolKey".ToLower());
            builder.Property(s => s.LocalCourseCode).HasColumnName("LocalCourseCode".ToLower());
            builder.Property(s => s.SessionName).HasColumnName("SessionName".ToLower());
            builder.Property(s => s.SectionIdentifier).HasColumnName("SectionIdentifier".ToLower());
            builder.Property(s => s.SchoolYear).HasColumnName("SchoolYear".ToLower());

            builder.HasMany(s => s.StaffSectionAssociations).WithOne(s => s.Section).HasForeignKey(s => s.SectionKey);

            builder.HasMany(s => s.StudentSections).WithOne(s => s.Section).HasForeignKey(s => s.SectionKey);
        }
    }
}
