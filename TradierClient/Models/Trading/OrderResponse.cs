using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Trading
{
    /// <summary>
    ///     Represents the root object of the order response.
    /// </summary>
    public class OrderResponseRootobject
    {
        /// <summary>
        ///     Represents an order response.
        /// </summary>
        [JsonPropertyName("order")]
        public OrderResponse OrderResponse { get; set; }
    }

    /// <summary>
    ///     Represents an order response.
    /// </summary>
    public class OrderResponse : IOrder
    {
        /// <summary>
        ///     Gets or sets the unique identifier for the property.
        /// </summary>
        /// <value>
        ///     An integer value representing the property identifier.
        /// </value>
        /// <remarks>
        ///     This property is decorated with the <see cref="JsonPropertyName" /> attribute,
        ///     which specifies that it is serialized as "id" when interacting with JSON data.
        /// </remarks>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the partner ID.
        /// </summary>
        /// <value>
        ///     The partner ID.
        /// </value>
        [JsonPropertyName("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}