using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Streaming
{

    public class StreamRootobject
    {
        [JsonPropertyName("stream")]
        public Stream Stream { get; set; }
    }

    public class Stream
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("sessionid")]
        public string SessionId { get; set; }
    }

}
