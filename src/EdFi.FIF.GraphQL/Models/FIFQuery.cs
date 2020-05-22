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
            Field<ListGraphType<StudentSchoolType>>(
                "staffsections",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "staffkey" }),
                resolve: (context) => contextServiceLocator.StaffRepository.Get(context.GetArgument<int>("staffkey"))
            );
            Field<ListGraphType<StudentSchoolType>>(
                "studentschoollist",
                resolve: (context) => contextServiceLocator.StudentSchoolRepository.All()
            );

        }
    }
}