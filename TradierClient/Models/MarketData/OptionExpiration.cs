using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    public class OptionExpirationsRootobject
    {
        [JsonPropertyName("expirations")] public Expirations Expirations { get; set; }
    }

    public class Expirations
    {
        [JsonPropertyName("date")] public List<DateTime> Date { get; set; }
    }
}