using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 
    public class Atis
    {
        [JsonPropertyName("cid")]
        public int Cid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; set; }

        [JsonPropertyName("frequency")]
        public string Frequency { get; set; }

        [JsonPropertyName("facility")]
        public int Facility { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("server")]
        public string Server { get; set; }

        [JsonPropertyName("visual_range")]
        public int VisualRange { get; set; }

        [JsonPropertyName("atis_code")]
        public string AtisCode { get; set; }

        [JsonPropertyName("text_atis")]
        public List<string> TextAtis { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("logon_time")]
        public string LogonTime { get; set; }
    }

}