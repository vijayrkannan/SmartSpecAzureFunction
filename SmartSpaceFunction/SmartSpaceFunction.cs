using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartSpaceFunction.Utlities;
using System.Data;
using SmartSpaceFunction.Models;
using System.Net.Http;
using System.Collections.Generic;

namespace SmartSpaceFunction
{
    public static class SmartSpaceFunction
    {
        [FunctionName("SmartSpaceFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string Latitude = req.Query["Latitude"];
            string Longitude = req.Query["Longitude"];
            string testget = req.Query.ToString();
            string requestBody = "";

            if (req.Method == HttpMethods.Post)
            {
                requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            }
            else if (req.Method == HttpMethods.Get)
            {
                requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            }

            string SqlQuery = "[dbo].[usp_getData]";

            List<Location> locations = SqlHelper.excuteQueryandReturnResult(SqlQuery, requestBody, log,context);
            string result = string.Empty;

            result = JsonConvert.SerializeObject(locations);

            string responseMessage = string.IsNullOrEmpty(result) ? string.Empty: result;

            return new OkObjectResult(responseMessage);
        }
    }
}
