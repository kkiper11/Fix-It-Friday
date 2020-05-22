using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;

namespace EdFi.FIF.GraphQL.Models
{
    public class StaffSectionAssociationType : ObjectGraphType<StaffSectionAssociation>
    {
        public StaffSectionAssociationType(ContextServiceLocator contextServiceLocator)
        {
            Field("staffkey", x => x.StaffKey);
            Field("sectionkey", x => x.SectionKey);
            Field<StringGraphType>("begindate", resolve: context => context.Source.BeginDate);
            Field<StringGraphType>("enddate", resolve: context => context.Source.EndDate);
        }
    }
}