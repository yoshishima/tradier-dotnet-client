using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Account
{
    /// <summary>
    ///     Represents the root object for orders data.
    /// </summary>
    public class OrdersRootobject
    {
        /// <summary>
        ///     Represents the Orders property.
        /// </summary>
        [JsonPropertyName("orders")]
        public Orders Orders { get; set; }
    }

    /// <summary>
    ///     Represents a collection of orders.
    /// </summary>
    public class Orders
    {
        /// <summary>
        ///     Represents a list of orders.
        /// </summary>
        [JsonPropertyName("order")]
        [JsonConverter(typeof(SingleOrArrayConverter<Order>))]
        public List<Order> Order { get; set; }
    }

    /// <summary>
    ///     Represents an order.
    /// </summary>
    public class Order
    {
        /// <summary>
        ///     Gets or sets the Id of the property.
        /// </summary>
        /// <value>
        ///     The Id.
        /// </value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the symbol of this property.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the value of the Side property.
        /// </summary>
        /// <remarks>
        ///     This property represents the side of an object.
        /// </remarks>
        [JsonPropertyName("side")]
        public string Side { get; set; }

        /// <summary>
        ///     Represents the quantity of a certain item.
        /// </summary>
        /// <value>
        ///     The quantity represented as a floating point number.
        /// </value>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        /// <summary>
        ///     Represents the status of an entity.
        /// </summary>
        /// <remarks>
        ///     The status property provides information about the current state of an entity.
        ///     It is represented as a string value.
        /// </remarks>
        /// <value>
        ///     The current status of the entity.
        /// </value>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("duration")] public string Duration { get; set; }

        /// <summary>
        ///     Gets or sets the price of an item.
        /// </summary>
        /// <value>
        ///     The price of the item.
        /// </value>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        /// <summary>
        ///     Gets or sets the average fill price of a trade.
        /// </summary>
        /// <value>
        ///     The average fill price.
        /// </value>
        [JsonPropertyName("avg_fill_price")]
        public float AvgFillPrice { get; set; }

        /// <summary>
        ///     The execution quantity for a particular property.
        /// </summary>
        /// <remarks>
        ///     This property represents the number of executions for a specific item.
        /// </remarks>
        /// <value>
        ///     A float representing the execution quantity.
        /// </value>
        /// /
        [JsonPropertyName("exec_quantity")]
        public float ExecQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the last fill price.
        /// </summary>
        /// <value>
        ///     The last fill price.
        /// </value>
        [JsonPropertyName("last_fill_price")]
        public float LastFillPrice { get; set; }

        /// <summary>
        ///     Gets or sets the last fill quantity.
        /// </summary>
        /// <value>
        ///     The last fill quantity.
        /// </value>
        [JsonPropertyName("last_fill_quantity")]
        public float LastFillQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the remaining quantity.
        /// </summary>
        /// <value>
        ///     The remaining quantity.
        /// </value>
        [JsonPropertyName("remaining_quantity")]
        public float RemainingQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the create date of the object.
        /// </summary>
        /// <value>
        ///     The create date represented as a <see cref="System.DateTime" /> object.
        /// </value>
        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     Gets or sets the transaction date.
        /// </summary>
        /// <value>
        ///     The transaction date.
        /// </value>
        /// <remarks>
        ///     This property represents the date of the transaction.
        /// </remarks>
        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        ///     Represents a property with the name "_class".
        /// </summary>
        [JsonPropertyName("_class")]
        public string Class { get; set; }

        /// <summary>
        ///     Gets or sets the option symbol.
        /// </summary>
        /// <value>
        ///     The option symbol.
        /// </value>
        [JsonPropertyName("option_symbol")]
        public string OptionSymbol { get; set; }

        /// <summary>
        ///     Gets or sets the number of legs.
        /// </summary>
        /// <value>
        ///     The number of legs.
        /// </value>
        [JsonPropertyName("num_legs")]
        public int NumLegs { get; set; }

        /// <summary>
        ///     Represents the strategy used for a particular operation.
        /// </summary>
        [JsonPropertyName("strategy")]
        public string Strategy { get; set; }

        /// <summary>
        ///     Gets or sets the stop property.
        /// </summary>
        /// <value>
        ///     The value of the stop property.
        /// </value>
        [JsonPropertyName("stop")]
        public string Stop { get; set; }

        /// <summary>
        ///     The tag property represents a string value in a JSON object or response.
        /// </summary>
        /// <remarks>
        ///     This property is tagged with the "tag" attribute in the JSON representation.
        /// </remarks>
        /// <value>
        ///     The value of the tag property.
        /// </value>
        /// <exception cref="System.ArgumentException">
        ///     Thrown when the provided tag value is invalid.
        /// </exception>
        [JsonPropertyName("tag")]
        //Need to check 255 max with only ltetters, numbers and - supported
        public string Tag { get; set; }

        /// <summary>
        ///     Represents a leg in a journey.
        /// </summary>
        [JsonPropertyName("leg")]
        public Leg[] Leg { get; set; }
    }

    /// <summary>
    ///     Represents a leg of a trade.
    /// </summary>
    public class Leg
    {
        /// <summary>
        ///     The unique identifier for the property.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the Type property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the symbol.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the side of an object.
        /// </summary>
        /// <value>
        ///     The side.
        /// </value>
        [JsonPropertyName("side")]
        public string Side { get; set; }

        /// <summary>
        ///     Represents the quantity of an item.
        /// </summary>
        /// <remarks>
        ///     The Quantity property is used to store the numeric value of the quantity of an item. It is a floating-point number
        ///     (single precision) representing a decimal value.
        /// </remarks>
        /// <value>
        ///     The numeric value of the quantity.
        /// </value>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the duration of the property.
        /// </summary>
        /// <value>
        ///     The duration.
        /// </value>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        ///     Gets or sets the price of the property.
        /// </summary>
        /// <value>
        ///     The price of the property.
        /// </value>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        /// <summary>
        ///     Gets or sets the average fill price.
        /// </summary>
        /// <value>
        ///     The average fill price.
        /// </value>
        [JsonPropertyName("avg_fill_price")]
        public float AvgFillPrice { get; set; }

        /// <summary>
        ///     Gets or sets the quantity of the execution.
        /// </summary>
        /// <value>
        ///     The quantity of the execution.
        /// </value>
        [JsonPropertyName("exec_quantity")]
        public float ExecQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the last fill price of an object.
        /// </summary>
        /// <value>
        ///     The last fill price.
        /// </value>
        [JsonPropertyName("last_fill_price")]
        public float LastFillPrice { get; set; }

        /// <summary>
        ///     Gets or sets the last fill quantity of an entity.
        /// </summary>
        /// <value>
        ///     The last fill quantity.
        /// </value>
        [JsonPropertyName("last_fill_quantity")]
        public float LastFillQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the remaining quantity.
        /// </summary>
        /// <value>The remaining quantity.</value>
        [JsonPropertyName("remaining_quantity")]
        public float RemainingQuantity { get; set; }

        /// <summary>
        ///     Gets or sets the create date.
        /// </summary>
        /// <value>
        ///     The create date.
        /// </value>
        /// <remarks>
        ///     The create date represents the date and time when the object was created.
        /// </remarks>
        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     Gets or sets the transaction date.
        /// </summary>
        /// <value>
        ///     The transaction date.
        /// </value>
        /// <remarks>
        ///     This property represents the date of the transaction.
        /// </remarks>
        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }

        /// Represents a property with the name "_class".
        /// /
        [JsonPropertyName("_class")]
        public string Class { get; set; }

        /// <summary>
        ///     Gets or sets the option symbol.
        /// </summary>
        [JsonPropertyName("option_symbol")]
        public string OptionSymbol { get; set; }
    }
}