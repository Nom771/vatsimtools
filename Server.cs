using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 

    public class Server
    {
        [JsonPropertyName("ident")]
        public string Ident { get; set; }

        [JsonPropertyName("hostname_or_ip")]
        public string HostnameOrIp { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("clients_connection_allowed")]
        public int ClientsConnectionAllowed { get; set; }

        [JsonPropertyName("client_connections_allowed")]
        public bool ClientConnectionsAllowed { get; set; }

        [JsonPropertyName("is_sweatbox")]
        public bool IsSweatbox { get; set; }
    }

}