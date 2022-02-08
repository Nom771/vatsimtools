using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 

    public class Pilot
    {
        [JsonPropertyName("cid")]
        public int Cid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; set; }

        [JsonPropertyName("server")]
        public string Server { get; set; }

        [JsonPropertyName("pilot_rating")]
        public int PilotRating { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("altitude")]
        public int Altitude { get; set; }

        [JsonPropertyName("groundspeed")]
        public int Groundspeed { get; set; }

        [JsonPropertyName("transponder")]
        public string Transponder { get; set; }

        [JsonPropertyName("heading")]
        public int Heading { get; set; }

        [JsonPropertyName("qnh_i_hg")]
        public double QnhIHg { get; set; }

        [JsonPropertyName("qnh_mb")]
        public int QnhMb { get; set; }

        [JsonPropertyName("flight_plan")]
        public FlightPlan FlightPlan { get; set; }

        [JsonPropertyName("logon_time")]
        public string LogonTime { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }
    }

}