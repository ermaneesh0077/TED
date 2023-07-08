using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = ConfigurationManager.ConnectionStrings["FileWritePath"].ConnectionString;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


            //string vaUrl = ConfigurationManager.ConnectionStrings["VaUrl"].ConnectionString;
            //string apiKey = ConfigurationManager.ConnectionStrings["ApiKey"].ConnectionString;
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, $"{vaUrl}");
            //request.Headers.Add("apikey", $"{apiKey}");
            //Task<HttpResponseMessage> task = Task.Run<HttpResponseMessage>(async () => await client.SendAsync(request));             
            //var jsonResponse = task.Result.Content.ReadAsStringAsync().Result;
            //FileHelper.WriteFileAsync(filePath, "Facilities.txt", jsonResponse);
            string jsonFilePath = @"C:\Users\USER\Downloads\response_Facilities_all - Copy.json";

            string json = File.ReadAllText(jsonFilePath);
            var d = ServiceLayer.ImportJson(connectionString, json);
        }

    }
}
