using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;


namespace EdFi.FIF.Core.Data
{
    public interface IStaffSectionAssociationRepository
    {
        Task<List<StaffSectionAssociation>> All();
        Task<List<StaffSectionAssociation>> GetByStaff(int staffKey);
        Task<List<StaffSectionAssociation>> GetBySection(string sectionKey);
    }
}