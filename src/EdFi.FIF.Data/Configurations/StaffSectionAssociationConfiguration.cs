using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdFi.FIF.Data.Configurations
{
    public class StaffSectionAssociationConfiguration : IEntityTypeConfiguration<StaffSectionAssociation>
    {
        public void Configure(EntityTypeBuilder<StaffSectionAssociation> builder)
        {
            builder.HasKey(s => new { s.StaffKey, s.SectionKey });
            builder.ToTable("StaffSectionAssociation".ToLower());
            builder.Property(s => s.StaffKey).HasColumnName("StaffKey".ToLower());
            builder.Property(s => s.SectionKey).HasColumnName("SectionKey".ToLower());
            builder.Property(s => s.BeginDate).HasColumnName("BeginDate".ToLower());
            builder.Property(s => s.EndDate).HasColumnName("EndDate".ToLower());

            builder.HasOne(s => s.Staff).WithMany(s => s.StaffSectionAssociations).HasForeignKey(s => s.StaffKey);
            builder.HasOne(s => s.Section).WithMany(s => s.StaffSectionAssociations).HasForeignKey(s => s.SectionKey);
        }
    }
}
