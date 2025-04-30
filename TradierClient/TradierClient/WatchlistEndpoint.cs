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
    /// The <c>WatchlistEndpoint</c> class provides methods to interact with the watchlist API.
    /// </summary>
    public class WatchlistEndpoint
    {
        /// <summary>
        /// Holds an instance of the <c>Requests</c> class used for making HTTP requests.
        /// </summary>
        private readonly Requests _requests;

        /// <summary>
        /// The <c>WatchlistEndpoint</c> class provides methods to interact with watchlist-related API endpoints.
        /// </summary>
        public WatchlistEndpoint(Requests requests)
        {
            _requests = requests;
        }

        /// <summary>
        /// Retrieve all of a user's watchlists.
        /// </summary>
        /// <returns>
        /// A Task that represents the asynchronous operation.
        /// The task result contains a Watchlists object.
        /// </returns>
        public async Task<Watchlists> GetWatchlists()
        {
            var response = await _requests.GetRequest("watchlists");
            return JsonSerializer.Deserialize<WatchlistsRootobject>(response).Watchlists;
        }

        /// <summary>
        /// Retrieves a specific watchlist by its unique identifier.
        /// </summary>
        /// <param name="watchlistId">The unique identifier of the watchlist to retrieve.</param>
        /// <returns>The <c>Watchlist</c> object corresponding to the specified identifier.</returns>
        public async Task<Watchlist> GetWatchlist(string watchlistId)
        {
            var response = await _requests.GetRequest($"watchlists/{watchlistId}");
            return JsonSerializer.Deserialize<WatchlistRootobject>(response).Watchlist;
        }

        /// <summary>
        /// Creates a new watchlist with the specified name and symbols.
        /// </summary>
        /// <param name="name">The name of the watchlist.</param>
        /// <param name="symbols">A comma-separated string of symbols to be included in the watchlist.</param>
        /// <returns>
        /// A Task representing the asynchronous operation, with a Watchlist object for the newly created watchlist as a result.
        /// </returns>
        public async Task<Watchlist> CreateWatchlist(string name, string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await CreateWatchlist(name, listSymbols);
        }

        /// <summary>
        /// Creates a new watchlist with the specified name and symbols.
        /// </summary>
        /// <param name="name">The name of the watchlist to be created.</param>
        /// <param name="symbols">The list of symbols to be included in the watchlist.</param>
        /// <returns>A Task representing the asynchronous operation, containing the created Watchlist object.</returns>
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
        /// Updates an existing watchlist by its ID, modifying the name and optionally updating its symbols.
        /// </summary>
        /// <param name="watchlistId">The unique identifier of the watchlist to be updated.</param>
        /// <param name="name">The new name for the watchlist.</param>
        /// <param name="symbols">Optional. A comma-separated string of symbols to be added to the watchlist.</param>
        /// <returns>An updated Watchlist object.</returns>
        public async Task<Watchlist> UpdateWatchlist(string watchlistId, string name, string symbols = "")
        {
            var listSymbols = symbols?.Split(',').Select(x => x.Trim()).ToList();
            return await UpdateWatchlist(watchlistId, name, listSymbols);
        }

        /// <summary>
        /// Updates an existing watchlist with a new name and an optional list of symbols.
        /// </summary>
        /// <param name="watchlistId">The unique identifier of the watchlist to update.</param>
        /// <param name="name">The new name to assign to the watchlist.</param>
        /// <param name="symbols">Optional. A list of symbols to include in the watchlist. If null or empty, the symbols will remain unchanged.</param>
        /// <returns>The updated <see cref="Watchlist"/> object.</returns>
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
        /// Deletes a specific watchlist.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated list of watchlists.</returns>
        public async Task<Watchlists> DeleteWatchlist(string watchlistId)
        {
            var response = await _requests.DeleteRequest($"watchlists/{watchlistId}");
            return JsonSerializer.Deserialize<WatchlistsRootobject>(response).Watchlists;
        }

        /// <summary>
        /// Adds symbols to an existing watchlist.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist where the symbols will be added.</param>
        /// <param name="symbols">A comma-separated string of symbols to add to the watchlist.</param>
        /// <returns>
        /// An updated <c>Watchlist</c> instance reflecting the added symbols.
        /// </returns>
        public async Task<Watchlist> AddSymbolsToWatchlist(string watchlistId, string symbols)
        {
            var listSymbols = symbols.Split(',').Select(x => x.Trim()).ToList();
            return await AddSymbolsToWatchlist(watchlistId, listSymbols);
        }

        /// <summary>
        /// Adds symbols to an existing watchlist and returns the updated watchlist object.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist to which symbols will be added.</param>
        /// <param name="symbols">A list of symbols to add to the watchlist.</param>
        /// <returns>The updated watchlist containing the newly added symbols.</returns>
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
        /// Removes a symbol from a specific watchlist.
        /// </summary>
        /// <param name="watchlistId">The ID of the watchlist from which the symbol should be removed.</param>
        /// <param name="symbol">The symbol to be removed from the watchlist.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation.
        /// The task result is a <see cref="Watchlist" /> object representing the updated watchlist after removing the symbol.
        /// </returns>
        public async Task<Watchlist> RemoveSymbolFromWatchlist(string watchlistId, string symbol)
        {
            var response = await _requests.DeleteRequest($"watchlists/{watchlistId}/symbols/{symbol}");
            return JsonSerializer.Deserialize<WatchlistRootobject>(response).Watchlist;
        }
    }
}