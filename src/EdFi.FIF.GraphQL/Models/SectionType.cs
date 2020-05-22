using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;

namespace EdFi.FIF.GraphQL.Models
{
    public class SectionType : ObjectGraphType<Section>
    {
        public SectionType(ContextServiceLocator contextServiceLocator)
        {
            Field("sectionkey", x => x.SectionKey);
            Field("schoolkey", x => x.SchoolKey);
            Field("localcoursecode", x => x.LocalCourseCode);
            Field("sessionname", x => x.SessionName);
            Field("sectionidentifier", x => x.SectionIdentifier);
            Field("schoolyear", x => x.SchoolYear);
            Field<ListGraphType<StudentSectionType>>("students",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "sectionkey" }),
                resolve: context => contextServiceLocator.StudentSectionRepository.GetBySection(context.Source.SectionKey), description: "Section");
        }
    }
}