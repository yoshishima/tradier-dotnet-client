using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Streaming
{
    /// <summary>
    ///     Represents a root object for streaming.
    /// </summary>
    public class StreamRootobject
    {
        /// <summary>
        ///     Gets or sets the stream property.
        /// </summary>
        /// <value>
        ///     The stream property.
        /// </value>
        [JsonPropertyName("stream")]
        public Stream Stream { get; set; }
    }

    /// <summary>
    ///     Represents a stream object that contains the URL and session ID.
    /// </summary>
    public class Stream
    {
        /// <summary>
        ///     Gets or sets the URL.
        /// </summary>
        /// <value>
        ///     The URL.
        /// </value>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        ///     Gets or sets the SessionId property.
        /// </summary>
        /// <value>
        ///     The SessionId property specifies the unique identifier for a session.
        /// </value>
        /// <remarks>
        ///     This property represents the session ID that is used to identify a specific session in the application.
        /// </remarks>
        [JsonPropertyName("sessionid")]
        public string SessionId { get; set; }
    }
}