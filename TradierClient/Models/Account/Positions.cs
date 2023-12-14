using System;
using System.Collections.Generic;
using Tradier.Client.Helpers;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Account
{
    public class PositionsRootobject
    {
        [JsonPropertyName("positions")]
        public Positions Positions { get; set; }
    }

    public class Positions
    {
        [JsonPropertyName("position")]
        [JsonConverter(typeof(SingleOrArrayConverter<Position>))]
        public List<Position> Position { get; set; }
    }

    public class Position
    {
        [JsonPropertyName("cost_basis")]
        public float CostBasis { get; set; }

        [JsonPropertyName("date_acquired")]
        public DateTime DateAcquired { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}