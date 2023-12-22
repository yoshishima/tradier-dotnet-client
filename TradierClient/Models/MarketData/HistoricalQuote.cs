using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    public class HistoricalQuotesRootobject
    {
        [JsonPropertyName("history")] public HistoricalQuotes History { get; set; }
    }

    public class HistoricalQuotes
    {
        [JsonPropertyName("day")]
        [JsonConverter(typeof(SingleOrArrayConverter<Day>))]
        public List<Day> Day { get; set; }
    }

    public class Day
    {
        [JsonPropertyName("date")] public string Date { get; set; }

        [JsonPropertyName("open")] public float Open { get; set; }

        [JsonPropertyName("high")] public float High { get; set; }

        [JsonPropertyName("low")] public float Low { get; set; }

        [JsonPropertyName("close")] public float Close { get; set; }

        [JsonPropertyName("volume")] public long Volume { get; set; }
    }
}