using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Trading
{
    /// <summary>
    ///     Represents an order.
    /// </summary>
    public interface IOrder
    {
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