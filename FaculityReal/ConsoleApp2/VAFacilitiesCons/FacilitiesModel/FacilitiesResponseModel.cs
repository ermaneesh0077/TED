using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.FacilitiesModel
{
    internal class FacilitiesResponseModel
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
    
   
    public class Address
    {
        public Mailing mailing { get; set; }
        public Physical physical { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Hours
    {
        public string Friday { get; set; }
        public string Monday { get; set; }
        public string Sunday { get; set; }
        public string Tuesday { get; set; }
        public string Saturday { get; set; }
        public string Thursday { get; set; }
        public string Wednesday { get; set; }
    }

    public class Mailing
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public object address_3 { get; set; }
    }

    public class OperatingStatus
    {
        public string code { get; set; }
        public string additional_info { get; set; }
    }

    public class Phone
    {
        public string fax { get; set; }
        public string main { get; set; }
    }

    public class Physical
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public object address_3 { get; set; }
    }

    public class Properties
    {
        public string id { get; set; }
        public string name { get; set; }
        public string facility_type { get; set; }
        public string classification { get; set; }
        public string website { get; set; }
        public string time_zone { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }
        public Hours hours { get; set; }
        public object operational_hours_special_instructions { get; set; }
        public Services services { get; set; }
        public Satisfaction satisfaction { get; set; }
        public WaitTimes wait_times { get; set; }
        public object mobile { get; set; }
        public string active_status { get; set; }
        public OperatingStatus operating_status { get; set; }
        public object detailed_services { get; set; }
        public object visn { get; set; }
    }

    

    public class Satisfaction
    {
        public string effective_date { get; set; }

    }

    public class Services
    {
        public List<string> benefits { get; set; }
    }

    public class WaitTimes
    {
    }


}
