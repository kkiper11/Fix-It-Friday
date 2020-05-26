using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;
// ReSharper disable InconsistentNaming

namespace EdFi.FIF.GraphQL.Models
{
    public class FIFQuery : ObjectGraphType
    {
        public FIFQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<ListGraphType<StaffType>>(
                "stafflist",
                resolve: (context) => contextServiceLocator.StaffRepository.All()
            );

            Field<StaffType>(
                "staff",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "staffkey" }),
                resolve: (context) => contextServiceLocator.StaffRepository.Get(context.GetArgument<int>("staffkey"))
            );

            Field<StaffType>(
                "sectionsbystaff",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "staffkey" }),
                resolve: (context) => contextServiceLocator.StaffRepository.Get(context.GetArgument<int>("staffkey"))
            );

           
        }
    }
}