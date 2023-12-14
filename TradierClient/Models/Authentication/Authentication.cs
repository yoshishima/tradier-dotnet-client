using System;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Authentication
{

    public class Token
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public int RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime ExpiresIn { get; set; }

        [JsonPropertyName("issued_at")]
        public DateTime IssuedAt { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}