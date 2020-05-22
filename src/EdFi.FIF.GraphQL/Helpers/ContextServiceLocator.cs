using EdFi.FIF.Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.FIF.GraphQL.Helpers
{
    public class ContextServiceLocator
    {
        public IStudentSchoolRepository StudentSchoolRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IStudentSchoolRepository>();
        
        public IContactPersonRepository ContactPersonRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IContactPersonRepository>();

        public ISectionRepository SectionRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ISectionRepository>();

        public IStaffRepository StaffRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IStaffRepository>();

        public IStaffSectionAssociationRepository StaffSectionAssociationRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IStaffSectionAssociationRepository>();

        public IStudentContactRepository StudentContactRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IStudentContactRepository>();

        public IStudentSectionRepository StudentSectionRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IStudentSectionRepository>();
       
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
