using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{

    public class TimesalesRootobject
    {
        [JsonPropertyName("series")]
        public Series Series { get; set; }
    }

    public class Series
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("price")]
        public float Price { get; set; }

        [JsonPropertyName("open")]
        public float Open { get; set; }

        [JsonPropertyName("high")]
        public float High { get; set; }

        [JsonPropertyName("low")]
        public float Low { get; set; }

        [JsonPropertyName("close")]
        public float Close { get; set; }

        [JsonPropertyName("volume")]
        public int Volume { get; set; }

        [JsonPropertyName("vwap")]
        public float Vwap { get; set; }
    }
}
