using Newtonsoft.Json.Linq;
// ReSharper disable InconsistentNaming

namespace EdFi.FIF.GraphQL.Models
{
    public sealed class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}