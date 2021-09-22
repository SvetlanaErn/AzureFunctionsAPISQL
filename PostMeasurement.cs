using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace AzureFunctionsAPISQL
{
    public static class PostMeasurement
    {
       
        [FunctionName("PostMeasurement")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Measurement data = JsonConvert.DeserializeObject<Measurement>(requestBody);
                if (data.DateTime == DateTime.MinValue) return new BadRequestObjectResult("date missing");

                await using var context = new MyContext();
                context.Measurements.Add(data);
                context.SaveChanges();
                return new OkResult();
            }
            catch
            {
                return new BadRequestObjectResult("wrong format");
            }
        }
    }
}
