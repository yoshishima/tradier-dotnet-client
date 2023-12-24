namespace Tradier.Client.Helpers
{
    /// <summary>
    ///     The Settings class provides constants for configuring endpoint URLs.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        ///     The production endpoint for accessing the Tradier API.
        /// </summary>
        /// <remarks>
        ///     This constant stores the URL of the production endpoint for accessing the Tradier API version 1.
        ///     The URL is "https://api.tradier.com/v1/".
        /// </remarks>
        public const string PRODUCTION_ENDPOINT = "https://api.tradier.com/v1/";

        /// <summary>
        ///     The URL endpoint for accessing the Tradier Sandbox API.
        /// </summary>
        public const string SANDBOX_ENDPOINT = "https://sandbox.tradier.com/v1/";

        /// <summary>
        ///     The endpoint for streaming data from Tradier API.
        /// </summary>
        /// <remarks>
        ///     This endpoint is used for establishing a WebSocket connection to receive real-time data from Tradier API.
        /// </remarks>
        public const string STREAMING_ENDPOINT = "wss://ws.tradier.com/v1/markets/events";
    }
}