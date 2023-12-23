using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    /// Represents the root object for historical quotes.
    /// </summary>
    public class HistoricalQuotesRootobject
    {
        /// <summary>
        /// Gets or sets the historical quotes for the property.
        /// </summary>
        /// <value>
        /// The historical quotes for the property.
        /// </value>
        [JsonPropertyName("history")] public HistoricalQuotes History { get; set; }
    }

    /// <summary>
    /// Represents historical quotes for a particular asset.
    /// </summary>
    public class HistoricalQuotes
    {
        /// <summary>
        /// Represents a list of days.
        /// </summary>
        [JsonPropertyName("day")]
        [JsonConverter(typeof(SingleOrArrayConverter<Day>))]
        public List<Day> Day { get; set; }
    }

    /// <summary>
    /// Represents a specific day's financial data.
    /// </summary>
    public class Day
    {
        /// <summary>
        /// Gets or sets the value of the Date property.
        /// </summary>
        /// <remarks>
        /// This property represents the date associated with an object.
        /// </remarks>
        /// <value>
        /// The value of the Date property.
        /// </value>
        /// <example>
        /// <code>
        /// string date = obj.Date;
        /// </code>
        /// </example>
        [JsonPropertyName("date")] public string Date { get; set; }

        /// <summary>
        /// Gets or sets the value of the "Open" property.
        /// </summary>
        /// <value>The opening value.</value>
        [JsonPropertyName("open")] public float Open { get; set; }

        /// <summary>
        /// Gets or sets the value of the 'high' property.
        /// </summary>
        /// <value>
        /// The value of the 'high' property.
        /// </value>
        [JsonPropertyName("high")] public float High { get; set; }

        /// <summary>
        /// Gets or sets the value of the "Low" property.
        /// </summary>
        /// <value>
        /// The value of the "Low" property.
        /// </value>
        [JsonPropertyName("low")] public float Low { get; set; }

        /// <summary>
        /// Gets or sets the value representing the "close" property.
        /// </summary>
        /// <value>
        /// The value of the "close" property.
        /// </value>
        [JsonPropertyName("close")] public float Close { get; set; }

        /// <summary>
        /// Gets or sets the volume of the property.
        /// </summary>
        [JsonPropertyName("volume")] public long Volume { get; set; }
    }
}