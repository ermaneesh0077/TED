using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
       // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class AO
    {
        public int ID { get; set; }
        public string country { get; set; }
            public string region { get; set; }
        }

        public class BJ
    {
        public int ID { get; set; }
        public string country { get; set; }
            public string region { get; set; }
        }

        public class BW
    {
        public int ID { get; set; }
        public string country { get; set; }
            public string region { get; set; }
        }

        public class Data
    {
        public int ID { get; set; }
        public DZ DZ { get; set; }
            public AO AO { get; set; }
            public BJ BJ { get; set; }
            public BW BW { get; set; }
        }

        public class DZ
    {
        public int ID { get; set; }
        public string country { get; set; }
            public string region { get; set; }
        }

        public class FacultiesModel
    {
        public int ID { get; set; }
            public string status { get; set; }

            [JsonProperty("status-code")]
            public int statuscode { get; set; }
            public string version { get; set; }
            public string access { get; set; }
            public Data data { get; set; }
        }

 
}