using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EdFi.FIF.GraphQL.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
// ReSharper disable InconsistentNaming

namespace EdFi.FIF.GraphQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }
       
        /*private readonly ILogger<GraphQLController> _logger;

        public GraphQLController(ILogger<GraphQLController> logger)
        {
            _logger = logger;
        }*/

        [HttpPost]
        public async Task<string> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var watch = Stopwatch.StartNew();

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
            
            var objectResult = Write(result);

            watch.Stop();

            //log.Info($"{Environment.NewLine}{query.Query.ToString()}{Environment.NewLine} executed in {watch.ElapsedMilliseconds} ms");

            return objectResult;
        }
        private string Write(ExecutionResult result)
        {
            return JsonConvert.SerializeObject(
                result,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}
