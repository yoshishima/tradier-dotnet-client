using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    public class OptionStrikesRootobject
    {
        [JsonPropertyName("strikes")] public Strikes Strikes { get; set; }
    }

    public class Strikes
    {
        [JsonPropertyName("strike")] public List<float> Strike { get; set; }
    }
}