using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Trading
{
    public interface IOrder
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

}
