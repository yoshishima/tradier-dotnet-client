using System;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Trading
{
    public class OrderPreviewResponseRootobject
    {
        [JsonPropertyName("order")]
        public OrderPreviewResponse OrderPreviewResponse { get; set; }
    }

    public class OrderPreviewResponse : IOrder
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("commission")]
        public float? Commision { get; set; }

        [JsonPropertyName("cost")]
        public float? Cost { get; set; }

        [JsonPropertyName("fees")]
        public float? Fees { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("result")]
        public bool? Result { get; set; }

        [JsonPropertyName("order_cost")]
        public float? OrderCost { get; set; }

        [JsonPropertyName("margin_change")]
        public float? MarginChange { get; set; }

        [JsonPropertyName("request_date")]
        public DateTime? RequestDate { get; set; }

        [JsonPropertyName("extended_hours")]
        public bool? ExtendedHours { get; set; }

        [JsonPropertyName("class")]
        public string ClassOrder { get; set; }

        [JsonPropertyName("strategy")]
        public string Strategy { get; set; }

        [JsonPropertyName("day_trades")]
        public int? DayTrades { get; set; }
    }
}
