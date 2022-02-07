using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 

    public class FlightPlan
    {
        [JsonPropertyName("flight_rules")]
        public string FlightRules { get; set; }

        [JsonPropertyName("aircraft")]
        public string Aircraft { get; set; }

        [JsonPropertyName("aircraft_faa")]
        public string AircraftFaa { get; set; }

        [JsonPropertyName("aircraft_short")]
        public string AircraftShort { get; set; }

        [JsonPropertyName("departure")]
        public string Departure { get; set; }

        [JsonPropertyName("arrival")]
        public string Arrival { get; set; }

        [JsonPropertyName("alternate")]
        public string Alternate { get; set; }

        [JsonPropertyName("cruise_tas")]
        public string CruiseTas { get; set; }

        [JsonPropertyName("altitude")]
        public string Altitude { get; set; }

        [JsonPropertyName("deptime")]
        public string Deptime { get; set; }

        [JsonPropertyName("enroute_time")]
        public string EnrouteTime { get; set; }

        [JsonPropertyName("fuel_time")]
        public string FuelTime { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("route")]
        public string Route { get; set; }

        [JsonPropertyName("revision_id")]
        public int RevisionId { get; set; }

        [JsonPropertyName("assigned_transponder")]
        public string AssignedTransponder { get; set; }
    }

}