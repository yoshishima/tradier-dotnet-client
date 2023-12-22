using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Authentication;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    /// Represents an authentication class that allows obtaining and refreshing access tokens.
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Represents a private variable of type `Requests` used within the current class.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentication"/> class.
        /// </summary>
        /// <param name="requests">The <see cref="Requests"/> object used for making API requests.</param>
        public Authentication(Requests requests)
        {
            _requests = requests;
        }

        /// <summary>
        /// You can obtain an access token by exchanging an authorization code.
        /// </summary>
        /// <param name="code">The authorization code to exchange for an access token.</param>
        /// <returns>A Task object that represents the asynchronous operation. The result of the Task is a Token object containing the access token.</returns>
        public async Task<Token> CreateAccessToken(string code)
        {
            var data = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
            };

            var response = await _requests.PostRequest("oauth/accesstoken", data);
            return JsonSerializer.Deserialize<Token>(response);
        }

        /// <summary>
        /// Refreshes the access token using the provided refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token to use for obtaining a new access token.</param>
        /// <returns>The new access token.</returns>
        public async Task<Token> RefreshAccessToken(string refreshToken)
        {
            var data = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken },
            };

            var response = await _requests.PostRequest("oauth/accesstoken", data);
            return JsonSerializer.Deserialize<Token>(response);
        }
    }
}
