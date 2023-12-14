using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Account
{

    public class HistoryRootobject
    {
        [JsonPropertyName("history")]
        public History History { get; set; }
    }

    public class History
    {
        [JsonPropertyName("event")]
        public List<Event> Event { get; set; }
    }

    public class Event
    {
        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("trade")]
        public Trade Trade { get; set; }

        [JsonPropertyName("adjustment")]
        public Adjustment Adjustment { get; set; }

        [JsonPropertyName("option")]
        public Option Option { get; set; }

        [JsonPropertyName("journal")]
        public Journal Journal { get; set; }
    }

    public class Trade
    {
        [JsonPropertyName("commission")]
        public float Commission { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public float Price { get; set; }

        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("trade_type")]
        public string TradeType { get; set; }
    }

    public class Adjustment
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }
    }

    public class Option
    {
        [JsonPropertyName("option_type")]
        public string OptionType { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }
    }

    public class Journal
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }
    }

}
