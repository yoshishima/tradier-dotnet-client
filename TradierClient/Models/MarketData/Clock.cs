using System;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    public class ClockRootobject
    {
        [JsonPropertyName("clock")] public Clock Clock { get; set; } = null!; // Initialize for nullability
    }

    public enum MarketState
    {
        Unknown,
        Open,
        Closed,
        PreMarket,
        PostMarket
    }

    public class Clock
    {
        // Could use a custom converter for "YYYY-MM-DD" format
        [JsonPropertyName("date")] public string Date { get; set; } = string.Empty;

        [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MarketState State { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime Timestamp { get; set; }

        // Could use TimeOnly in .NET 6+ or custom converter
        [JsonPropertyName("next_change")] public string NextChange { get; set; } = string.Empty;

        [JsonPropertyName("next_state")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MarketState NextState { get; set; }

        // Helper methods for working with the time format
        public TimeSpan? GetNextChangeAsTimeSpan()
        {
            if (TimeSpan.TryParse(NextChange, out var result))
                return result;
            return null;
        }

        // Helper method to get the date from string
        public DateTime? GetDateAsDateTime()
        {
            if (DateTime.TryParse(Date, out var result))
                return result;
            return null;
        }
    }
}