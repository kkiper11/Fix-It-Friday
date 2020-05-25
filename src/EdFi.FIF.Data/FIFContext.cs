using EdFi.FIF.Core.Models;
using EdFi.FIF.Data.Configurations;
using Microsoft.EntityFrameworkCore;
// ReSharper disable InconsistentNaming

namespace EdFi.FIF.Data
{
    public class FIFContext : DbContext
    {
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
            modelBuilder.HasDefaultSchema("fif");

            modelBuilder.ApplyConfiguration(new ContactPersonConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new StaffSectionAssociationConfiguration());
            modelBuilder.ApplyConfiguration(new StudentContactConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSchoolConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSectionConfiguration());
        }
    }
}
