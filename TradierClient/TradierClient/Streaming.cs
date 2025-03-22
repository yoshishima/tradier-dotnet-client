using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Streaming
{
    /// <summary>
    ///     Represents a response from the account streaming service.
    /// </summary>
    public class AccountStreamResponse
    {
        /// <summary>
        ///     Gets or sets the type of account event.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the event details.
        /// </summary>
        [JsonPropertyName("event")]
        public AccountEvent Event { get; set; }
    }

    /// <summary>
    ///     Represents various types of account events.
    /// </summary>
    public class AccountEvent
    {
        /// <summary>
        ///     Gets or sets the order event information.
        /// </summary>
        [JsonPropertyName("order")]
        public OrderEvent Order { get; set; }

        /// <summary>
        ///     Gets or sets the trade event information.
        /// </summary>
        [JsonPropertyName("trade")]
        public TradeEvent Trade { get; set; }
    }

    /// <summary>
    ///     Represents an order event in the account stream.
    /// </summary>
    public class OrderEvent
    {
        /// <summary>
        ///     Gets or sets the order ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the account ID.
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the status of the order.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the symbol associated with the order.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the order side (buy/sell).
        /// </summary>
        [JsonPropertyName("side")]
        public string Side { get; set; }

        /// <summary>
        ///     Gets or sets the order quantity.
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the order type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the execution price.
        /// </summary>
        [JsonPropertyName("price")]
        public float? Price { get; set; }

        /// <summary>
        ///     Gets or sets the average fill price.
        /// </summary>
        [JsonPropertyName("avg_fill_price")]
        public float? AvgFillPrice { get; set; }

        /// <summary>
        ///     Gets or sets the executed quantity.
        /// </summary>
        [JsonPropertyName("exec_quantity")]
        public int? ExecQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the last filled price.
        /// </summary>
        [JsonPropertyName("last_fill_price")]
        public float? LastFillPrice { get; set; }

        /// <summary>
        ///     Gets or sets the last filled quantity.
        /// </summary>
        [JsonPropertyName("last_fill_quantity")]
        public int? LastFillQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the remaining quantity.
        /// </summary>
        [JsonPropertyName("remaining_quantity")]
        public int? RemainingQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the time the order was created.
        /// </summary>
        [JsonPropertyName("create_date")]
        public string CreateDate { get; set; }

        /// <summary>
        ///     Gets or sets the transaction date.
        /// </summary>
        [JsonPropertyName("transaction_date")]
        public string TransactionDate { get; set; }

        /// <summary>
        ///     Gets or sets the class of the order.
        /// </summary>
        [JsonPropertyName("class")]
        public string Class { get; set; }

        /// <summary>
        ///     Gets or sets the option symbol if applicable.
        /// </summary>
        [JsonPropertyName("option_symbol")]
        public string OptionSymbol { get; set; }
    }

    /// <summary>
    ///     Represents a trade execution event in the account stream.
    /// </summary>
    public class TradeEvent
    {
        /// <summary>
        ///     Gets or sets the order ID.
        /// </summary>
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        /// <summary>
        ///     Gets or sets the account ID.
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the symbol traded.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the side of the trade (buy/sell).
        /// </summary>
        [JsonPropertyName("side")]
        public string Side { get; set; }

        /// <summary>
        ///     Gets or sets the quantity traded.
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the execution price.
        /// </summary>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        /// <summary>
        ///     Gets or sets the execution ID.
        /// </summary>
        [JsonPropertyName("exec_id")]
        public string ExecId { get; set; }

        /// <summary>
        ///     Gets or sets the execution time.
        /// </summary>
        [JsonPropertyName("exec_time")]
        public string ExecTime { get; set; }

        /// <summary>
        ///     Gets or sets the commission charged.
        /// </summary>
        [JsonPropertyName("commission")]
        public float? Commission { get; set; }

        /// <summary>
        ///     Gets or sets the option symbol if applicable.
        /// </summary>
        [JsonPropertyName("option_symbol")]
        public string OptionSymbol { get; set; }
    }
}