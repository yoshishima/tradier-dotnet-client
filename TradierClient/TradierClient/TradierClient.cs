using System;
using System.Net.Http;
using Tradier.Client.Helpers;
using Tradier.Client.Models.Streaming;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    ///     The <c>TradierClient</c> class provides access to Tradier API, enabling interaction with various
    ///     endpoints such as account management, market data, trading, watchlists, and more.
    /// </summary>
    public class TradierClient
    {
        /// <summary>
        ///     Represents the main client for interacting with the Tradier API.
        /// </summary>
        /// <remarks>
        ///     This class initializes various endpoints such as Authentication, Account, MarketData, Trading,
        ///     and Watchlist, using the provided HTTP client configuration settings.
        /// </remarks>
        public TradierClient(HttpClient httpClient, string apiToken, string defaultAccountNumber = null,
            bool useProduction = false)
        {
            var baseEndpoint =
                useProduction ? new Uri(Settings.PRODUCTION_ENDPOINT) : new Uri(Settings.SANDBOX_ENDPOINT);

            httpClient.BaseAddress = baseEndpoint;
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = new Requests(httpClient);

            Authentication = new Authentication(request);
            Account = new Account(request, defaultAccountNumber);
            MarketData = new MarketData(request);
            Trading = new Trading(request, defaultAccountNumber);
            Watchlist = new WatchlistEndpoint(request);

            // TODO: Coming soon
            //Streaming = new Streaming(request);
            Fundamentals = new Fundamentals(request);
        }

        /// <summary>
        ///     Represents the client for interacting with the Tradier API.
        /// </summary>
        public TradierClient(string apiToken, string defaultAccountNumber, bool useProduction = false)
            : this(new HttpClient(), apiToken, defaultAccountNumber, useProduction)
        {
        }

        /// <summary>
        ///     The <c>TradierClient</c> class provides an interface to interact with the Tradier API.
        /// </summary>
        /// <remarks>
        ///     It includes support for account management, market data access, trading, watchlists, and more.
        ///     The class operates using either an existing <c>HttpClient</c> or creates a new one if none is provided.
        /// </remarks>
        public TradierClient(string apiToken, bool useProduction = false)
            : this(new HttpClient(), apiToken, null, useProduction)
        {
        }

        // TODO: Coming soon
        /// <summary>
        ///     Gets or sets the streaming client for handling real-time data streams.
        /// </summary>
        /// <value>
        ///     The streaming client instance.
        /// </value>
        public Streaming Streaming { get; set; }

        /// <summary>
        ///     Gets or sets the fundamentals functionality for retrieving company and dividend data from the Tradier API.
        /// </summary>
        /// <value>
        ///     The fundamentals functionality.
        /// </value>
        public Fundamentals Fundamentals { get; set; }

        /// <summary>
        ///     Gets or sets the authentication functionality for managing access tokens.
        /// </summary>
        /// <value>
        ///     The authentication capability for the client.
        /// </value>
        public Authentication Authentication { get; set; }

        /// <summary>
        ///     Gets or sets the account information associated with the client.
        /// </summary>
        /// <value>
        ///     The account representation, providing access to account-related operations such as
        ///     retrieving profiles, balances, positions, orders, and history.
        /// </value>
        public Account Account { get; set; }

        /// <summary>
        ///     Gets or sets the market data interface for interacting with market-related data endpoints.
        /// </summary>
        /// <value>
        ///     The market data interface used for operations such as retrieving option chains, quotes, historical data,
        ///     and more.
        /// </value>
        public MarketData MarketData { get; set; }


        /// <summary>
        ///     Gets or sets the trading operations for the property.
        /// </summary>
        /// <value>
        ///     The trading operations, providing methods for placing various types of orders and interacting with the trading
        ///     system.
        /// </value>
        public Trading Trading { get; set; }

        /// <summary>
        ///     Gets or sets the watchlist API endpoint to manage and interact with user-defined watchlists.
        /// </summary>
        /// <value>
        ///     An instance of <see cref="WatchlistEndpoint" /> used to perform operations such as retrieving, creating,
        ///     updating, and deleting watchlists, as well as managing watchlist symbols.
        /// </value>
        public WatchlistEndpoint Watchlist { get; set; }
    }
}