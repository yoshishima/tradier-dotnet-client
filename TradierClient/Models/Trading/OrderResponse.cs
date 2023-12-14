using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Trading
{
    public class OrderResponseRootobject
    {
        [JsonPropertyName("order")]
        public OrderReponse OrderReponse { get; set; }
    }

    public class OrderReponse : IOrder
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("partner_id")]
        public string PartnerId { get; set; }
    }
}
