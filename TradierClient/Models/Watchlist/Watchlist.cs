using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Watchlist
{
    /// <summary>
    ///     Represents the root object for watchlists data.
    /// </summary>
    public class WatchlistsRootobject
    {
        /// <summary>
        ///     Represents a collection of watchlists.
        /// </summary>
        [JsonPropertyName("watchlists")]
        public Watchlists Watchlists { get; set; }
    }

    /// Represents a watchlist root object.
    /// </summary>
    public class WatchlistRootobject
    {
        /// <summary>
        ///     Gets or sets the watchlist property.
        /// </summary>
        /// <value>
        ///     The watchlist.
        /// </value>
        [JsonPropertyName("watchlist")]
        public Watchlist Watchlist { get; set; }
    }

    /// <summary>
    ///     Represents a collection of watchlists.
    /// </summary>
    public class Watchlists
    {
        /// <summary>
        ///     Represents a list of watchlist items.
        /// </summary>
        [JsonPropertyName("watchlist")]
        [JsonConverter(typeof(SingleOrArrayConverter<Watchlist>))]
        public List<Watchlist> Watchlist { get; set; }
    }

    /// <summary>
    ///     Represents a watchlist.
    /// </summary>
    public class Watchlist
    {
        /// <summary>
        ///     Gets or sets the name property.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the property Id.
        /// </summary>
        /// <value>
        ///     The value of the property Id.
        /// </value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the public identifier.
        /// </summary>
        /// <value>
        ///     The public identifier.
        /// </value>
        [JsonPropertyName("public_id")]
        public string PublicId { get; set; }

        /// <summary>
        ///     Represents the Items property.
        /// </summary>
        [JsonPropertyName("items")]
        public Items Items { get; set; }
    }

    /// <summary>
    ///     Represents a collection of items.
    /// </summary>
    public class Items
    {
        /// <summary>
        ///     Represents a property named "Item" that is a list of <see cref="Item" />.
        /// </summary>
        [JsonPropertyName("item")]
        [JsonConverter(typeof(SingleOrArrayConverter<Item>))]
        public List<Item> Item { get; set; }
    }

    /// <summary>
    ///     Represents an item with symbol and ID.
    /// </summary>
    public class Item
    {
        /// <summary>
        ///     Gets or sets the symbol.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the Id property for the given object.
        /// </summary>
        /// <value>
        ///     The Id property.
        /// </value>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}