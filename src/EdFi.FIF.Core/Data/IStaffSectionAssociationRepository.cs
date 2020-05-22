using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.FIF.Core.Models;


namespace EdFi.FIF.Core.Data
{
    public interface IStaffSectionAssociationRepository
    {
        Task<List<StaffSectionAssociation>> All();
        Task<StaffSectionAssociation> GetByStaff(int staffKey);
        Task<StaffSectionAssociation> GetBySection(string sectionKey);
    }
}