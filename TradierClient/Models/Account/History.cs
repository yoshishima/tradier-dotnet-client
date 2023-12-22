using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Account
{
    /// <summary>
    ///     Represents the root object of a history.
    /// </summary>
    public class HistoryRootobject
    {
        /// <summary>
        ///     Gets or sets the history for the given property.
        /// </summary>
        /// <value>
        ///     The history object that represents the historical data for the property.
        /// </value>
        [JsonPropertyName("history")]
        public History History { get; set; }
    }

    /// <summary>
    ///     Represents a history object that contains a list of events.
    /// </summary>
    public class History
    {
        /// <summary>
        ///     Represents a list of events.
        /// </summary>
        [JsonPropertyName("event")]
        public List<Event> Event { get; set; }
    }

    /// <summary>
    ///     Represents an event in the system.
    /// </summary>
    public class Event
    {
        /// <summary>
        ///     Gets or sets the amount property.
        /// </summary>
        /// <value>
        ///     The amount value.
        /// </value>
        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        /// <summary>
        ///     Gets or sets the date value.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Represents a trade property.
        /// </summary>
        [JsonPropertyName("trade")]
        public Trade Trade { get; set; }

        /// <summary>
        ///     Gets or sets the adjustment for the property.
        /// </summary>
        /// <value>The adjustment.</value>
        [JsonPropertyName("adjustment")]
        public Adjustment Adjustment { get; set; }

        /// <summary>
        ///     Represents an option.
        /// </summary>
        [JsonPropertyName("option")]
        public Option Option { get; set; }

        /// <summary>
        ///     Gets or sets the journal property.
        /// </summary>
        /// <value>
        ///     The journal.
        /// </value>
        [JsonPropertyName("journal")]
        public Journal Journal { get; set; }
    }

    /// <summary>
    ///     Represents a trade.
    /// </summary>
    public class Trade
    {
        /// <summary>
        ///     Gets or sets the commission.
        /// </summary>
        /// <value>
        ///     The commission.
        /// </value>
        [JsonPropertyName("commission")]
        public float Commission { get; set; }

        /// <summary>
        ///     Gets or sets the description of the property.
        /// </summary>
        /// <value>
        ///     The description of the property.
        /// </value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the price of the property.
        /// </summary>
        /// <value>
        ///     The price of the property.
        /// </value>
        [JsonPropertyName("price")]
        public float Price { get; set; }

        /// <summary>
        ///     Gets or sets the value of the Quantity property.
        /// </summary>
        /// <value>
        ///     The value representing the quantity.
        /// </value>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the symbol.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the trade type.
        /// </summary>
        [JsonPropertyName("trade_type")]
        public string TradeType { get; set; }
    }

    /// <summary>
    ///     Represents an adjustment with a description and quantity.
    /// </summary>
    /// /
    public class Adjustment
    {
        /// <summary>
        ///     Gets or sets the Description property.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the quantity value.
        /// </summary>
        /// <value>
        ///     The quantity value.
        /// </value>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }
    }

    /// <summary>
    ///     Represents an option.
    /// </summary>
    public class Option
    {
        /// <summary>
        ///     Represents an option type.
        /// </summary>
        /// <remarks>
        ///     This property is used to store the type of an option.
        /// </remarks>
        [JsonPropertyName("option_type")]
        public string OptionType { get; set; }

        /// A string property that represents the description of an object.
        /// /
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the quantity value.
        /// </summary>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }
    }

    /// <summary>
    ///     Represents a journal.
    /// </summary>
    public class Journal
    {
        /// <summary>
        ///     Gets or sets the description of the property.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }
    }
}