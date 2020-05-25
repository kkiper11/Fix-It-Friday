using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;

namespace EdFi.FIF.GraphQL.Models
{
    public class StudentContactType : ObjectGraphType<StudentContact>
    {
        public StudentContactType(ContextServiceLocator contextServiceLocator)
        {
            Field<ContactPersonType>("contact",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "contactkey" }),
                resolve: context => contextServiceLocator.ContactPersonRepository.Get(context.Source.ContactKey), description: "Contact");
        }
    }
}