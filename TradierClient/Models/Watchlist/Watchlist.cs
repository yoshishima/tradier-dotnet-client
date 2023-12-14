using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Watchlist
{

    public class WatchlistsRootobject
    {
        [JsonPropertyName("watchlists")]
        public Watchlists Watchlists { get; set; }
    }

    public class WatchlistRootobject
    {
        [JsonPropertyName("watchlist")]
        public Watchlist Watchlist { get; set; }
    }

    public class Watchlists
    {
        [JsonPropertyName("watchlist")]
        [JsonConverter(typeof(SingleOrArrayConverter<Watchlist>))]
        public List<Watchlist> Watchlist { get; set; }
    }

    public class Watchlist
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("public_id")]
        public string PublicId { get; set; }

        [JsonPropertyName("items")]
        public Items Items { get; set; }
    }

    public class Items
    {
        [JsonPropertyName("item")]
        [JsonConverter(typeof(SingleOrArrayConverter<Item>))]
        public List<Item> Item { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}