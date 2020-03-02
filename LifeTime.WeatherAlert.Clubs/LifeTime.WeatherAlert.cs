/*
 *LifeTime.AzureFunction.weatherAlert.API
 *Author: Nuradin Ahmed
 *Description: This is simple PoC to use Azure Function HTTP Request from Azure SQL DB
 */

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Host;
using LifeTime.WeatherAlert.Clubs.Repositories;
using System.Net;

namespace LifeTime.WeatherAlert.Clubs
{
    //private static readonly HttpClient


    public static class LifeTimeWeatherAlert 
    {

        [FunctionName("LifeTimeWeatherAlert")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestMessage req, TraceWriter log)

        {
            log.Info("C# HTTP trigger function processed a request.");

            var weatherClubRepository = new weatherClubRepository();

            var weatherClubList = weatherClubRepository.getLatestWeatherAlert();

            if (weatherClubList == null)
            {
                log.Error("No Foreseable Weather Alerts -");
                //return req.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "The Requested resources does not exit");
            }

            return req.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "The Requested resources does not exit");


        }
    }
}

