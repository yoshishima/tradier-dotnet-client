using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Authentication;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    /// Represents an authentication class that enables handling user authentication,
    /// including obtaining and refreshing access tokens for API usage.
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Represents a private field of type `Requests` used for making HTTP requests within the `Authentication` class.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        /// Represents a class that provides authentication-related operations such as obtaining and refreshing access tokens.
        /// </summary>
        public Authentication(Requests requests)
        {
            _requests = requests;
        }

        /// <summary>
        /// Obtains an access token by exchanging an authorization code.
        /// </summary>
        /// <param name="code">The authorization code to exchange for an access token.</param>
        /// <returns>
        /// A Task that represents the asynchronous operation. The result contains a <see cref="Token" /> object with the access token details.
        /// </returns>
        public async Task<Token> CreateAccessToken(string code)
        {
            var data = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code }
            };

            var response = await _requests.PostRequest("oauth/accesstoken", data);
            return JsonSerializer.Deserialize<Token>(response);
        }

        /// <summary>
        /// Refreshes the access token using the provided refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token to use for obtaining a new access token.</param>
        /// <returns>A <see cref="Token" /> object containing the new access token and related information.</returns>
        public async Task<Token> RefreshAccessToken(string refreshToken)
        {
            var data = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken }
            };

            var response = await _requests.PostRequest("oauth/accesstoken", data);
            return JsonSerializer.Deserialize<Token>(response);
        }
    }
}