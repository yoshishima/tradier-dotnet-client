using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Watchlist;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    ///     The <c>WatchlistEndpoint</c> class provides methods to interact with the watchlist API.
    /// </summary>
    public class WatchlistEndpoint
    {
        /// <summary>
        ///     Represents a class that handles requests.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        ///     Initializes a new instance of the WatchlistEndpoint class.
        /// </summary>
        /// <param name="requests">The Requests object for handling API requests.</param>
        public WatchlistEndpoint(Requests requests)
        {
            _requests = requests;
        }

        /// <summary>
        ///     Retrieve all of a user's watchlists.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation. The task result contains a Watchlists object.</returns>
        public async Task<Watchlists> GetWatchlists()
        {
            var response = await _requests.GetRequest("watchlists");
            return JsonSerializer.Deserialize<WatchlistsRootobject>(response).Watchlists;
        }

        /// <summary>
        ///     Retrieve a specific watchlist by id.
        /// </summary>
        /// <param name="watchlistId">The id of the watchlist to retrieve.</param>
        /// <returns>The watchlist object.</returns>
        public async Task<Watchlist> GetWatchlist(string watchlistId)
        {
            var response = await _requests.GetRequest($"watchlists/{watchlistId}");
            return JsonSerializer.Deserialize<WatchlistRootobject>(response).Watchlist;
        }

        /// <summary>
        ///     Create a new watchlist.
        /// </summary>
        /// <param name="name">The name of the watchlist.</param>
        /// <param name="symbols">A comma-separated string of symbols to be added to the watchlist.</param>
        /// <returns>
        ///     The newly created watchlist.
        /// </returns>
        public async Task<Watchlist> CreateWatchlist(string name, string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await CreateWatchlist(name, listSymbols);
        }

        /// <summary>
        ///     Create a new watchlist.
        /// </summary>
        /// <param name="name">The name of the watchlist.</param>
        /// <param name="symbols">The symbols to be added to the watchlist.</param>
        /// <returns>A Task with the created Watchlist object.</returns>
        public async Task<Watchlist> CreateWatchlist(string name, List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols);
            var data = new Dictionary<string, string>
            {
                { "name", name },
                { "symbols", strSymbols }
            };

            var response = await _requests.PostRequest("watchlists", data);
            return JsonSerializer.Deserialize<WatchlistRootobject>(response).Watchlist;
        }

        /// <summary>
        ///     Update an existing watchlist
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist to be updated</param>
        /// <param name="name">The new name for the watchlist</param>
        /// <param name="symbols">Optional. A comma-separated list of symbols to be added to the watchlist</param>
        /// <returns>
        ///     An updated Watchlist object.
        /// </returns>
        public async Task<Watchlist> UpdateWatchlist(string watchlistId, string name, string symbols = "")
        {
            var listSymbols = symbols?.Split(',').Select(x => x.Trim()).ToList();
            return await UpdateWatchlist(watchlistId, name, listSymbols);
        }

        /// <summary>
        ///     Update an existing watchlist.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist to be updated.</param>
        /// <param name="name">The new name for the watchlist.</param>
        /// <param name="symbols">Optional. The symbols to be added to the watchlist. If null, the symbol list will not be updated.</param>
        /// <returns>The updated watchlist.</returns>
        public async Task<Watchlist> UpdateWatchlist(string watchlistId, string name, List<string> symbols = null)
        {
            var strSymbols = string.Join(",", symbols);
            var data = new Dictionary<string, string>
            {
                { "name", name },
                { "symbols", strSymbols }
            };

            var response = await _requests.PutRequest($"watchlists/{watchlistId}", data);
            return JsonSerializer.Deserialize<WatchlistRootobject>(response).Watchlist;
        }

        /// <summary>
        ///     Deletes a specific watchlist.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist to delete.</param>
        /// <returns>The updated list of watchlists.</returns>
        public async Task<Watchlists> DeleteWatchlist(string watchlistId)
        {
            var response = await _requests.DeleteRequest($"watchlists/{watchlistId}");
            return JsonSerializer.Deserialize<WatchlistsRootobject>(response).Watchlists;
        }

        /// <summary>
        ///     Adds symbols to an existing watchlist.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist.</param>
        /// <param name="symbols">A comma-separated string of symbols to be added.</param>
        /// <returns>
        ///     An updated instance of the watchlist after symbols have been added.
        /// </returns>
        public async Task<Watchlist> AddSymbolsToWatchlist(string watchlistId, string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await AddSymbolsToWatchlist(watchlistId, listSymbols);
        }

        /// <summary>
        ///     Add symbols to an existing watchlist. If the symbol exists, it will be over-written.
        /// </summary>
        /// <param name="watchlistId">The ID of the target watchlist.</param>
        /// <param name="symbols">The list of symbols to be added.</param>
        /// <returns>The updated watchlist after adding the symbols.</returns>
        public async Task<Watchlist> AddSymbolsToWatchlist(string watchlistId, List<string> symbols)
        {
            var strSymbols = string.Join(",", symbols);
            var data = new Dictionary<string, string>
            {
                { "symbols", strSymbols }
            };

            var response = await _requests.PostRequest($"watchlists/{watchlistId}/symbols", data);
            return JsonSerializer.Deserialize<WatchlistRootobject>(response).Watchlist;
        }

        /// <summary>
        ///     Removes a symbol from a specific watchlist.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist from which the symbol should be removed.</param>
        /// <param name="symbol">The symbol to be removed from the watchlist.</param>
        /// <returns>
        ///     A <see cref="Task" /> representing the asynchronous operation.
        ///     The task result is a <see cref="Watchlist" /> object representing the updated watchlist after removing the symbol.
        /// </returns>
        public async Task<Watchlist> RemoveSymbolFromWatchlist(string watchlistId, string symbol)
        {
            var response = await _requests.DeleteRequest($"watchlists/{watchlistId}/symbols/{symbol}");
            return JsonSerializer.Deserialize<WatchlistRootobject>(response).Watchlist;
        }
    }
}