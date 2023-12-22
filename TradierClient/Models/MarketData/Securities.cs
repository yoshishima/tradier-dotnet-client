using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    public class SecuritiesRootobject
    {
        [JsonPropertyName("securities")] public Securities Securities { get; set; }
    }

    public class Securities
    {
        [JsonPropertyName("security")] public List<Security> Security { get; set; }
    }

    public class Security
    {
        [JsonPropertyName("symbol")] public string Symbol { get; set; }

        [JsonPropertyName("exchange")] public string Exchange { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }
    }
}