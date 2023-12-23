using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    /// Represents the root object for timesales.
    /// </summary>
    public class TimesalesRootobject
    {
        /// <summary>
        /// Gets or sets the series property.
        /// </summary>
        [JsonPropertyName("series")] public Series Series { get; set; }
    }

    /// <summary>
    /// Represents a series of data.
    /// </summary>
    public class Series
    {
        /// <summary>
        /// Gets or sets the list of Datum objects representing the data.
        /// </summary>
        /// <value>
        /// The list of Datum objects representing the data.
        /// </value>
        [JsonPropertyName("data")] public List<Datum> Data { get; set; }
    }


    /// <summary>
    /// Represents a data point with various properties.
    /// </summary>
    public class Datum
    {
        /// <summary>
        /// Gets or sets the time value.
        /// </summary>
        [JsonPropertyName("time")] public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the property.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the price of the property.
        /// </summary>
        /// <value>The price.</value>
        [JsonPropertyName("price")] public float Price { get; set; }

        /// <summary>
        /// Gets or sets the open value of an object.
        /// </summary>
        /// <remarks>
        /// The open value represents a float value indicating the opening value of an object.
        /// </remarks>
        /// <returns>The open value of an object.</returns>
        [JsonPropertyName("open")]
        public float Open { get; set; }

        /// <summary>
        /// Gets or sets the value of the High property.
        /// </summary>
        /// <value>
        /// The value of the High property.
        /// </value>
        [JsonPropertyName("high")] public float High { get; set; }

        /// <summary>
        /// Gets or sets the value for the 'Low' property.
        /// </summary>
        /// <value>
        /// The low value.
        /// </value>
        [JsonPropertyName("low")] public float Low { get; set; }

        /// <summary>
        /// Gets or sets the Close property.
        /// </summary>
        /// <value>
        /// A floating-point number representing the closing value.
        /// </value>
        /// <remarks>
        /// This property stores the closing value of a particular asset or stock.
        /// </remarks>
        [JsonPropertyName("close")]
        public float Close { get; set; }

        /// <summary>
        /// Gets or sets the volume property.
        /// </summary>
        [JsonPropertyName("volume")] public int Volume { get; set; }

        /// <summary>
        /// Gets or sets the Volume Weighted Average Price (VWAP) of a security.
        /// </summary>
        /// <value>The VWAP value.</value>
        [JsonPropertyName("vwap")] public float Vwap { get; set; }
    }
}