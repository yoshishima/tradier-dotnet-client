using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Tradier.Client.Models.Exception;

namespace Tradier.Client.Exceptions
{
    /// <summary>
    ///     Represents an exception thrown by the TradierClient class.
    /// </summary>
    public class TradierClientException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the TradierClientException class.
        /// </summary>
        public TradierClientException()
        {
        }

        /// Initializes a new instance of the TradierClientException class with the specified error message.
        /// The error message that explains the reason for the exception.
        public TradierClientException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Represents an exception thrown by the TradierClient.
        /// </summary>
        /// <remarks>
        ///     This exception is thrown when an error occurs while making a request to the Tradier API.
        /// </remarks>
        public TradierClientException(HttpResponseMessage response)
        {
            var resp = response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(resp.Result))
            {
                if (Equals(response.Content.Headers.ContentType, MediaTypeHeaderValue.Parse("application/json")))
                {
                    var fault = JsonSerializer.Deserialize<FaultRootobject>(resp.Result).Fault;
                    throw new TradierClientException(fault, response);
                }

                throw new TradierClientException(resp.Result);
            }

            // if it's not any of the cases above,
            // just output the http status code exception embedded in EnsureSuccessStatusCode()
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        ///     Represents an exception that occurs while interacting with the Tradier API.
        /// </summary>
        /// <remarks>
        ///     This exception is thrown when the Tradier client encounters an error response from the API.
        /// </remarks>
        public TradierClientException(Fault fault, HttpResponseMessage response)
        {
            throw new Exception(responseBuilder(response, fault));
        }

        /// <summary>
        ///     Represents an exception specific to the TradierClient class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public TradierClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Builds a response message based on the provided <paramref name="response" /> and optional <paramref name="fault" />
        ///     .
        /// </summary>
        /// <param name="response">The HTTP response message.</param>
        /// <param name="fault">An optional fault object.</param>
        /// <returns>
        ///     A string representing the built response message. The message contains the following information:
        ///     - IsSuccessStatusCode: Indicates whether the response status code represents success.
        ///     - Reason: The reason phrase associated with the status code.
        ///     - StatusCode: The HTTP status code.
        ///     - Message: The fault string if <paramref name="fault" /> is not null, otherwise it's the string representation of
        ///     the response content.
        /// </returns>
        private string responseBuilder(HttpResponseMessage response, Fault fault = null)
        {
            var messageStream = response.Content.ReadAsStreamAsync().Result;
            var messageField = fault != null ? fault.FaultString : messageStream.ToString();
            var messageBuilt = $"IsSuccessStatusCode: {response.IsSuccessStatusCode}\n" +
                               $"Reason: {response.ReasonPhrase}\n" +
                               $"StatusCode: {response.StatusCode.ToString()}\n" +
                               $"Message: {messageField}";

            return messageBuilt;
        }
    }
}