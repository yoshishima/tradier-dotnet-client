using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{

    public class OptionSymbolsRootobject
    {
        [JsonPropertyName("symbols")]
        public List<Symbol> Symbols { get; set; }
    }

    public class Symbol
    {
        [JsonPropertyName("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonPropertyName("options")]
        public List<string> Options { get; set; }
    }

}
