using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
         
        public object GetFacilietesAll()
        {
            var data = new { Id = 1, Type = "Feature",
                geometrytype= "Point",
                geometrycoordinates0 = -94.77066050000000 ,
                geometrycoordinates1 = 37.032057500000000,
                propertiesid= "nca_042"
            };
            return data;
        }

    }
}
