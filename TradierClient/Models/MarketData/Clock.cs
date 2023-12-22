using System;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    public class ClockRootobject
    {
        [JsonPropertyName("clock")] public Clock Clock { get; set; }
    }

    public class Clock
    {
        [JsonPropertyName("date")] public string Date { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("state")] public string State { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("next_change")] public string NextChange { get; set; }

        [JsonPropertyName("next_state")] public string NextState { get; set; }
    }
}