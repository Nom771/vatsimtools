using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools
{
    public class Root
    {
        [JsonPropertyName("callsign")]
        public string Callsign { get; set; }
        [JsonPropertyName("transceivers")]
        public List<Transceiver> Transcievers { get; set; }
    }
}
