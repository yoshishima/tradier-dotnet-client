using System;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    ///     Represents a ClockRootobject that contains a Clock object.
    /// </summary>
    public class ClockRootobject
    {
        /// <summary>
        ///     Represents a clock.
        /// </summary>
        [JsonPropertyName("clock")]
        public Clock Clock { get; set; }
    }

    /// <summary>
    ///     Represents a clock object with date, description, state, timestamp, next change, and next state properties.
    /// </summary>
    public class Clock
    {
        /// <summary>
        ///     Gets or sets the date property.
        /// </summary>
        /// <value>
        ///     The date as a string.
        /// </value>
        [JsonPropertyName("date")]
        public string Date { get; set; }

        /// <summary>
        ///     Gets or sets the description of the property.
        /// </summary>
        /// <value>The description.</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>
        ///     The state.
        /// </value>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the timestamp.
        /// </summary>
        /// <value>
        ///     The timestamp.
        /// </value>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Gets or sets the NextChange property.
        /// </summary>
        /// <value>
        ///     The value of the NextChange property.
        /// </value>
        [JsonPropertyName("next_change")]
        public string NextChange { get; set; }

        /// <summary>
        ///     Gets or sets the next state property.
        /// </summary>
        /// <value>
        ///     The next state.
        /// </value>
        [JsonPropertyName("next_state")]
        public string NextState { get; set; }
    }
}