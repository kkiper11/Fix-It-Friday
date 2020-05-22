using EdFi.FIF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdFi.FIF.Data.Configurations
{
    public class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.HasKey(s => s.StudentKey);
            builder.ToTable("ContactPerson".ToLower());
            builder.Property(s => s.UniqueKey).HasColumnName("UniqueKey".ToLower());
            builder.Property(s => s.ContactPersonKey).HasColumnName("ContactPersonKey".ToLower());
            builder.Property(s => s.StudentKey).HasColumnName("StudentKey".ToLower());
            builder.Property(s => s.ContactFirstName).HasColumnName("ContactFirstName".ToLower());
            builder.Property(s => s.ContactLastName).HasColumnName("ContactLastName".ToLower());
            builder.Property(s => s.RelationshipToStudent).HasColumnName("RelationshipToStudent".ToLower());
            builder.Property(s => s.StreetNumberName).HasColumnName("StreetNumberName".ToLower());
            builder.Property(s => s.ApartmentRoomSuiteNumber).HasColumnName("ApartmentRoomSuiteNumber".ToLower());
            builder.Property(s => s.State).HasColumnName("State".ToLower());
            builder.Property(s => s.PostalCode).HasColumnName("PostalCode".ToLower());
            builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber".ToLower());
            builder.Property(s => s.PrimaryEmailAddress).HasColumnName("PrimaryEmailAddress".ToLower());
            builder.Property(s => s.IsPrimaryContact).HasColumnName("IsPrimaryContact".ToLower());
        }
    }
}
