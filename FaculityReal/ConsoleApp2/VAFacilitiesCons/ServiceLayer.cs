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
                    var propertiesoperating_statuscode = item.properties.operating_status.code;
                    var propertiesdetailed_services = string.Empty; //item.properties.detailed_services;
                    var propertiesclassification = item.properties.classification;
                    var propertieswebsite = item.properties.website;
                    var propertiestime_zone=item.properties.time_zone;
                    var propertiesaddressmailingzip=item.properties.address.mailing.zip;
                    var propertiesaddressmailingcity = item.properties.address.mailing.city;
                    var propertiesaddressmailingstate=item.properties.address.mailing.state;
                    var propertiesaddressmailingaddress_1 = item.properties.address.mailing.address_1;
                    var propertiesaddressmailingaddress_2 = item.properties.address.mailing.address_2;
                    var propertiesaddressmailingaddress_3 = item.properties.address.mailing.address_3;


                    var propertiesaddressphysicalzip= item.properties.address.physical.zip;
                    var propertiesaddressphysicalcity= item.properties.address.physical.city;
                    var propertiesaddressphysicalstate= item.properties.address.physical.state;
                    var propertiesaddressphysicaladdress_1= item.properties.address.physical.address_1;
                    var propertiesaddressphysicaladdress_2= item.properties.address.physical.address_2;
                    var propertiesaddressphysicaladdress_3= item.properties.address.physical.address_3;
                    var propertiesphonefax= item.properties.phone.fax;
                    var propertiesphonemain = item.properties.phone.main;
                    var propertieshoursFriday1= item.properties.hours.Friday;
                    var propertieshoursMonday1= item.properties.hours.Monday;
                    var propertieshoursSunday1= item.properties.hours.Sunday;
                    var propertieshoursTuesday1= item.properties.hours.Tuesday;
                    var propertieshoursSaturday1= item.properties.hours.Saturday;
                    var propertieshoursThursday1= item.properties.hours.Thursday;
                    var propertieshoursWednesday1= item.properties.hours.Wednesday;
                    var propertiesoperational_hours_special_instructions= item.properties.operational_hours_special_instructions;
                    var propertiesmobile= item.properties.mobile;
                    var propertiesactive_status= item.properties.active_status;
                    
                    var propertiesvisn= item.properties.visn;
                    var propertiesservicesbenefits0= item.properties.services.benefits[0];
                    var propertiesservicesbenefits1= item.properties.services.benefits[1];
                    var propertiesservicesbenefits2= item.properties.services.benefits[2];
                    var propertiesservicesbenefits3= item.properties.services.benefits[3];
                    var propertiesservicesbenefits4= item.properties.services.benefits[4];
                    var propertiesservicesbenefits5= item.properties.services.benefits[5];
                    var propertiesservicesbenefits6= item.properties.services.benefits[6];
                    var propertiesservicesbenefits7= item.properties.services.benefits[7];
                    var propertiesservicesbenefits8= item.properties.services.benefits[8];
                    var propertiesservicesbenefits9 = item.properties.services.benefits[9];
                    var propertiesoperating_statusadditional_info= item.properties.operating_status.additional_info;
                    var propertiesservicesbenefits10= item.properties.services.benefits[10];
                    var propertiesservicesbenefits11= item.properties.services.benefits[11];
                    var propertiesservicesbenefits12= item.properties.services.benefits[12];
                    var propertiesservicesbenefits13= item.properties.services.benefits[13];
                    var propertiesservicesbenefits14 = item.properties.services.benefits[14];
                    var propertieshoursfriday2= item.properties.hours.Friday;
                    var propertieshoursmonday2 = item.properties.hours.Monday;
                    var propertieshourssunday2 = item.properties.hours.Sunday;
                    var propertieshourstuesday2 = item.properties.hours.Tuesday;
                    var propertieshourssaturday2 = item.properties.hours.Saturday;
                    var propertieshoursthursday2 = item.properties.hours.Thursday;
                    var propertieshourswednesday2 = item.properties.hours.Wednesday;
                    var propertiesphonepharmacy = string.Empty; //item.properties.phone.p;
                    var propertiesphoneafter_hours = string.Empty;
                    var propertiesphonepatient_advocate =string.Empty;
                    var propertiesphonemental_health_clinic;
                    var propertiesphoneenrollment_coordinator;
                    var propertiesphonehealth_connect;
                    var propertiesserviceshealth0;
                    var propertiesserviceshealth1;
                    var propertiesserviceshealth2;
                    var propertiesserviceshealth3;
                    var propertiesserviceshealth4;
                    var propertiesserviceshealth5;
                    var propertiesserviceshealth6;
                    var propertiesserviceshealth7;
                    var propertiesserviceshealth8;
                    var propertiesserviceshealth9;
                    var propertiesserviceshealth10;
                    var propertiesserviceshealth11;
                    var propertiesserviceshealth12;
                    var propertiesserviceshealth13;
                    var propertiesserviceshealth14;
                    var propertiesserviceshealth15;
                    var propertiesserviceshealth16;
                    var propertiesserviceshealth17;
                    var propertiesserviceshealth18;

                    var propertiesserviceslast_updated;
                    var propertiessatisfactionhealthprimary_care_urgent;
                    var propertiessatisfactionhealthprimary_care_routine;
                    var propertiessatisfactionhealthspecialty_care_urgent;
                    var propertiessatisfactionhealthspecialty_care_routine;
                    var propertiessatisfactioneffective_date;

                    var propertieswait_timeshealth0service;
                    var propertieswait_timeshealth0new;
                    var propertieswait_timeshealth0established;
                    var propertieswait_timeshealth1service;
                    var propertieswait_timeshealth1new;
                    var propertieswait_timeshealth1established;
                    var propertieswait_timeshealth2service;
                    var propertieswait_timeshealth2new;
                    var propertieswait_timeshealth2established;
                    var propertieswait_timeshealth3service;
                    var propertieswait_timeshealth3new;
                    var propertieswait_timeshealth3established;
                    var propertieswait_timeshealth4service;
                    var propertieswait_timeshealth4new;
                    var propertieswait_timeshealth4established;
                    var propertieswait_timeshealth5service;
                    var propertieswait_timeshealth5new;
                    var propertieswait_timeshealth5established;
                    var propertieswait_timeshealth6service;
                    var propertieswait_timeshealth6new;
                    var propertieswait_timeshealth6established;
                    var propertieswait_timeshealth7service;
                    var propertieswait_timeshealth7new;
                    var propertieswait_timeshealth7established;
                    var propertieswait_timeshealth8service;
                    var propertieswait_timeshealth8new;
                    var propertieswait_timeshealth8established;
                    var propertieswait_timeshealth9service;
                    var propertieswait_timeshealth9new;
                    var propertieswait_timeshealth9established;
                    var propertieswait_timeshealth10service;
                    var propertieswait_timeshealth10new;
                    var propertieswait_timeshealth10established;
                    var propertieswait_timeshealth11service;
                    var propertieswait_timeshealth11new;
                    var propertieswait_timeshealth11established;
                    var propertieswait_timeseffective_date;
                    var propertiesoperating_statussupplemental_status0id;
                    var propertiesoperating_statussupplemental_status0label;
                    var propertiesdetailed_services0name;
                    var propertiesdetailed_services0description_facility;
                    var propertiesdetailed_services0appointment_leadin;
                    var propertiesdetailed_services0appointment_phones;
                    var propertiesdetailed_services0online_scheduling_available;
                    var propertiesdetailed_services0referral_required;
                    var propertiesdetailed_services0walk_ins_accepted;
                    var propertiesdetailed_services0path;
                    var propertiesdetailed_services0appointment_phones0extension;
                    var propertiesdetailed_services0appointment_phones0label;
                    var propertiesdetailed_services0appointment_phones0number;
                    var propertiesdetailed_services0appointment_phones0type;
                    var propertiesdetailed_services0appointment_phones1extension;
                    var propertiesdetailed_services0appointment_phones1label;
                    var propertiesdetailed_services0appointment_phones1number;
                    var propertiesdetailed_services0appointment_phones1type;
                    var propertiesdetailed_services0appointment_phones2extension;
                    var propertiesdetailed_services0appointment_phones2label;
                    var propertiesdetailed_services0appointment_phones2number;
                    var propertiesdetailed_services0appointment_phones2type;


                    query.Append($"INSERT INTO [FacilitiesAllTable1] " +
                            $"([type],geometrytype,[geometrycoordinates0],[geometrycoordinates1],[propertiesid],[propertiesname],[propertiesfacility_type],propertiestime_zone," +
                            $"[propertiesoperating_statuscode]" +
                            $",[propertiesdetailed_services]" +
                            $",[propertiesclassification]" +
                            $",[propertieswebsite]" +
                            $",[propertiesaddressmailingzip],[propertiesaddressmailingcity]" +
                            $",[propertiesaddressmailingstate],[propertiesaddressmailingaddress_1],propertiesaddressmailingaddress_2" +
                            $",propertiesaddressmailingaddress_3,propertiesaddressphysicalzip  ,propertiesaddressphysicalcity ,propertiesaddressphysicalstate ,propertiesaddressphysicaladdress_1,propertiesaddressphysicaladdress_2,propertiesaddressphysicaladdress_3,propertiesphonefax ,propertiesphonemain ,propertieshoursFriday1,propertieshoursMonday1,propertieshoursSunday1 ,propertieshoursTuesday1,propertieshoursSaturday1 ,propertieshoursThursday1,propertieshoursWednesday1 ,propertiesoperational_hours_special_instructions,propertiesmobile ,propertiesactive_status , propertiesdetailed_services ,propertiesvisn,propertiesservicesbenefits0,propertiesservicesbenefits1,propertiesservicesbenefits2,propertiesservicesbenefits3,propertiesservicesbenefits4,propertiesservicesbenefits5,propertiesservicesbenefits6,propertiesservicesbenefits7,propertiesservicesbenefits8,propertiesservicesbenefits9,propertiesoperating_statusadditional_info ,propertiesservicesbenefits10,propertiesservicesbenefits11,propertiesservicesbenefits12,propertiesservicesbenefits13,propertiesservicesbenefits14,propertieshoursfriday2 ,propertieshoursmonday2,propertieshourssunday2,propertieshourstuesday2 ,propertieshourssaturday2,propertieshoursthursday2,propertieshourswednesday2 ,propertiesphonepharmacy ,propertiesphoneafter_hours ,propertiesphonepatient_advocate ,propertiesphonemental_health_clinic ,propertiesphoneenrollment_coordinator ,propertiesphonehealth_connect,propertiesserviceshealth0 ,propertiesserviceshealth1 ,propertiesserviceshealth2 ,propertiesserviceshealth3 ,propertiesserviceshealth4 ,propertiesserviceshealth5 ,propertiesserviceshealth6 ,propertiesserviceshealth7 ,propertiesserviceshealth8 ,propertiesserviceshealth9 ,propertiesserviceshealth10 ,propertiesserviceshealth11 ,propertiesserviceshealth12,propertiesserviceshealth13,propertiesserviceshealth14,propertiesserviceshealth15,propertiesserviceshealth16,propertiesserviceshealth17,propertiesserviceshealth18,propertiesserviceslast_updated ,propertiessatisfactionhealthprimary_care_urgent,propertiessatisfactionhealthprimary_care_routine,propertiessatisfactionhealthspecialty_care_urgent,propertiessatisfactionhealthspecialty_care_routine,propertiessatisfactioneffective_date ,propertieswait_timeshealth0service ,propertieswait_timeshealth0new,propertieswait_timeshealth0established,propertieswait_timeshealth1service ,propertieswait_timeshealth1new,propertieswait_timeshealth1established,propertieswait_timeshealth2service ,propertieswait_timeshealth2new,propertieswait_timeshealth2established,propertieswait_timeshealth3service ,propertieswait_timeshealth3new,propertieswait_timeshealth3established,propertieswait_timeshealth4service ,propertieswait_timeshealth4new,propertieswait_timeshealth4established,propertieswait_timeshealth5service ,propertieswait_timeshealth5new,propertieswait_timeshealth5established,propertieswait_timeshealth6service ,propertieswait_timeshealth6new,propertieswait_timeshealth6established,propertieswait_timeshealth7service,propertieswait_timeshealth7new,propertieswait_timeshealth7established,propertieswait_timeshealth8service,propertieswait_timeshealth8new,propertieswait_timeshealth8established,propertieswait_timeshealth9service,propertieswait_timeshealth9new,propertieswait_timeshealth9established,propertieswait_timeshealth10service,propertieswait_timeshealth10new,propertieswait_timeshealth10established,propertieswait_timeshealth11service,propertieswait_timeshealth11new,propertieswait_timeshealth11established,propertieswait_timeseffective_date ,propertiesoperating_statussupplemental_status0id,propertiesoperating_statussupplemental_status0label,propertiesdetailed_services0name ,propertiesdetailed_services0description_facility ,propertiesdetailed_services0appointment_leadin ,propertiesdetailed_services0appointment_phones ,propertiesdetailed_services0online_scheduling_available ,propertiesdetailed_services0referral_required ,propertiesdetailed_services0walk_ins_accepted ,propertiesdetailed_services0path ,propertiesdetailed_services0appointment_phones0extension ,propertiesdetailed_services0appointment_phones0label ,propertiesdetailed_services0appointment_phones0number,propertiesdetailed_services0appointment_phones0type,propertiesdetailed_services0appointment_phones1extension ,propertiesdetailed_services0appointment_phones1label ,propertiesdetailed_services0appointment_phones1number,propertiesdetailed_services0appointment_phones1type,propertiesdetailed_services0appointment_phones2extension ,propertiesdetailed_services0appointment_phones2label ,propertiesdetailed_services0appointment_phones2number,propertiesdetailed_services0appointment_phones2type) " +
                            $"VALUES( '{type}','{geoType}',{coordinates0},{coordinates1},'{propertiesid}','{propertiesname}','{propertiesfacility_type}','{propertiestime_zone}'" +
                            $",'{propertiesoperating_statuscode}'," +
                            $"'{propertiesdetailed_services}'" +
                            $",'{propertiesclassification}'" +
                            $",'{propertieswebsite}'" +
                            $",'{propertiesaddressmailingzip}','{propertiesaddressmailingcity}','{propertiesaddressmailingstate}','{propertiesaddressmailingaddress_1}','{propertiesaddressmailingaddress_2}'" +
                            $",'{propertiesaddressmailingaddress_3}','{propertiesaddressphysicalzip  }','{propertiesaddressphysicalcity }','{propertiesaddressphysicalstate }','{propertiesaddressphysicaladdress_1}','{propertiesaddressphysicaladdress_2}','{propertiesaddressphysicaladdress_3}','{propertiesphonefax }','{propertiesphonemain }','{propertieshoursFriday1}','{propertieshoursMonday1}','{propertieshoursSunday1 }','{propertieshoursTuesday1}','{propertieshoursSaturday1 }','{propertieshoursThursday1}','{propertieshoursWednesday1 }','{propertiesoperational_hours_special_instructions}','{propertiesmobile }','{propertiesactive_status }', '{propertiesdetailed_services }','{propertiesvisn}','{propertiesservicesbenefits0}','{propertiesservicesbenefits1}','{propertiesservicesbenefits2}','{propertiesservicesbenefits3}','{propertiesservicesbenefits4}','{propertiesservicesbenefits5}','{propertiesservicesbenefits6}','{propertiesservicesbenefits7}','{propertiesservicesbenefits8}','{propertiesservicesbenefits9}','{propertiesoperating_statusadditional_info }','{propertiesservicesbenefits10}','{propertiesservicesbenefits11}','{propertiesservicesbenefits12}','{propertiesservicesbenefits13}','{propertiesservicesbenefits14}','{propertieshoursfriday2 }','{propertieshoursmonday2}','{propertieshourssunday2}','{propertieshourstuesday2 }','{propertieshourssaturday2}','{propertieshoursthursday2}','{propertieshourswednesday2 }','{propertiesphonepharmacy }','{propertiesphoneafter_hours }','{propertiesphonepatient_advocate }','{propertiesphonemental_health_clinic }','{propertiesphoneenrollment_coordinator }','{propertiesphonehealth_connect}','{propertiesserviceshealth0 }','{propertiesserviceshealth1 }','{propertiesserviceshealth2 }','{propertiesserviceshealth3 }','{propertiesserviceshealth4 }','{propertiesserviceshealth5 }','{propertiesserviceshealth6 }','{propertiesserviceshealth7 }','{propertiesserviceshealth8 }','{propertiesserviceshealth9 }','{propertiesserviceshealth10 }','{propertiesserviceshealth11 }','{propertiesserviceshealth12}','{propertiesserviceshealth13}','{propertiesserviceshealth14}','{propertiesserviceshealth15}','{propertiesserviceshealth16}','{propertiesserviceshealth17}','{propertiesserviceshealth18}','{propertiesserviceslast_updated }','{propertiessatisfactionhealthprimary_care_urgent}','{propertiessatisfactionhealthprimary_care_routine}','{propertiessatisfactionhealthspecialty_care_urgent}','{propertiessatisfactionhealthspecialty_care_routine}','{propertiessatisfactioneffective_date }','{propertieswait_timeshealth0service }','{propertieswait_timeshealth0new}','{propertieswait_timeshealth0established}','{propertieswait_timeshealth1service }','{propertieswait_timeshealth1new}','{propertieswait_timeshealth1established}','{propertieswait_timeshealth2service }','{propertieswait_timeshealth2new}','{propertieswait_timeshealth2established}','{propertieswait_timeshealth3service }','{propertieswait_timeshealth3new}','{propertieswait_timeshealth3established}','{propertieswait_timeshealth4service }','{propertieswait_timeshealth4new}','{propertieswait_timeshealth4established}','{propertieswait_timeshealth5service }','{propertieswait_timeshealth5new}','{propertieswait_timeshealth5established}','{propertieswait_timeshealth6service }','{propertieswait_timeshealth6new}','{propertieswait_timeshealth6established}','{propertieswait_timeshealth7service}','{propertieswait_timeshealth7new}','{propertieswait_timeshealth7established}','{propertieswait_timeshealth8service}','{propertieswait_timeshealth8new}','{propertieswait_timeshealth8established}','{propertieswait_timeshealth9service}','{propertieswait_timeshealth9new}','{propertieswait_timeshealth9established}','{propertieswait_timeshealth10service}','{propertieswait_timeshealth10new}','{propertieswait_timeshealth10established}','{propertieswait_timeshealth11service}','{propertieswait_timeshealth11new}','{propertieswait_timeshealth11established}','{propertieswait_timeseffective_date }','{propertiesoperating_statussupplemental_status0id}','{propertiesoperating_statussupplemental_status0label}','{propertiesdetailed_services0name }','{propertiesdetailed_services0description_facility }','{propertiesdetailed_services0appointment_leadin }','{propertiesdetailed_services0appointment_phones }','{propertiesdetailed_services0online_scheduling_available }','{propertiesdetailed_services0referral_required }','{propertiesdetailed_services0walk_ins_accepted }','{propertiesdetailed_services0path }','{propertiesdetailed_services0appointment_phones0extension }','{propertiesdetailed_services0appointment_phones0label }','{propertiesdetailed_services0appointment_phones0number}','{propertiesdetailed_services0appointment_phones0type}','{propertiesdetailed_services0appointment_phones1extension }','{propertiesdetailed_services0appointment_phones1label }','{propertiesdetailed_services0appointment_phones1number}','{propertiesdetailed_services0appointment_phones1type}','{propertiesdetailed_services0appointment_phones2extension }','{propertiesdetailed_services0appointment_phones2label }','{propertiesdetailed_services0appointment_phones2number}','{propertiesdetailed_services0appointment_phones2type}');");
                     
                    
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
