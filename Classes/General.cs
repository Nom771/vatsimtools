using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 

    public class General
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("reload")]
        public int Reload { get; set; }

        [JsonPropertyName("update")]
        public string Update { get; set; }

        [JsonPropertyName("update_timestamp")]
        public string UpdateTimestamp { get; set; }

        [JsonPropertyName("connected_clients")]
        public int ConnectedClients { get; set; }

        [JsonPropertyName("unique_users")]
        public int UniqueUsers { get; set; }
    }

}