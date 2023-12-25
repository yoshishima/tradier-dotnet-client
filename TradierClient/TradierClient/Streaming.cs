using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Streaming;

namespace Tradier.Client
{
    /// <summary>
    ///     The <c>Streaming</c> class provides methods for streaming data from a server using WebSocket.
    /// </summary>
    public class Streaming
    {
        /// <summary>
        ///     Private member variable for handling requests.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        ///     Initializes a new instance of the Streaming class.
        /// </summary>
        /// <param name="requests">The requests object to use for streaming.</param>
        public Streaming(Requests requests)
        {
            _requests = requests;
        }


        /// <summary>
        ///     Calls the /v1/markets/events/session endpoint to retrieve a streaming token.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result represents the streaming token as a Stream.</returns>
        public async Task<Stream> GetStreamingToken()
        {
            var response =
                await _requests.PostRequest(
                    "/v1/markets/events/session");
            return JsonSerializer.Deserialize<StreamRootobject>(response).Stream;
        }

        /// <summary>
        ///     Establishes a WebSocket connection to the specified URL using the provided session ID and symbol list.
        /// </summary>
        /// <param name="url">The URL to connect to.</param>
        /// <param name="sessionid">The session ID used for authorization.</param>
        /// <param name="symbolList">The list of symbols to be sent as parameters.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public async Task EstablishWebSocket(string url, string sessionid, string symbolList)
        {
            using (var webSocket = new ClientWebSocket())
            {
                // Add your headers (e.g., Authorization header)
                webSocket.Options.SetRequestHeader("Authorization", $"Bearer {sessionid}");

                Console.WriteLine(url);
                Console.WriteLine(sessionid);

                await webSocket.ConnectAsync(new Uri(url), CancellationToken.None);

                var parameters = symbolList;
                await Send(webSocket, parameters);

                await Receive(webSocket);
            }
        }

        /// <summary>
        ///     Sends the provided parameters to the specified ClientWebSocket instance.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket instance to send the data to.</param>
        /// <param name="parameters">The parameters to be sent.</param>
        /// <returns>A Task representing the asynchronous Send operation.</returns>
        private static async Task Send(ClientWebSocket webSocket, string parameters)
        {
            var bytes = Encoding.UTF8.GetBytes(parameters);
            await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true,
                CancellationToken.None);
            Console.WriteLine("Sent data: " + parameters);
        }

        /// <summary>
        ///     Receives messages from the WebSocket and handles the close message.
        /// </summary>
        /// <param name="webSocket">The WebSocket object to receive messages from.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        private static async Task Receive(ClientWebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine(message);

                // Handle close message
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty,
                        CancellationToken.None);
                    Console.WriteLine("WebSocket connection closed.");
                }
            }
        }


        /// <summary>
        ///     The JsonBuilder class provides a static method for building a JSON string from provided parameters.
        /// </summary>
        public class JsonBuilder
        {
            /// <summary>
            ///     Builds a JSON string by serializing the given input parameters.
            /// </summary>
            /// <param name="symbols">An array of strings representing symbols.</param>
            /// <param name="sessionID">A string representing the session ID.</param>
            /// <param name="filters">An array of strings representing filters.</param>
            /// <param name="linebreak">A boolean value indicating whether linebreaks should be included in the JSON string.</param>
            /// <param name="validOnly">A boolean value indicating whether only valid elements should be included in the JSON string.</param>
            /// <param name="advancedDetails">
            ///     A boolean value indicating whether advanced details should be included in the JSON
            ///     string.
            /// </param>
            /// <returns>A string representing the JSON serialized object.</returns>
            public static string BuildJsonString(string[] symbols, string sessionID, string[] filters, bool linebreak,
                bool validOnly, bool advancedDetails)
            {
                var jsonObject = new
                {
                    symbols,
                    sessionid = sessionID,
                    filter = filters,
                    linebreak,
                    validOnly,
                    advancedDetails
                };

                return JsonSerializer.Serialize(jsonObject);
            }
        }
    }
}