using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    /// Represents the root object for option expirations.
    /// </summary>
    public class OptionExpirationsRootobject
    {
        /// <summary>
        /// Gets or sets the Expirations property.
        /// </summary>
        /// <value>
        /// The Expirations property.
        /// </value>
        [JsonPropertyName("expirations")] public Expirations Expirations { get; set; }
    }

    /// <summary>
    /// Represents a class for keeping track of expirations dates.
    /// </summary>
    public class Expirations
    {
        /// <summary>
        /// Gets or sets the list of Date values.
        /// </summary>
        /// <value>
        /// The list of Date values.
        /// </value>
        [JsonPropertyName("date")] public List<DateTime> Date { get; set; }
    }
}