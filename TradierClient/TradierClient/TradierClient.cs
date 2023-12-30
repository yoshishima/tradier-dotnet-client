using System;
using System.Net.Http;
using Tradier.Client.Helpers;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    ///     The TradierClient class is used to interact with the Tradier API. It provides methods to perform authentication,
    ///     retrieve account information, access market data, and perform trading
    ///     operations.
    /// </summary>
    public class TradierClient
    {
        /// <summary>
        ///     The TradierClient class represents a client for interacting with the Tradier API.
        /// </summary>
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
            Streaming = new Streaming(request);
            Fundamentals = new Fundamentals(request);
        }

        /// <summary>
        ///     Initializes a new instance of the TradierClient class with the specified API token, default account number, and
        ///     production flag.
        /// </summary>
        /// <param name="apiToken">The API token to be used for authentication.</param>
        /// <param name="defaultAccountNumber">The default account number to be used.</param>
        /// <param name="useProduction">A flag indicating whether to use the production environment.</param>
        public TradierClient(string apiToken, string defaultAccountNumber, bool useProduction = false)
            : this(new HttpClient(), apiToken, defaultAccountNumber, useProduction)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the TradierClient class.
        /// </summary>
        /// <param name="apiToken">The API token used to authenticate with Tradier API.</param>
        /// <param name="useProduction">Specifies whether to use production or sandbox environment. Default is false (sandbox).</param>
        public TradierClient(string apiToken, bool useProduction = false)
            : this(new HttpClient(), apiToken, null, useProduction)
        {
        }

        /// <summary>
        ///     Gets or sets the streaming property.
        /// </summary>
        /// <value>
        ///     The streaming property.
        /// </value>
        /// <remarks>
        ///     The streaming property allows the user to manage the streaming settings.
        /// </remarks>
        public Streaming Streaming { get; set; }

        /// <summary>
        ///     Represents the fundamental details of a property.
        /// </summary>
        public Fundamentals Fundamentals { get; set; }

        /// <summary>
        ///     Gets or sets the authentication information for the property.
        /// </summary>
        /// <value>
        ///     The authentication information.
        /// </value>
        public Authentication Authentication { get; set; }

        /// <summary>
        ///     Gets or sets the Account property.
        /// </summary>
        /// <remarks>
        ///     Represents the account associated with an entity.
        /// </remarks>
        public Account Account { get; set; }

        /// <summary>
        ///     Gets or sets the market data.
        /// </summary>
        /// <value>
        ///     The market data.
        /// </value>
        /// /
        public MarketData MarketData { get; set; }


        /// <summary>
        ///     Gets or sets the Trading property.
        /// </summary>
        /// <value>The Trading property.</value>
        public Trading Trading { get; set; }

        /// <summary>
        ///     Property representing the Watchlist endpoint.
        /// </summary>
        /// <value>
        ///     An instance of the WatchlistEndpoint class.
        /// </value>
        public WatchlistEndpoint Watchlist { get; set; }
    }
}