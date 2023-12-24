using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    ///     Represents a root object that contains the option chain data.
    /// </summary>
    public class OptionChainRootobject
    {
        /// <summary>
        ///     Gets or sets the options for the property.
        /// </summary>
        /// <value>
        ///     The options for the property.
        /// </value>
        [JsonPropertyName("options")]
        public Options Options { get; set; }
    }

    /// <summary>
    ///     Represents a collection of options.
    /// </summary>
    public class Options
    {
        /// <summary>
        ///     Represents an option.
        /// </summary>
        /// <value>
        ///     The list of options.
        /// </value>
        [JsonPropertyName("option")]
        [JsonConverter(typeof(SingleOrArrayConverter<Option>))]
        public List<Option> Option { get; set; }
    }

    /// <summary>
    ///     Represents an option contract with various properties.
    /// </summary>
    public class Option
    {
        /// <summary>
        ///     Gets or sets the symbol property.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the description of the property.
        /// </summary>
        /// <value>
        ///     The description of the property.
        /// </value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the exchange of the property.
        /// </summary>
        /// <value>
        ///     The exchange of the property.
        /// </value>
        [JsonPropertyName("exch")]
        public string Exchange { get; set; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        /// <remarks>
        ///     This property represents the type of the property. It is used to define the data type of the property in the JSON
        ///     object.
        /// </remarks>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the Last property.
        /// </summary>
        /// <value>
        ///     The last value as a nullable float.
        /// </value>
        [JsonPropertyName("last")]
        public float? Last { get; set; }

        /// <summary>
        ///     Gets or sets the change value.
        /// </summary>
        /// <value>
        ///     The change value.
        /// </value>
        [JsonPropertyName("change")]
        public float? Change { get; set; }

        /// <summary>
        ///     Gets or sets the volume property.
        /// </summary>
        /// <value>
        ///     The volume value.
        /// </value>
        [JsonPropertyName("volume")]
        public int Volume { get; set; }

        /// <summary>
        ///     Gets or sets the opening value of the property.
        /// </summary>
        /// <value>
        ///     The opening value of the property.
        /// </value>
        [JsonPropertyName("open")]
        public float? Open { get; set; }

        /// <summary>
        ///     Gets or sets the high value of the property.
        /// </summary>
        /// <value>
        ///     The high value. This value can be null.
        /// </value>
        [JsonPropertyName("high")]
        public float? High { get; set; }

        /// <summary>
        ///     Gets or sets the low property.
        /// </summary>
        /// <value>
        ///     The low property value.
        /// </value>
        [JsonPropertyName("low")]
        public float? Low { get; set; }

        /// <summary>
        ///     Gets or sets the closing price of the property.
        /// </summary>
        /// <remarks>
        ///     This property represents the closing price of the property on a specific date.
        ///     The closing price is a float value and can be null if the closing price is not available.
        /// </remarks>
        [JsonPropertyName("close")]
        public float? Close { get; set; }

        /// <summary>
        ///     Gets or sets the bid value.
        /// </summary>
        /// <value>The bid value.</value>
        [JsonPropertyName("bid")]
        public float? Bid { get; set; }

        /// <summary>
        ///     Gets or sets the ask price for an item.
        /// </summary>
        /// <value>
        ///     The ask price, represented as a nullable float.
        /// </value>
        [JsonPropertyName("ask")]
        public float? Ask { get; set; }

        /// <summary>
        ///     Gets or sets the underlying property.
        /// </summary>
        /// <value>
        ///     The underlying property.
        /// </value>
        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        /// <summary>
        ///     Gets or sets the strike value of the property.
        /// </summary>
        /// <value>
        ///     The strike value.
        /// </value>
        [JsonPropertyName("strike")]
        public float Strike { get; set; }

        /// <summary>
        ///     Gets or sets the change percentage.
        /// </summary>
        /// <value>
        ///     The change percentage.
        /// </value>
        [JsonPropertyName("change_percentage")]
        public float? ChangePercentage { get; set; }

        /// <summary>
        ///     Gets or sets the average volume of a property.
        /// </summary>
        /// <value>
        ///     An integer representing the average volume of a property.
        /// </value>
        [JsonPropertyName("average_volume")]
        public int AverageVolume { get; set; }

        /// <summary>
        ///     Gets or sets the value of the last volume.
        /// </summary>
        /// <value>
        ///     The value of the last volume.
        /// </value>
        [JsonPropertyName("last_volume")]
        public int LastVolume { get; set; }

        /// <summary>
        ///     Gets or sets the trade date.
        /// </summary>
        /// <value>
        ///     The trade date.
        /// </value>
        [JsonPropertyName("trade_date")]
        [JsonConverter(typeof(MillisecondsEpochConverter))]
        public DateTime TradeDate { get; set; }

        /// <summary>
        ///     Gets or sets the previous closing price of a stock.
        /// </summary>
        /// <value>
        ///     The previous closing price.
        /// </value>
        [JsonPropertyName("prevclose")]
        public float? PreviousClose { get; set; }

        /// <summary>
        ///     Gets or sets the 52-week high value.
        /// </summary>
        /// <value>
        ///     The 52-week high value.
        /// </value>
        [JsonPropertyName("week_52_high")]
        public float Week52High { get; set; }

        /// <summary>
        ///     Gets or sets the 52-week low for a given property.
        /// </summary>
        /// <value>
        ///     The 52-week low value.
        /// </value>
        [JsonPropertyName("week_52_low")]
        public float Week52Low { get; set; }

        /// at a given bid price.
        /// /
        [JsonPropertyName("bidsize")]
        public int BidSize { get; set; }

        /// <summary>
        ///     Gets or sets the bid exchange.
        /// </summary>
        /// <value>
        ///     The bid exchange.
        /// </value>
        [JsonPropertyName("bidexch")]
        public string BidExchange { get; set; }

        /// <summary>
        ///     Gets or sets the bid date.
        /// </summary>
        /// <value>
        ///     The bid date.
        /// </value>
        /// <remarks>
        ///     This property represents the date and time when a bid is made.
        /// </remarks>
        [JsonPropertyName("bid_date")]
        [JsonConverter(typeof(MillisecondsEpochConverter))]
        public DateTime BidDate { get; set; }

        /// <summary>
        ///     Gets or sets the ask size of a property.
        /// </summary>
        /// <value>
        ///     The ask size.
        /// </value>
        [JsonPropertyName("asksize")]
        public int AskSize { get; set; }

        /// <summary>
        ///     Gets or sets the ask exchange for the property.
        /// </summary>
        /// <value>
        ///     The ask exchange.
        /// </value>
        /// <remarks>
        ///     This property represents the exchange at which the asking price of a product or service is quoted.
        ///     It is used to identify the specific exchange platform where the ask price is visible.
        /// </remarks>
        [JsonPropertyName("askexch")]
        public string AskExchange { get; set; }

        /// <summary>
        ///     Gets or sets the ask date.
        /// </summary>
        /// <value>
        ///     The ask date.
        /// </value>
        [JsonPropertyName("ask_date")]
        [JsonConverter(typeof(MillisecondsEpochConverter))]
        public DateTime AskDate { get; set; }

        /// <summary>
        ///     Gets or sets the open interest.
        /// </summary>
        /// <value>
        ///     The open interest.
        /// </value>
        [JsonPropertyName("open_interest")]
        public int OpenInterest { get; set; }

        /// <summary>
        ///     Gets or sets the contract size for a property.
        /// </summary>
        /// <value>
        ///     The contract size.
        /// </value>
        [JsonPropertyName("contract_size")]
        public int ContractSize { get; set; }

        /// <summary>
        ///     Gets or sets the expiration date.
        /// </summary>
        /// <value>
        ///     The expiration date.
        /// </value>
        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; }

        /// <summary>
        ///     Gets or sets the expiration type of the property.
        /// </summary>
        /// @JsonPropertyName("expiration_type") public string ExpirationType { get; set; }
        /// /
        [JsonPropertyName("expiration_type")]
        public string ExpirationType { get; set; }

        /// <summary>
        ///     Gets or sets the option type.
        /// </summary>
        /// <value>
        ///     The option type.
        /// </value>
        [JsonPropertyName("option_type")]
        public string OptionType { get; set; }

        /// <summary>
        ///     Gets or sets the root symbol.
        /// </summary>
        /// <value>
        ///     The root symbol.
        /// </value>
        [JsonPropertyName("root_symbol")]
        public string RootSymbol { get; set; }

        /// <summary>
        ///     Gets or sets the Greeks property.
        /// </summary>
        /// <value>
        ///     A <see cref="Greeks" /> object representing the Greeks.
        /// </value>
        [JsonPropertyName("greeks")]
        public Greeks Greeks { get; set; }
    }

    /// <summary>
    ///     Represents the Greeks for an options contract.
    /// </summary>
    public class Greeks
    {
        /// <summary>
        ///     Gets or sets the Delta value.
        /// </summary>
        /// <value>
        ///     The Delta value.
        /// </value>
        [JsonPropertyName("delta")]
        public float Delta { get; set; }

        /// <summary>
        ///     Gets or sets the "gamma" property.
        /// </summary>
        /// <value>
        ///     The value of the "gamma" property.
        /// </value>
        /// <remarks>
        ///     This property represents the gamma value used in color calculations.
        /// </remarks>
        [JsonPropertyName("gamma")]
        public float Gamma { get; set; }

        /// <summary>
        ///     Gets or sets the value of Theta.
        /// </summary>
        /// <value>
        ///     The value of Theta.
        /// </value>
        [JsonPropertyName("theta")]
        public float Theta { get; set; }

        /// <summary>
        ///     Gets or sets the vega value.
        /// </summary>
        /// <value>
        ///     The vega value.
        /// </value>
        [JsonPropertyName("vega")]
        public float Vega { get; set; }

        /// <summary>
        ///     Gets or sets the value of the Rho property.
        /// </summary>
        /// <value>
        ///     The value of the Rho property.
        /// </value>
        [JsonPropertyName("rho")]
        public float Rho { get; set; }

        /// <summary>
        ///     Gets or sets the value of Phi.
        /// </summary>
        /// <remarks>
        ///     This property represents the Phi value.
        /// </remarks>
        /// <value>
        ///     The value of Phi.
        /// </value>
        [JsonPropertyName("phi")]
        public float Phi { get; set; }

        /// <summary>
        ///     Gets or sets the bid implied volatility.
        /// </summary>
        /// <value>
        ///     The bid implied volatility.
        /// </value>
        [JsonPropertyName("bid_iv")]
        public float BidIV { get; set; }

        /// <summary>
        ///     Gets or sets the value of MidIV.
        /// </summary>
        /// <value>
        ///     The value of MidIV.
        /// </value>
        [JsonPropertyName("mid_iv")]
        public float MidIV { get; set; }

        /// <summary>
        ///     Gets or sets the asking implied volatility (IV) for an option.
        /// </summary>
        /// <value>
        ///     The asking implied volatility (IV) for an option.
        /// </value>
        [JsonPropertyName("ask_iv")]
        public float AskIV { get; set; }

        /// <summary>
        ///     The SmvIV property represents the Smv volume for an object.
        /// </summary>
        /// <value>
        ///     A float representing the Smv volume.
        /// </value>
        [JsonPropertyName("smv_vol")]
        public float SmvIV { get; set; }

        /// <summary>
        ///     Gets or sets the updated date and time.
        /// </summary>
        /// <value>
        ///     The updated date and time.
        /// </value>
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(ParseExactConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}