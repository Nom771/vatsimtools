using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 

    public class Prefile
    {
        [JsonPropertyName("cid")]
        public int Cid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; set; }

        [JsonPropertyName("flight_plan")]
        public FlightPlan FlightPlan { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }
    }

}