using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;

namespace EdFi.FIF.GraphQL.Models
{
    public class FIFQuery : ObjectGraphType
    {
        public FIFQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<ListGraphType<StaffType>>(
                "staff",
                resolve: (context) => contextServiceLocator.StaffRepository.All()
            );
            Field<StaffType>(
                "staffsections",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "staffkey" }),
                resolve: (context) => contextServiceLocator.StaffRepository.Get(context.GetArgument<int>("staffkey"))
            );
            Field<SectionType>(
                "sectionstudents",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "sectionkey" }),
                resolve: (context) => contextServiceLocator.SectionRepository.Get(context.GetArgument<string>("sectionkey"))
            );
            Field<ListGraphType<StudentSchoolType>>(
                "students",
                resolve: (context) => contextServiceLocator.StudentSchoolRepository.All()
            );

        }
    }
}