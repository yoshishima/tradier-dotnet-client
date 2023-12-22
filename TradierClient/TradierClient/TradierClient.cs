using System;
using System.Net.Http;
using Tradier.Client.Helpers;

// ReSharper disable once CheckNamespace
namespace Tradier.Client
{
    /// <summary>
    ///     The <c>TradierClient</c> class.
    /// </summary>
    public class TradierClient
    {
        // TODO: Coming soon
        //public Streaming Streaming { get; set; }

        /// <summary>
        ///     The TradierClient constructor (with an existing HttpClient)
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
            //Streaming = new Streaming(request);
        }

        /// <summary>
        ///     The TradierClient constructor (with no HttpClient passed)
        /// </summary>
        public TradierClient(string apiToken, string defaultAccountNumber, bool useProduction = false)
            : this(new HttpClient(), apiToken, defaultAccountNumber, useProduction)
        {
        }

        /// <summary>
        ///     The TradierClient constructor (with no HttpClient and no defaultAccount passed)
        /// </summary>
        public TradierClient(string apiToken, bool useProduction = false)
            : this(new HttpClient(), apiToken, null, useProduction)
        {
        }

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

        public MarketData MarketData { get; set; }

        /// <summary>
        ///     Gets or sets the Trading property.
        /// </summary>
        /// <value>
        ///     The Trading property.
        /// </value>
        public Trading Trading { get; set; }

        public WatchlistEndpoint Watchlist { get; set; }
    }
}