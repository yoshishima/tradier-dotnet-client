using System;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Trading
{
    /// <summary>
    /// Represents the root object of the order preview response.
    /// </summary>
    public class OrderPreviewResponseRootobject
    {
        /// <summary>
        /// Represents the response object for order preview.
        /// </summary>
        [JsonPropertyName("order")]
        public OrderPreviewResponse OrderPreviewResponse { get; set; }
    }

    /// <summary>
    /// Represents a response object that contains the preview details of an order.
    /// </summary>
    public class OrderPreviewResponse : IOrder
    {
        /// <summary>
        /// Gets or sets the status property.
        /// </summary>
        /// <value>
        /// The status property.
        /// </value>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the commission value.
        /// </summary>
        /// <value>
        /// The commission value.
        /// </value>
        [JsonPropertyName("commission")]
        public float? Commision { get; set; }

        /// <summary>
        /// Gets or sets the cost of the property.
        /// </summary>
        /// <value>
        /// The cost of the property. If not specified, value is null.
        /// </value>
        [JsonPropertyName("cost")]
        public float? Cost { get; set; }

        /// <summary>
        /// Gets or sets the fees for a property.
        /// </summary>
        /// <value>
        /// The fees for the property. It can be null if no fees are applicable.
        /// </value>
        [JsonPropertyName("fees")]
        public float? Fees { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// An integer representing the quantity. Can be null.
        /// </value>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Represents the side of an object.
        /// </summary>
        /// <value>The side of an object.</value>
        /// <remarks>
        /// This property represents the side of an object. It can have different values depending on the context in which it is used.
        /// For example, in a geometric shape, it could represent the side of the shape (e.g. "top", "bottom", "left", "right").
        /// </remarks>
        [JsonPropertyName("side")]
        public string Side { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the duration of the property.
        /// </summary>
        /// <value>
        /// The duration of the property.
        /// </value>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Result"/> property.
        /// </summary>
        /// <value>
        /// The result of the operation. It is a nullable boolean.
        /// </value>
        [JsonPropertyName("result")]
        public bool? Result { get; set; }

        /// <summary>
        /// Gets or sets the cost of the order.
        /// </summary>
        /// <remarks>
        /// This property represents the cost of the order in a floating-point format.
        /// </remarks>
        [JsonPropertyName("order_cost")]
        public float? OrderCost { get; set; }

        /// <summary>
        /// Represents the margin change property.
        /// </summary>
        /// <remarks>
        /// The margin change property indicates the change in margin value.
        /// </remarks>
        [JsonPropertyName("margin_change")]
        public float? MarginChange { get; set; }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        [JsonPropertyName("request_date")]
        public DateTime? RequestDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether extended hours are available.
        /// </summary>
        /// <value>
        /// <c>true</c> if extended hours are available; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Extending trading hours beyond regular market hours allows for trading of assets even when the market is closed.
        /// If this property is set to <c>true</c>, extended hours trading is available for the specified assets.
        /// If this property is set to <c>false</c>, extended hours trading is not available for the specified assets.
        /// </remarks>
        [JsonPropertyName("extended_hours")]
        public bool? ExtendedHours { get; set; }

        /// <summary>
        /// Gets or sets the class order.
        /// </summary>
        /// <value>
        /// The class order as a string.
        /// </value>
        [JsonPropertyName("class")]
        public string ClassOrder { get; set; }

        /// <summary>
        /// Gets or sets the strategy.
        /// </summary>
        [JsonPropertyName("strategy")]
        public string Strategy { get; set; }

        /// <summary>
        /// Gets or sets the number of day trades.
        /// </summary>
        /// <value>
        /// The number of day trades.
        /// </value>
        [JsonPropertyName("day_trades")]
        public int? DayTrades { get; set; }
    }
}
