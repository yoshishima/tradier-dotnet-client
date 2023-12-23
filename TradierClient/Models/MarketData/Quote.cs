using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    /// Represents the root object for a quote.
    /// </summary>
    public class QuoteRootobject
    {
        /// <summary>
        /// Gets or sets the quotes.
        /// </summary>
        /// <value>
        /// The quotes.
        /// </value>
        [JsonPropertyName("quotes")] public Quotes Quotes { get; set; }
    }

    /// Represents a collection of quotes.
    /// /
    public class Quotes
    {
        /// <summary>
        /// Gets or sets the value of the Quote property.
        /// </summary>
        /// <value>
        /// A list of Quote objects representing quotes.
        /// </value>
        /// <remarks>
        /// The Quote property is decorated with the JsonPropertyName attribute,
        /// which specifies the name of the property when serialized to JSON.
        /// The property is also decorated with the JsonConverter attribute,
        /// which specifies the SingleOrArrayConverter class to be used during serialization.
        /// This converter allows the property to be serialized as either a single Quote object or an array of Quote objects.
        /// The Quote property is a list of Quote objects.
        /// Each Quote object represents a quote.
        /// </remarks>
        [JsonPropertyName("quote")]
        [JsonConverter(typeof(SingleOrArrayConverter<Quote>))]
        public List<Quote> Quote { get; set; }
    }

    /// <summary>
    /// Represents a quote for a financial instrument.
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// Gets or sets the symbol of the property.
        /// </summary>
        [JsonPropertyName("symbol")] public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the description of the property.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonPropertyName("description")] public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Exch property.
        /// </summary>
        [JsonPropertyName("exch")] public string Exch { get; set; }

        /// <summary>
        /// Represents the type property.
        /// </summary>
        /// <value>
        /// The value of the type property.
        /// </value>
        [JsonPropertyName("type")] public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the "last" property.
        /// </summary>
        /// <remarks>
        /// This property represents the last value. It is a nullable float.
        /// </remarks>
        [JsonPropertyName("last")] public float? Last { get; set; }

        /// <summary>
        /// Gets or sets the change value.
        /// </summary>
        /// <value>
        /// The change value.
        /// </value>
        [JsonPropertyName("change")] public float? Change { get; set; }

        /// <summary>
        /// Gets or sets the volume property.
        /// </summary>
        [JsonPropertyName("volume")] public int Volume { get; set; }

        /// <summary>
        /// Gets or sets the open price of an entity.
        /// </summary>
        /// <value>
        /// The open price.
        /// </value>
        [JsonPropertyName("open")] public float? Open { get; set; }

        /// <summary>
        /// Gets or sets the high value.
        /// </summary>
        /// <value>
        /// The high value.
        /// </value>
        [JsonPropertyName("high")] public float? High { get; set; }

        /// <summary>
        /// Gets or sets the low value.
        /// </summary>
        [JsonPropertyName("low")] public float? Low { get; set; }

        /// <summary>
        /// Gets or sets the closing value of the property.
        /// </summary>
        /// <value>
        /// The closing value, expressed as a nullable float.
        /// </value>
        [JsonPropertyName("close")] public float? Close { get; set; }

        /// <summary>
        /// Gets or sets the bid value.
        /// </summary>
        /// <value>
        /// The bid value.
        /// </value>
        [JsonPropertyName("bid")] public float? Bid { get; set; }

        /// <summary>
        /// Gets or sets the asking price for the property.
        /// </summary>
        /// <value>
        /// The asking price for the property.
        /// </value>
        [JsonPropertyName("ask")] public float? Ask { get; set; }

        /// <summary>
        /// Gets or sets the change percentage.
        /// </summary>
        /// <value>
        /// The change percentage.
        /// </value>
        [JsonPropertyName("change_percentage")]
        public float? ChangePercentage { get; set; }

        /// <summary>
        /// Gets or sets the average volume.
        /// </summary>
        /// <value>
        /// The average volume.
        /// </value>
        [JsonPropertyName("average_volume")] public int AverageVolume { get; set; }

        /// <summary>
        /// Gets or sets the last volume property.
        /// </summary>
        [JsonPropertyName("last_volume")] public int LastVolume { get; set; }

        /// <summary>
        /// Gets or sets the trade date.
        /// </summary>
        /// <value>
        /// The trade date.
        /// </value>
        [JsonPropertyName("trade_date")] public long TradeDate { get; set; }

        /// <summary>
        /// Gets or sets the previous closing value of a property.
        /// </summary>
        /// <remarks>
        /// This property represents the previous closing value of a property.
        /// The value can be null if the previous closing value is not available.
        /// </remarks>
        [JsonPropertyName("prevclose")] public float? Prevclose { get; set; }

        /// <summary>
        /// Gets or sets the week 52 high value for a particular property.
        /// </summary>
        /// <value>
        /// The week 52 high value.
        /// </value>
        [JsonPropertyName("week_52_high")] public float Week52High { get; set; }

        /// <summary>
        /// Gets or sets the 52-week low for the property.
        /// </summary>
        /// <value>
        /// The 52-week low value.
        /// </value>
        [JsonPropertyName("week_52_low")] public float Week52Low { get; set; }

        /// <summary>
        /// The size of the bid for this property.
        /// </summary>
        /// <value>
        /// An integer representing the size of the bid.
        /// </value>
        [JsonPropertyName("bidsize")] public int Bidsize { get; set; }

        /// <summary>
        /// Gets or sets the Bidexch property.
        /// </summary>
        /// <value>
        /// The Bidexch.
        /// </value>
        [JsonPropertyName("bidexch")] public string Bidexch { get; set; }

        /// <summary>
        /// Gets or sets the bid date in milliseconds since Unix epoch.
        /// </summary>
        /// <value>
        /// The bid date in milliseconds since Unix epoch.
        /// </value>
        [JsonPropertyName("bid_date")] public long BidDate { get; set; }

        /// <summary>
        /// Gets or sets the ask size.
        /// </summary>
        [JsonPropertyName("asksize")] public int Asksize { get; set; }

        /// <summary>
        /// Gets or sets the Askexch property.
        /// </summary>
        /// <value>
        /// The value of the Askexch property.
        /// </value>
        [JsonPropertyName("askexch")] public string Askexch { get; set; }

        /// <summary>
        /// Gets or sets the ask date in milliseconds.
        /// </summary>
        /// <value>
        /// The ask date.
        /// </value>
        [JsonPropertyName("ask_date")] public long AskDate { get; set; }

        /// <summary>
        /// Gets or sets the value of the RootSymbols property.
        /// </summary>
        /// <value>
        /// The value of the RootSymbols property.
        /// </value>
        [JsonPropertyName("root_symbols")] public string RootSymbols { get; set; }

        /// <summary>
        /// Gets or sets the underlying value.
        /// </summary>
        /// <value>
        /// The underlying value.
        /// </value>
        [JsonPropertyName("underlying")] public string Underlying { get; set; }

        /// <summary>
        /// Gets or sets the strike property.
        /// </summary>
        /// <value>
        /// The strike value.
        /// </value>
        [JsonPropertyName("strike")] public float Strike { get; set; }

        /// <summary>
        /// Gets or sets the open interest value.
        /// </summary>
        /// <value>
        /// The open interest.
        /// </value>
        [JsonPropertyName("open_interest")] public int OpenInterest { get; set; }

        /// <summary>
        /// Gets or sets the contract size.
        /// </summary>
        /// <value>
        /// The contract size.
        /// </value>
        [JsonPropertyName("contract_size")] public int ContractSize { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        [JsonPropertyName("expiration_date")] public string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration type of a property.
        /// </summary>
        /// <value>
        /// The expiration type.
        /// </value>
        [JsonPropertyName("expiration_type")] public string ExpirationType { get; set; }

        /// <summary>
        /// Gets or sets the type of option.
        /// </summary>
        /// <value>
        /// The option type.
        /// </value>
        [JsonPropertyName("option_type")] public string OptionType { get; set; }

        /// <summary>
        /// Gets or sets the root symbol of a property.
        /// </summary>
        /// <value>
        /// The root symbol.
        /// </value>
        [JsonPropertyName("root_symbol")] public string RootSymbol { get; set; }
    }
}