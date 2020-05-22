using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace EdFi.FIF.GraphQL.Models
{
    public class FIFSchema : Schema
    {
        public FIFSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<FIFQuery>();
        }
    }
}
