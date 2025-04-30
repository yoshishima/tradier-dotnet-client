using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tradier.Client.Exceptions;

namespace Tradier.Client.Helpers
{
    /// <summary>
    ///     Class for making HTTP requests using HttpClient.
    /// </summary>
    public class Requests
    {
        /// <summary>
        ///     The <see cref="_httpClient" /> is a private readonly instance of <see cref="HttpClient" /> class.
        ///     It is used to send HTTP requests and receive HTTP responses from a specified URI.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Initializes a new instance of the Requests class with the specified HttpClient.
        /// </summary>
        /// <param name="httpClient">The HttpClient object to use for making HTTP requests.</param>
        public Requests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        ///     Send an asynchronous HTTP request to the specified URI using the specified HTTP method.
        /// </summary>
        /// <param name="uri">The URI of the request.</param>
        /// <param name="method">The HTTP method to use.</param>
        /// <returns>The response content as a string.</returns>
        private async Task<string> BaseSendAsyncRequest(string uri, HttpMethod method)
        {
            using var request = new HttpRequestMessage(method, uri);
            using var response = await _httpClient.SendAsync(request);
            {
                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    // Handle rate limiting
                    var retryAfter = response.Headers.RetryAfter?.Delta ?? TimeSpan.FromSeconds(60);
                    throw new TradierClientException(
                        $"Rate limit exceeded. Retry after {retryAfter.TotalSeconds} seconds.");
                }

                if (!response.IsSuccessStatusCode) throw new TradierClientException(response);

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }

        /// <summary>
        ///     Sends an HTTP GET request to the specified URI.
        /// </summary>
        /// <param name="uri">The URI to which the request is sent.</param>
        /// <returns>A task representing the asynchronous operation that returns the response content as a string.</returns>
        public async Task<string> GetRequest(string uri)
        {
            return await BaseSendAsyncRequest(uri, HttpMethod.Get);
        }

        /// <summary>
        ///     Send a GET request to the specified URI and returns the response as a string.
        /// </summary>
        /// <param name="uri">The URI of the resource to request.</param>
        /// <returns>The response from the GET request as a string.</returns>
        public async Task<string> GetRequest(Uri uri)
        {
            return await GetRequest(uri.ToString());
        }

        /// <summary>
        ///     Sends a DELETE request to the specified URI and returns the response as a string.
        /// </summary>
        /// <param name="uri">The URI to send the request to.</param>
        /// <returns>A Task containing the response string.</returns>
        public async Task<string> DeleteRequest(string uri)
        {
            return await BaseSendAsyncRequest(uri, HttpMethod.Delete);
        }

        /// <summary>
        ///     Send a PUT request to the specified URI with the given values.
        /// </summary>
        /// <param name="uri">The URI to send the request to.</param>
        /// <param name="values">The values to include in the request body.</param>
        /// <returns>
        ///     A task representing the asynchronous operation. The task result contains the
        ///     response content as a string.
        /// </returns>
        public async Task<string> PutRequest(string uri, Dictionary<string, string> values)
        {
            using var response = await _httpClient.PutAsync(uri, new FormUrlEncodedContent(values));
            {
                if (!response.IsSuccessStatusCode) throw new TradierClientException(response);

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }

        /// <summary>
        ///     Sends a POST request to the specified URI with the given values.
        /// </summary>
        /// <param name="uri">The URI to send the request to.</param>
        /// <param name="values">The dictionary containing the values to include in the request.</param>
        /// <returns>
        ///     A <see cref="Task{TResult}" /> representing the async operation that returns the response content as a string.
        /// </returns>
        /// <exception cref="TradierClientException">Thrown if the response is not a success status code.</exception>
        public async Task<string> PostRequest(string uri, Dictionary<string, string> values = null)
        {
            using var response =
                await _httpClient.PostAsync(uri, values == null ? null : new FormUrlEncodedContent(values));
            {
                if (!response.IsSuccessStatusCode) throw new TradierClientException(response);

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }
    }
}