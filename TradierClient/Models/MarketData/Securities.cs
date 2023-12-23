using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    /// Represents the root object for securities.
    /// </summary>
    public class SecuritiesRootobject
    {
        /// <summary>
        /// Gets or sets the securities.
        /// </summary>
        /// <value>
        /// The securities.
        /// </value>
        [JsonPropertyName("securities")] public Securities Securities { get; set; }
    }

    /// <summary>
    /// Represents a collection of securities.
    /// </summary>
    public class Securities
    {
        /// <summary>
        /// Gets or sets the list of securities.
        /// </summary>
        [JsonPropertyName("security")] public List<Security> Security { get; set; }
    }

    /// <summary>
    /// Represents a security.
    /// </summary>
    public class Security
    {
        /// <summary>
        /// Gets or sets the symbol property.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        [JsonPropertyName("symbol")] public string Symbol { get; set; }

        /// <summary>
        /// Getter and setter for the Exchange property.
        /// </summary>
        /// <value>The value of the Exchange property.</value>
        [JsonPropertyName("exchange")] public string Exchange { get; set; }

        /// <summary>
        /// Gets or sets the Type property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        [JsonPropertyName("type")] public string Type { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonPropertyName("description")] public string Description { get; set; }
    }
}