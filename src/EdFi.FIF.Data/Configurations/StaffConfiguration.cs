using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdFi.FIF.Data.Configurations
{
    class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(s => s.StaffKey);
            builder.ToTable("Staff".ToLower());
            builder.Property(s => s.StaffKey).HasColumnName("StaffKey".ToLower());
            builder.Property(s => s.PersonalTitlePrefix).HasColumnName("PersonalTitlePrefix".ToLower());
            builder.Property(s => s.FirstName).HasColumnName("FirstName".ToLower());
            builder.Property(s => s.MiddleName).HasColumnName("MiddleName".ToLower());
            builder.Property(s => s.LastSurname).HasColumnName("LastSurname".ToLower());
            builder.Property(s => s.StaffUniqueId).HasColumnName("StaffUniqueId".ToLower());

            builder.HasMany(s => s.StaffSectionAssociations).WithOne(s => s.Staff).HasForeignKey(s => s.StaffKey);
        }
    }
}
