using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 

    public class PilotRating
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        [JsonPropertyName("long_name")]
        public string LongName { get; set; }
    }

}