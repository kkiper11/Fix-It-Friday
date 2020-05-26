using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;

namespace EdFi.FIF.GraphQL.Models
{
    public class StaffSectionAssociationType : ObjectGraphType<StaffSectionAssociation>
    {
        public StaffSectionAssociationType(ContextServiceLocator contextServiceLocator)
        {
            Field<SectionType>("section",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "sectionkey" }),
                resolve: context => contextServiceLocator.SectionRepository.Get(context.Source.SectionKey), description: "Section");
        }
    }
}