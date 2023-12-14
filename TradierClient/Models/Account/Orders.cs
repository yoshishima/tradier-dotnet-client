using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Account
{

    public class OrdersRootobject
    {
        [JsonPropertyName("orders")]
        public Orders Orders { get; set; }
    }

    public class Orders
    {
        [JsonPropertyName("order")]
        [JsonConverter(typeof(SingleOrArrayConverter<Order>))]
        public List<Order> Order { get; set; }
    }

    public class Order
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("price")]
        public float Price { get; set; }

        [JsonPropertyName("avg_fill_price")]
        public float AvgFillPrice { get; set; }

        [JsonPropertyName("exec_quantity")]
        public float ExecQuantity { get; set; }

        [JsonPropertyName("last_fill_price")]
        public float LastFillPrice { get; set; }

        [JsonPropertyName("last_fill_quantity")]
        public float LastFillQuantity { get; set; }

        [JsonPropertyName("remaining_quantity")]
        public float RemainingQuantity { get; set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [JsonPropertyName("_class")]
        public string Class { get; set; }

        [JsonPropertyName("option_symbol")]
        public string OptionSymbol { get; set; }

        [JsonPropertyName("num_legs")]
        public int NumLegs { get; set; }

        [JsonPropertyName("strategy")]
        public string Strategy { get; set; }

        [JsonPropertyName("stop")]
        public string Stop { get; set; }

        [JsonPropertyName("tag")]
        //Need to check 255 max with only ltetters, numbers and - supported
        public string Tag { get; set; }

        [JsonPropertyName("leg")]
        public Leg[] Leg { get; set; }
    }

    public class Leg
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("price")]
        public float Price { get; set; }

        [JsonPropertyName("avg_fill_price")]
        public float AvgFillPrice { get; set; }

        [JsonPropertyName("exec_quantity")]
        public float ExecQuantity { get; set; }

        [JsonPropertyName("last_fill_price")]
        public float LastFillPrice { get; set; }

        [JsonPropertyName("last_fill_quantity")]
        public float LastFillQuantity { get; set; }

        [JsonPropertyName("remaining_quantity")]
        public float RemainingQuantity { get; set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [JsonPropertyName("_class")]
        public string Class { get; set; }

        [JsonPropertyName("option_symbol")]
        public string OptionSymbol { get; set; }
    }

}
