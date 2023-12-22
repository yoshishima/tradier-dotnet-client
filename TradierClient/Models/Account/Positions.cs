using System;
using System.Collections.Generic;
using Tradier.Client.Helpers;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Account
{
    /// <summary>
    /// Represents the root object for positions.
    /// </summary>
    public class PositionsRootobject
    {
        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        [JsonPropertyName("positions")]
        public Positions Positions { get; set; }
    }

    /// <summary>
    /// Represents a collection of positions.
    /// </summary>
    public class Positions
    {
        /// <summary>
        /// Gets or sets the position of an object.
        /// </summary>
        /// <value>
        /// A list of <see cref="Position"/> objects representing the position of the object.
        /// </value>
        [JsonPropertyName("position")]
        [JsonConverter(typeof(SingleOrArrayConverter<Position>))]
        public List<Position> Position { get; set; }
    }

    /// <summary>
    /// Represents a position in a portfolio.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Gets or sets the cost basis of an item.
        /// </summary>
        /// <value>
        /// The cost basis of the item.
        /// </value>
        [JsonPropertyName("cost_basis")]
        public float CostBasis { get; set; }

        /// <summary>
        /// Gets or sets the date when the item was acquired.
        /// </summary>
        [JsonPropertyName("date_acquired")]
        public DateTime DateAcquired { get; set; }

        /// <summary>
        /// Gets or sets the ID of the property.
        /// </summary>
        /// <value>
        /// The ID of the property.
        /// </value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity value.
        /// </summary>
        /// <value>
        /// The quantity value.
        /// </value>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}