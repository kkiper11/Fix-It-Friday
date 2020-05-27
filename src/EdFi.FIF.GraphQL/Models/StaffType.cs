using System.Linq;
using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;
// ReSharper disable VirtualMemberCallInConstructor

namespace EdFi.FIF.GraphQL.Models
{
    public class StaffType : ObjectGraphType<Staff>
    {
        public StaffType(ContextServiceLocator contextServiceLocator)
        {
            Field("staffkey", x => x.StaffKey);
            Field("personaltitleprefix", x => x.PersonalTitlePrefix);
            Field("firstname", x => x.FirstName);
            Field("middlename", x => x.MiddleName);
            Field("lastsurname", x => x.LastSurname);
            Field("staffuniqueid", x => x.StaffUniqueId);
            Field<ListGraphType<SectionType>>("sections",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "staffkey" }),
                resolve: context => contextServiceLocator.SectionRepository.GetBySectionList(contextServiceLocator.StaffSectionAssociationRepository.GetByStaff(context.Source.StaffKey).Result.ToList()), description: "Staff sections");
        }
    }
}