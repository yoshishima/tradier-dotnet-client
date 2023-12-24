using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    ///     Represents the root object for option strikes.
    /// </summary>
    public class OptionStrikesRootobject
    {
        /// <summary>
        ///     Gets or sets the Strikes property.
        /// </summary>
        /// <value>The Strikes property.</value>
        [JsonPropertyName("strikes")]
        public Strikes Strikes { get; set; }
    }

    /// <summary>
    ///     Represents a class that holds a list of strike values.
    /// </summary>
    public class Strikes
    {
        /// <summary>
        ///     Gets or sets the strike property.
        /// </summary>
        /// <value>
        ///     The strike property as a list of floats.
        /// </value>
        [JsonPropertyName("strike")]
        public List<float> Strike { get; set; }
    }
}