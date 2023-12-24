using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    ///     Represents the root object for option symbols.
    /// </summary>
    public class OptionSymbolsRootobject
    {
        /// <summary>
        ///     Gets or sets the list of symbols.
        /// </summary>
        /// <value>
        ///     The list of symbols.
        /// </value>
        [JsonPropertyName("symbols")]
        public List<Symbol> Symbols { get; set; }
    }

    /// <summary>
    ///     Represents a symbol.
    /// </summary>
    public class Symbol
    {
        /// <summary>
        ///     Gets or sets the root symbol property.
        /// </summary>
        [JsonPropertyName("rootSymbol")]
        public string RootSymbol { get; set; }

        /// <summary>
        ///     Gets or sets the list of options.
        /// </summary>
        /// <value>
        ///     The list of options.
        /// </value>
        [JsonPropertyName("options")]
        public List<string> Options { get; set; }
    }
}