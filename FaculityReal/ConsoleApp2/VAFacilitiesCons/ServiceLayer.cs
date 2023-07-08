using ConsoleApp2.FacilitiesModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ServiceLayer
    {
        public static bool ImportJson(string connectionString, string jsonresponse)
        {

            SqlConnection con = new SqlConnection(connectionString);
            FacilitiesResponseModel myDeserializedClass = JsonConvert.DeserializeObject<FacilitiesResponseModel>(jsonresponse);
            bool res = CreateInsertQuery(myDeserializedClass, connectionString);
             
            return res;
        }

        private static bool CreateInsertQuery(FacilitiesResponseModel FacilitiesResponseModel, string connectionString)
        {
            bool res = false;
            var query = new StringBuilder();
            var type = "Feature";

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                query.Append("truncate table FacilitiesAllTable1;");

                foreach (var item in FacilitiesResponseModel.features)
                {
                    var geoType = item.geometry.type;

                    var coordinates0 = item.geometry.coordinates?[0];
                    var coordinates1 = item.geometry.coordinates?[1];
                    var propertiesid = item.properties.id;
                    var propertiesname = item.properties.name.Replace("'", "");
                    var propertiesfacility_type = item.properties.facility_type;
                    var propertiestime_zone=item.properties.time_zone;
                    var propertiesoperating_statuscode = item.properties.operating_status.code;
                    
                    var propertiesdetailed_services=item.properties.detailed_services;
                    query.Append($"INSERT INTO [FacilitiesAllTable1] " +
                        $"([type],geometrytype,[geometrycoordinates0],[geometrycoordinates1],[propertiesid],[propertiesname],[propertiesfacility_type],propertiestime_zone," +
                        $"[propertiesoperating_statuscode]" +
                        $",[propertiesdetailed_services]) " +
                        $"VALUES( '{type}','{geoType}',{coordinates0},{coordinates1},'{propertiesid}','{propertiesname}','{propertiesfacility_type}','{propertiestime_zone}','{propertiesoperating_statuscode}'," +
                        $"'{propertiesdetailed_services}');");
                    
                }
                SqlCommand cmd = new SqlCommand(query.ToString(), con);
                cmd.ExecuteNonQuery();
                res = true;

                return res;

            }
            catch (Exception ex)
            {


            }
            return res;
        }
    }
}
