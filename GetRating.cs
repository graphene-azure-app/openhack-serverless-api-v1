using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SOH19DryRunFunctionApp.Models;
using System.Collections.Generic;

namespace SOH19DryRunFunctionApp
{
    public static class GetRating
    {
        [FunctionName("GetRating")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ratings/{id}")] HttpRequest req,
            [CosmosDB("BFYOC", "ratings", ConnectionStringSetting = "CosmosDBConnection", SqlQuery = "Select * from ratings r where r.id = {id}")] IEnumerable<RatingModel> rating,
            ILogger log)
        {
            log.LogInformation("Getting Rating");
            if (rating == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return new OkObjectResult(rating);
            }
        }
    }
}

/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SOH19DryRunFunctionApp.Models;
using System.Collections.Generic;

namespace SOH19DryRunFunctionApp
{
    public static class GetRating
    {
        [FunctionName("GetRating")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ratings/{id}")] HttpRequest req,
            [CosmosDB("%RatingsDbName%", "%RatingsCollectionName%", ConnectionStringSetting = "RatingsDatabase", SqlQuery = "Select * from ratings r where r.id = {id}")]IEnumerable<RatingModel> rating,
            ILogger log)
        {
            log.LogInformation("Getting Rating");
            if (rating == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return new OkObjectResult(rating);
            }
        }
    }
}
*/