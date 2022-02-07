using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VatTools{ 
    public class FeedRoot
    {
        [JsonPropertyName("general")]
        public General General { get; set; }

        [JsonPropertyName("pilots")]
        public List<Pilot> Pilots { get; set; }

        [JsonPropertyName("controllers")]
        public List<Controller> Controllers { get; set; }

        [JsonPropertyName("atis")]
        public List<Atis> Atis { get; set; }

        [JsonPropertyName("servers")]
        public List<Server> Servers { get; set; }

        [JsonPropertyName("prefiles")]
        public List<Prefile> Prefiles { get; set; }

        [JsonPropertyName("facilities")]
        public List<Facility> Facilities { get; set; }

        [JsonPropertyName("ratings")]
        public List<Rating> Ratings { get; set; }

        [JsonPropertyName("pilot_ratings")]
        public List<PilotRating> PilotRatings { get; set; }
    }

}