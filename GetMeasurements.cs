using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunctionsAPISQL
{
    public static class GetMeasurements
    {
        [FunctionName("GetMeasurements")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            await using var context = new MyContext();
            List<Measurement> list = context.Measurements.ToList();
            return new OkObjectResult(list);
        }
    }
}
