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

                 int i = 0;
                foreach (var item in FacilitiesResponseModel.features)
                {
                    i++;
                    if (i > 0)
                    {




                        var geoType = item.geometry.type;

                        var coordinates0 = item.geometry.coordinates?[0];
                        var coordinates1 = item.geometry.coordinates?[1];
                        var propertiesid = item.properties.id;
                        var propertiesname = item.properties.name.Replace("'", "");
                        var propertiesfacility_type = item.properties.facility_type;
                        var propertiesoperating_statuscode = item.properties.operating_status.code;
                        var propertiesdetailed_services = string.Empty; //item.properties.detailed_services;
                        var propertiesclassification = item.properties.classification;
                        var propertieswebsite = item.properties.website;
                        var propertiestime_zone = item.properties.time_zone;
                        var propertiesaddressmailingzip = item.properties.address.mailing.zip;
                        var propertiesaddressmailingcity = item.properties.address.mailing.city?.Replace("'", "")?.Replace(",", " ");
                        var propertiesaddressmailingstate = item.properties.address.mailing.state;
                        var propertiesaddressmailingaddress_1 = item.properties.address.mailing.address_1?.Replace("'", "");
                        var propertiesaddressmailingaddress_2 = item.properties.address.mailing.address_2?.Replace("'", "")?.Replace(",", " ");
                        var propertiesaddressmailingaddress_3 = item.properties.address.mailing.address_3;


                        var propertiesaddressphysicalzip = item.properties.address.physical.zip;
                        var propertiesaddressphysicalcity = item.properties.address.physical.city?.Replace("'", "")?.Replace(",", " ");
                        var propertiesaddressphysicalstate = item.properties.address.physical.state?.Replace("'", "")?.Replace(",", " ");
                        var propertiesaddressphysicaladdress_1 = item.properties.address.physical.address_1?.Replace("'", " ")?.Replace(",", "");
                        var propertiesaddressphysicaladdress_2 = item.properties.address.physical.address_2?.Replace("'", " ")?.Replace(",", " ");
                        var propertiesaddressphysicaladdress_3 = item.properties.address.physical.address_3;
                        var propertiesphonefax = item.properties.phone.fax;
                        var propertiesphonemain = item.properties.phone.main;
                        var propertieshoursFriday1 = item.properties.hours.Friday;
                        var propertieshoursMonday1 = item.properties.hours.Monday;
                        var propertieshoursSunday1 = item.properties.hours.Sunday;
                        var propertieshoursTuesday1 = item.properties.hours.Tuesday;
                        var propertieshoursSaturday1 = item.properties.hours.Saturday;
                        var propertieshoursThursday1 = item.properties.hours.Thursday;
                        var propertieshoursWednesday1 = item.properties.hours.Wednesday;
                        var propertiesoperational_hours_special_instructions = item.properties.operational_hours_special_instructions;
                        var propertiesmobile = item.properties.mobile;
                        var propertiesactive_status = item.properties.active_status;

                        int propertiesvisn = item.properties.visn == null ? 0 : Convert.ToInt16(item.properties.visn);
                        var propertiesservicesbenefits0 = string.Empty;
                        var propertiesservicesbenefits1 = string.Empty;
                        var propertiesservicesbenefits2 = string.Empty;
                        var propertiesservicesbenefits3 = string.Empty;
                        var propertiesservicesbenefits4 = string.Empty;
                        var propertiesservicesbenefits5 = string.Empty;
                        var propertiesservicesbenefits6 = string.Empty;
                        var propertiesservicesbenefits7 = string.Empty;
                        var propertiesservicesbenefits8 = string.Empty;
                        var propertiesservicesbenefits9 = string.Empty;

                        var propertiesservicesbenefits10 = string.Empty;
                        var propertiesservicesbenefits11 = string.Empty;
                        var propertiesservicesbenefits12 = string.Empty;
                        var propertiesservicesbenefits13 = string.Empty;
                        var propertiesservicesbenefits14 = string.Empty;
                        if (item.properties.services.benefits != null)
                        {
                            propertiesservicesbenefits0 = item.properties.services.benefits.Count > 0 ? item.properties.services.benefits[0] : string.Empty;
                            propertiesservicesbenefits1 = item.properties.services.benefits.Count > 1 ? item.properties.services.benefits[1] : string.Empty;
                            propertiesservicesbenefits2 = item.properties.services.benefits.Count > 2 ? item.properties.services.benefits[2] : string.Empty;
                            propertiesservicesbenefits3 = item.properties.services.benefits.Count > 3 ? item.properties.services.benefits[3] : string.Empty;
                            propertiesservicesbenefits4 = item.properties.services.benefits.Count > 4 ? item.properties.services.benefits[4] : string.Empty;
                            propertiesservicesbenefits5 = item.properties.services.benefits.Count > 5 ? item.properties.services.benefits[5] : string.Empty;
                            propertiesservicesbenefits6 = item.properties.services.benefits.Count > 6 ? item.properties.services.benefits[6] : string.Empty;
                            propertiesservicesbenefits7 = item.properties.services.benefits.Count > 7 ? item.properties.services.benefits[7] : string.Empty;
                            propertiesservicesbenefits8 = item.properties.services.benefits.Count > 8 ? item.properties.services.benefits[8] : string.Empty;
                            propertiesservicesbenefits9 = item.properties.services.benefits.Count > 9 ? item.properties.services.benefits[9] : string.Empty;


                            propertiesservicesbenefits10 = item.properties.services.benefits.Count > 10 ? item.properties.services.benefits[10] : string.Empty; ;

                            propertiesservicesbenefits11 = item.properties.services.benefits.Count > 11 ? item.properties.services.benefits[11] : string.Empty;
                            propertiesservicesbenefits12 = item.properties.services.benefits.Count > 12 ? item.properties.services.benefits[12] : string.Empty;
                            propertiesservicesbenefits13 = item.properties.services.benefits.Count > 13 ? item.properties.services.benefits[13] : string.Empty;
                            propertiesservicesbenefits14 = item.properties.services.benefits.Count > 14 ? item.properties.services.benefits[14] : string.Empty;

                        }
                        var propertiesoperating_statusadditional_info = item.properties.operating_status.additional_info?.Replace("'", " ");
                        var propertieshoursfriday2 = item.properties.hours.Friday;
                        var propertieshoursmonday2 = item.properties.hours.Monday;
                        var propertieshourssunday2 = item.properties.hours.Sunday;
                        var propertieshourstuesday2 = item.properties.hours.Tuesday;
                        var propertieshourssaturday2 = item.properties.hours.Saturday;
                        var propertieshoursthursday2 = item.properties.hours.Thursday;
                        var propertieshourswednesday2 = item.properties.hours.Wednesday;
                        var propertiesphonepharmacy = string.Empty; //item.properties.phone.p;
                        var propertiesphoneafter_hours = string.Empty;
                        var propertiesphonepatient_advocate = string.Empty;
                        var propertiesphonemental_health_clinic = string.Empty;
                        var propertiesphoneenrollment_coordinator = string.Empty;
                        var propertiesphonehealth_connect = string.Empty;
                        var propertiesserviceshealth0 = string.Empty; //item.properties.services;
                        var propertiesserviceshealth1 = string.Empty;
                        var propertiesserviceshealth2 = string.Empty; ;
                        var propertiesserviceshealth3 = string.Empty; ;
                        var propertiesserviceshealth4 = string.Empty; ;
                        var propertiesserviceshealth5 = string.Empty; ;
                        var propertiesserviceshealth6 = string.Empty; ;
                        var propertiesserviceshealth7 = string.Empty; ;
                        var propertiesserviceshealth8 = string.Empty; ;
                        var propertiesserviceshealth9 = string.Empty; ;
                        var propertiesserviceshealth10 = string.Empty; ;
                        var propertiesserviceshealth11 = string.Empty; ;
                        var propertiesserviceshealth12 = string.Empty; ;
                        var propertiesserviceshealth13 = string.Empty; ;
                        var propertiesserviceshealth14 = string.Empty; ;
                        var propertiesserviceshealth15 = string.Empty; ;
                        var propertiesserviceshealth16 = string.Empty; ;
                        var propertiesserviceshealth17 = string.Empty; ;
                        var propertiesserviceshealth18 = string.Empty; ;

                        var propertiesserviceslast_updated = string.Empty;
                        var propertiessatisfactionhealthprimary_care_urgent = 0;
                        var propertiessatisfactionhealthprimary_care_routine = 0;
                        var propertiessatisfactionhealthspecialty_care_urgent = 0;
                        var propertiessatisfactionhealthspecialty_care_routine = 0;
                        var propertiessatisfactioneffective_date = item.properties.satisfaction.effective_date;

                        var propertieswait_timeshealth0service = string.Empty;
                        var propertieswait_timeshealth0new = string.Empty;
                        var propertieswait_timeshealth0established = string.Empty;
                        var propertieswait_timeshealth1service = string.Empty;
                        var propertieswait_timeshealth1new = string.Empty;
                        var propertieswait_timeshealth1established = string.Empty;
                        var propertieswait_timeshealth2service = string.Empty;
                        var propertieswait_timeshealth2new = string.Empty;
                        var propertieswait_timeshealth2established = string.Empty;
                        var propertieswait_timeshealth3service = string.Empty;
                        var propertieswait_timeshealth3new = string.Empty;
                        var propertieswait_timeshealth3established = string.Empty;
                        var propertieswait_timeshealth4service = string.Empty;
                        var propertieswait_timeshealth4new = string.Empty;
                        var propertieswait_timeshealth4established = string.Empty;
                        var propertieswait_timeshealth5service = string.Empty;
                        var propertieswait_timeshealth5new = string.Empty;
                        var propertieswait_timeshealth5established = string.Empty;
                        var propertieswait_timeshealth6service = string.Empty;
                        var propertieswait_timeshealth6new = string.Empty;
                        var propertieswait_timeshealth6established = string.Empty;
                        var propertieswait_timeshealth7service = string.Empty;
                        var propertieswait_timeshealth7new = string.Empty;
                        var propertieswait_timeshealth7established = string.Empty;
                        var propertieswait_timeshealth8service = string.Empty;
                        var propertieswait_timeshealth8new = string.Empty;
                        var propertieswait_timeshealth8established = string.Empty;
                        var propertieswait_timeshealth9service = string.Empty;
                        var propertieswait_timeshealth9new = string.Empty;
                        var propertieswait_timeshealth9established = string.Empty;
                        var propertieswait_timeshealth10service = string.Empty;
                        var propertieswait_timeshealth10new = string.Empty;
                        var propertieswait_timeshealth10established = string.Empty;
                        var propertieswait_timeshealth11service = string.Empty;
                        var propertieswait_timeshealth11new = string.Empty;
                        var propertieswait_timeshealth11established = string.Empty;
                        var propertieswait_timeseffective_date = string.Empty;
                        var propertiesoperating_statussupplemental_status0id = string.Empty;
                        var propertiesoperating_statussupplemental_status0label = string.Empty;
                        var propertiesdetailed_services0name = string.Empty;
                        var propertiesdetailed_services0description_facility = string.Empty;
                        var propertiesdetailed_services0appointment_leadin = string.Empty;
                        var propertiesdetailed_services0appointment_phones = string.Empty;
                        var propertiesdetailed_services0online_scheduling_available = string.Empty;
                        var propertiesdetailed_services0referral_required = string.Empty;
                        var propertiesdetailed_services0walk_ins_accepted = string.Empty;
                        var propertiesdetailed_services0path = string.Empty;
                        var propertiesdetailed_services0appointment_phones0extension = string.Empty;
                        var propertiesdetailed_services0appointment_phones0label = string.Empty;
                        var propertiesdetailed_services0appointment_phones0number = string.Empty;
                        var propertiesdetailed_services0appointment_phones0type = string.Empty;
                        var propertiesdetailed_services0appointment_phones1extension = string.Empty;
                        var propertiesdetailed_services0appointment_phones1label = string.Empty;
                        var propertiesdetailed_services0appointment_phones1number = string.Empty;
                        var propertiesdetailed_services0appointment_phones1type = string.Empty;
                        var propertiesdetailed_services0appointment_phones2extension = string.Empty;
                        var propertiesdetailed_services0appointment_phones2label = string.Empty;
                        var propertiesdetailed_services0appointment_phones2number = string.Empty;
                        var propertiesdetailed_services0appointment_phones2type = string.Empty;


                        query.Append($"INSERT INTO [FacilitiesAllTable1] " +
                                $"([type],geometrytype,[geometrycoordinates0],[geometrycoordinates1],[propertiesid],[propertiesname],[propertiesfacility_type],propertiestime_zone," +
                                $"[propertiesoperating_statuscode]" +
                                $",[propertiesdetailed_services]" +
                                $",[propertiesclassification]" +
                                $",[propertieswebsite]" +
                                $",[propertiesaddressmailingzip],[propertiesaddressmailingcity]" +
                                $",[propertiesaddressmailingstate],[propertiesaddressmailingaddress_1],propertiesaddressmailingaddress_2" +
                                $",propertiesaddressmailingaddress_3,propertiesaddressphysicalzip  ,propertiesaddressphysicalcity ,propertiesaddressphysicalstate ,propertiesaddressphysicaladdress_1,propertiesaddressphysicaladdress_2,propertiesaddressphysicaladdress_3,propertiesphonefax ,propertiesphonemain ,propertieshoursFriday1,propertieshoursMonday1,propertieshoursSunday1 ,propertieshoursTuesday1,propertieshoursSaturday1 ,propertieshoursThursday1,propertieshoursWednesday1 ,propertiesoperational_hours_special_instructions,propertiesmobile ,propertiesactive_status , propertiesvisn,propertiesservicesbenefits0,propertiesservicesbenefits1,propertiesservicesbenefits2,propertiesservicesbenefits3,propertiesservicesbenefits4,propertiesservicesbenefits5,propertiesservicesbenefits6,propertiesservicesbenefits7,propertiesservicesbenefits8,propertiesservicesbenefits9,propertiesoperating_statusadditional_info ,propertiesservicesbenefits10,propertiesservicesbenefits11,propertiesservicesbenefits12,propertiesservicesbenefits13,propertiesservicesbenefits14,propertieshoursfriday2 ,propertieshoursmonday2,propertieshourssunday2,propertieshourstuesday2 ,propertieshourssaturday2,propertieshoursthursday2,propertieshourswednesday2 ,propertiesphonepharmacy ,propertiesphoneafter_hours ,propertiesphonepatient_advocate ,propertiesphonemental_health_clinic ,propertiesphoneenrollment_coordinator ,propertiesphonehealth_connect,propertiesserviceshealth0 ,propertiesserviceshealth1 ,propertiesserviceshealth2 ,propertiesserviceshealth3 ,propertiesserviceshealth4 ,propertiesserviceshealth5 ,propertiesserviceshealth6 ,propertiesserviceshealth7 ,propertiesserviceshealth8 ,propertiesserviceshealth9 ,propertiesserviceshealth10 ,propertiesserviceshealth11 ,propertiesserviceshealth12,propertiesserviceshealth13,propertiesserviceshealth14,propertiesserviceshealth15,propertiesserviceshealth16,propertiesserviceshealth17,propertiesserviceshealth18,propertiesserviceslast_updated ,propertiessatisfactionhealthprimary_care_urgent,propertiessatisfactionhealthprimary_care_routine,propertiessatisfactionhealthspecialty_care_urgent,propertiessatisfactionhealthspecialty_care_routine,propertiessatisfactioneffective_date ,propertieswait_timeshealth0service ,propertieswait_timeshealth0new,propertieswait_timeshealth0established,propertieswait_timeshealth1service ,propertieswait_timeshealth1new,propertieswait_timeshealth1established,propertieswait_timeshealth2service ,propertieswait_timeshealth2new,propertieswait_timeshealth2established,propertieswait_timeshealth3service ,propertieswait_timeshealth3new,propertieswait_timeshealth3established,propertieswait_timeshealth4service ,propertieswait_timeshealth4new,propertieswait_timeshealth4established,propertieswait_timeshealth5service ,propertieswait_timeshealth5new,propertieswait_timeshealth5established,propertieswait_timeshealth6service ,propertieswait_timeshealth6new,propertieswait_timeshealth6established,propertieswait_timeshealth7service,propertieswait_timeshealth7new,propertieswait_timeshealth7established,propertieswait_timeshealth8service,propertieswait_timeshealth8new,propertieswait_timeshealth8established,propertieswait_timeshealth9service,propertieswait_timeshealth9new,propertieswait_timeshealth9established,propertieswait_timeshealth10service,propertieswait_timeshealth10new,propertieswait_timeshealth10established,propertieswait_timeshealth11service,propertieswait_timeshealth11new,propertieswait_timeshealth11established,propertieswait_timeseffective_date ,propertiesoperating_statussupplemental_status0id,propertiesoperating_statussupplemental_status0label,propertiesdetailed_services0name ,propertiesdetailed_services0description_facility ,propertiesdetailed_services0appointment_leadin ,propertiesdetailed_services0appointment_phones ,propertiesdetailed_services0online_scheduling_available ,propertiesdetailed_services0referral_required ,propertiesdetailed_services0walk_ins_accepted ,propertiesdetailed_services0path ,propertiesdetailed_services0appointment_phones0extension ,propertiesdetailed_services0appointment_phones0label ,propertiesdetailed_services0appointment_phones0number,propertiesdetailed_services0appointment_phones0type,propertiesdetailed_services0appointment_phones1extension ,propertiesdetailed_services0appointment_phones1label ,propertiesdetailed_services0appointment_phones1number,propertiesdetailed_services0appointment_phones1type,propertiesdetailed_services0appointment_phones2extension ,propertiesdetailed_services0appointment_phones2label ,propertiesdetailed_services0appointment_phones2number,propertiesdetailed_services0appointment_phones2type) " +
                                $"VALUES( '{type}','{geoType}',{coordinates0},{coordinates1},'{propertiesid}','{propertiesname}','{propertiesfacility_type}','{propertiestime_zone}'" +
                                $",'{propertiesoperating_statuscode}'," +
                                $"'{propertiesdetailed_services}'" +
                                $",'{propertiesclassification}'" +
                                $",'{propertieswebsite}'" +
                                $",'{propertiesaddressmailingzip}','{propertiesaddressmailingcity}','{propertiesaddressmailingstate}','{propertiesaddressmailingaddress_1}','{propertiesaddressmailingaddress_2}'" +
                                $",'{propertiesaddressmailingaddress_3}','{propertiesaddressphysicalzip}','{propertiesaddressphysicalcity}','{propertiesaddressphysicalstate}','{propertiesaddressphysicaladdress_1}','{propertiesaddressphysicaladdress_2}','{propertiesaddressphysicaladdress_3}','{propertiesphonefax}','{propertiesphonemain}','{propertieshoursFriday1}','{propertieshoursMonday1}','{propertieshoursSunday1}','{propertieshoursTuesday1}','{propertieshoursSaturday1}','{propertieshoursThursday1}','{propertieshoursWednesday1}','{propertiesoperational_hours_special_instructions}','{propertiesmobile}','{propertiesactive_status}'," +
                                $"{propertiesvisn},'{propertiesservicesbenefits0}','{propertiesservicesbenefits1}','{propertiesservicesbenefits2}','{propertiesservicesbenefits3}','{propertiesservicesbenefits4}','{propertiesservicesbenefits5}','{propertiesservicesbenefits6}','{propertiesservicesbenefits7}','{propertiesservicesbenefits8}','{propertiesservicesbenefits9}','{propertiesoperating_statusadditional_info}','{propertiesservicesbenefits10}','{propertiesservicesbenefits11}','{propertiesservicesbenefits12}','{propertiesservicesbenefits13}','{propertiesservicesbenefits14}','{propertieshoursfriday2}','{propertieshoursmonday2}','{propertieshourssunday2}','{propertieshourstuesday2}','{propertieshourssaturday2}','{propertieshoursthursday2}','{propertieshourswednesday2}','{propertiesphonepharmacy}','{propertiesphoneafter_hours}','{propertiesphonepatient_advocate}','{propertiesphonemental_health_clinic}','{propertiesphoneenrollment_coordinator}','{propertiesphonehealth_connect}','{propertiesserviceshealth0}','{propertiesserviceshealth1}','{propertiesserviceshealth2}','{propertiesserviceshealth3}','{propertiesserviceshealth4}','{propertiesserviceshealth5}','{propertiesserviceshealth6}','{propertiesserviceshealth7}','{propertiesserviceshealth8}','{propertiesserviceshealth9}','{propertiesserviceshealth10}','{propertiesserviceshealth11}','{propertiesserviceshealth12}','{propertiesserviceshealth13}','{propertiesserviceshealth14}','{propertiesserviceshealth15}','{propertiesserviceshealth16}','{propertiesserviceshealth17}','{propertiesserviceshealth18}','{propertiesserviceslast_updated}',{propertiessatisfactionhealthprimary_care_urgent}" +
                                $",{propertiessatisfactionhealthprimary_care_routine},{propertiessatisfactionhealthspecialty_care_urgent}" +
                                $",{propertiessatisfactionhealthspecialty_care_routine}" +
                                $",'{propertiessatisfactioneffective_date}','{propertieswait_timeshealth0service}','{propertieswait_timeshealth0new}','{propertieswait_timeshealth0established}','{propertieswait_timeshealth1service}','{propertieswait_timeshealth1new}','{propertieswait_timeshealth1established}','{propertieswait_timeshealth2service}','{propertieswait_timeshealth2new}','{propertieswait_timeshealth2established}','{propertieswait_timeshealth3service}','{propertieswait_timeshealth3new}','{propertieswait_timeshealth3established}','{propertieswait_timeshealth4service}','{propertieswait_timeshealth4new}','{propertieswait_timeshealth4established}','{propertieswait_timeshealth5service}','{propertieswait_timeshealth5new}','{propertieswait_timeshealth5established}','{propertieswait_timeshealth6service}','{propertieswait_timeshealth6new}','{propertieswait_timeshealth6established}','{propertieswait_timeshealth7service}','{propertieswait_timeshealth7new}','{propertieswait_timeshealth7established}','{propertieswait_timeshealth8service}','{propertieswait_timeshealth8new}','{propertieswait_timeshealth8established}','{propertieswait_timeshealth9service}','{propertieswait_timeshealth9new}','{propertieswait_timeshealth9established}','{propertieswait_timeshealth10service}','{propertieswait_timeshealth10new}','{propertieswait_timeshealth10established}','{propertieswait_timeshealth11service}','{propertieswait_timeshealth11new}','{propertieswait_timeshealth11established}','{propertieswait_timeseffective_date}','{propertiesoperating_statussupplemental_status0id}','{propertiesoperating_statussupplemental_status0label}','{propertiesdetailed_services0name}','{propertiesdetailed_services0description_facility}','{propertiesdetailed_services0appointment_leadin}','{propertiesdetailed_services0appointment_phones}','{propertiesdetailed_services0online_scheduling_available}','{propertiesdetailed_services0referral_required}','{propertiesdetailed_services0walk_ins_accepted}','{propertiesdetailed_services0path}','{propertiesdetailed_services0appointment_phones0extension}','{propertiesdetailed_services0appointment_phones0label}','{propertiesdetailed_services0appointment_phones0number}','{propertiesdetailed_services0appointment_phones0type}','{propertiesdetailed_services0appointment_phones1extension}','{propertiesdetailed_services0appointment_phones1label}','{propertiesdetailed_services0appointment_phones1number}','{propertiesdetailed_services0appointment_phones1type}','{propertiesdetailed_services0appointment_phones2extension}','{propertiesdetailed_services0appointment_phones2label}','{propertiesdetailed_services0appointment_phones2number}','{propertiesdetailed_services0appointment_phones2type}');");




                        
                    }
                 }

                SqlCommand cmd = new SqlCommand(query.ToString(), con);
                cmd.ExecuteNonQuery();
                res = true;
                return res;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return res;
        }
    }
}
