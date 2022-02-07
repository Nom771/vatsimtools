using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 

    public class Rating
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("short")]
        public string Short { get; set; }

        [JsonPropertyName("long")]
        public string Long { get; set; }
    }

}