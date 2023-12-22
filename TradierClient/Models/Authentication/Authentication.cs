using System;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Authentication
{
    /// <summary>
    ///     Represents a token obtained from an authentication server.
    /// </summary>
    public class Token
    {
        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the refresh token.
        /// </summary>
        /// <value>
        ///     The refresh token.
        /// </value>
        [JsonPropertyName("refresh_token")]
        public int RefreshToken { get; set; }

        /// <summary>
        ///     Gets or sets the expiration time in UTC format.
        /// </summary>
        /// <value>
        ///     The expiration time in UTC format.
        /// </value>
        [JsonPropertyName("expires_in")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime ExpiresIn { get; set; }

        /// <summary>
        ///     Gets or sets the date and time at which the property was issued.
        /// </summary>
        /// <value>
        ///     The date and time at which the property was issued.
        /// </value>
        [JsonPropertyName("issued_at")]
        public DateTime IssuedAt { get; set; }

        /// <summary>
        ///     The scope property represents the scope of an item.
        /// </summary>
        /// <remarks>
        ///     The scope provides information about the context or area to which an item belongs.
        /// </remarks>
        /// <value>
        ///     A string value representing the scope of the item.
        /// </value>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

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