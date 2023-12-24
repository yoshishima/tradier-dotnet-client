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
    ///     The <c>Streaming</c> class
    /// </summary>
    public class Streaming
    {
        private readonly Requests _requests;

        /// <summary>
        ///     Initializes a new instance of the Streaming class.
        /// </summary>
        /// <param name="requests">The requests object to use for streaming.</param>
        public Streaming(Requests requests)
        {
            _requests = requests;
        }


        public async Task<Stream> GetStreamingToken()
        {
            var response =
                await _requests.PostRequest(
                    "/v1/markets/events/session");
            return JsonSerializer.Deserialize<StreamRootobject>(response).Stream;
        }

        public async Task EstablishWebSocket(string url, string sessionid, string symbolList)
        {
            using (var webSocket = new ClientWebSocket())
            {
                // Add your headers (e.g., Authorization header)
                webSocket.Options.SetRequestHeader("Authorization", $"Bearer {sessionid}");

                Console.WriteLine(url);
                Console.WriteLine(sessionid);

                // Connect
                await webSocket.ConnectAsync(new Uri(url), CancellationToken.None);
                Console.WriteLine("Connected!");

                // Send parameters if required (as per server requirement)
                //string parameters = "{\"symbols\": [\"SPY231220C00462000\",\"SPY\",\"MSFT\"], \"sessionid\": \"" + token + "\", \"linebreak\": false, \"advancedDetails\": false}";
                var parameters = symbolList;
                await Send(webSocket, parameters);

                // Example to receive messages
                await Receive(webSocket);
            }
        }

        private static async Task Send(ClientWebSocket webSocket, string parameters)
        {
            var bytes = Encoding.UTF8.GetBytes(parameters);
            await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true,
                CancellationToken.None);
            Console.WriteLine("Sent data: " + parameters);
        }

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


        public class JsonBuilder
        {
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
        // TODO: Coming soon
        //public async Task<StreamResponse> GetStreamingQuotes(string sessionid, string symbols, string filter, bool lineBreak, bool validOnly, bool advancedDetails)
        //{
        //    var response = await _requests.GetRequest($"markets/events?sessionid={sessionid}&symbols={symbols}&linebreak={lineBreak}&validOnly={validOnly}&advancedDetails={advancedDetails}");
        //    return JsonConvert.DeserializeObject<StreamResponse>(response);
        //}
    }
}