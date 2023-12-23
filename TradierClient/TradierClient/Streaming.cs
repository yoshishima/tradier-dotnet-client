using System.Text.Json;
using System.Threading.Tasks;
using System;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Streaming;

// ReSharper disable once CheckNamespace
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


        public async Task<String> CreateMarketSession()
        {
            var response =
                await _requests.GetRequest(
                    $"v1/markets/events/session");
            return JsonSerializer.Deserialize<Stream>(response).SessionId;
        }

        // TODO: Coming soon
        //public async Task<StreamResponse> GetStreamingQuotes(string sessionid, string symbols, string filter, bool lineBreak, bool validOnly, bool advancedDetails)
        //{
        //    var response = await _requests.GetRequest($"markets/events?sessionid={sessionid}&symbols={symbols}&linebreak={lineBreak}&validOnly={validOnly}&advancedDetails={advancedDetails}");
        //    return JsonConvert.DeserializeObject<StreamResponse>(response);
        //}
    }
}