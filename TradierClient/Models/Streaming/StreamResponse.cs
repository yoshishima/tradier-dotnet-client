namespace Tradier.Client.Models.Streaming
{
    /// <summary>
    ///     Represents a response object that contains various stream data.
    /// </summary>
    public class StreamResponse
    {
        /// <summary>
        ///     Gets or sets the quote stream property.
        /// </summary>
        public QuoteStream QuoteStream { get; set; }

        /// <summary>
        ///     Gets or sets the TradeStream property.
        /// </summary>
        /// <value>
        ///     The TradeStream object representing the stream of trades.
        /// </value>
        public TradeStream TradeStream { get; set; }

        /// <summary>
        ///     Gets or sets the SummaryStream property.
        /// </summary>
        /// <value>
        ///     The SummaryStream property represents a summary stream.
        /// </value>
        public SummaryStream SummaryStream { get; set; }

        /// <summary>
        ///     Gets or sets the TimeSaleStream property.
        /// </summary>
        /// <value>
        ///     The TimeSaleStream property.
        /// </value>
        public TimeSaleStream TimeSaleStream { get; set; }

        /// <summary>
        ///     Gets or sets the TradeXStream object.
        /// </summary>
        /// <value>
        ///     The TradeXStream object.
        /// </value>
        public TradeXStream TradeXStream { get; set; }
    }

    /// <summary>
    ///     Represents a stream of quotes for a particular symbol.
    /// </summary>
    public class QuoteStream
    {
        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        ///     Gets or sets the symbol.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        public string symbol { get; set; }

        /// Gets or sets the bid value.
        /// @value The bid value to set.
        /// /
        public float bid { get; set; }

        /// <summary>
        ///     Gets or sets the bid size for a property.
        /// </summary>
        /// <value>
        ///     The bid size.
        /// </value>
        public int bidsz { get; set; }

        /// <summary>
        ///     Gets or sets the bid exchange string.
        /// </summary>
        /// <value>
        ///     The bid exchange string.
        /// </value>
        public string bidexch { get; set; }

        /// <summary>
        ///     Gets or sets the bid date.
        /// </summary>
        /// <value>The bid date.</value>
        public string biddate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the ask property.
        /// </summary>
        /// <value>
        ///     The value of the ask property.
        /// </value>
        public float ask { get; set; }

        /// <summary>
        ///     Gets or sets the value of asksz.
        /// </summary>
        /// <value>
        ///     The value of asksz.
        /// </value>
        public int asksz { get; set; }

        /// <summary>
        ///     Gets or sets the askexch property.
        /// </summary>
        /// <value>
        ///     The askexch property stores a string value.
        /// </value>
        public string askexch { get; set; }

        /// <summary>
        ///     Gets or sets the askdate property.
        /// </summary>
        /// <remarks>
        ///     This property represents the date when the software prompts the user to enter a date.
        /// </remarks>
        /// <value>
        ///     A string representing the prompt for the user to enter a date.
        /// </value>
        public string askdate { get; set; }
    }

    /// <summary>
    ///     Represents a trade stream containing information about a trade.
    /// </summary>
    public class TradeStream
    {
        /// <summary>
        ///     Gets or sets the type of the property,
        /// </summary>
        /// <value>
        ///     A string representing the type of the property.
        /// </value>
        public string type { get; set; }

        /// <summary>
        ///     Gets or sets the symbol.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        public string symbol { get; set; }

        /// <summary>
        ///     Represents the exch property.
        /// </summary>
        /// <value>
        ///     The value of the exch property.
        /// </value>
        public string exch { get; set; }

        /// <summary>
        ///     Gets or sets the price of the property.
        /// </summary>
        /// <value>
        ///     The price of the property.
        /// </value>
        public string price { get; set; }

        /// <summary>
        ///     Gets or sets the size of the property.
        /// </summary>
        /// <value>
        ///     The size of the property.
        /// </value>
        public string size { get; set; }

        /// <summary>
        ///     Gets or sets the value of cvol.
        /// </summary>
        public string cvol { get; set; }

        /// <summary>
        ///     Gets or sets the value of the date property.
        /// </summary>
        public string date { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string last { get; set; }
    }

    /// <summary>
    ///     Class representing a summary of a stream.
    /// </summary>
    public class SummaryStream
    {
        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     A string representing the type of the property.
        /// </value>
        public string type { get; set; }

        /// <summary>
        ///     Gets or sets the symbol.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        public string symbol { get; set; }

        /// <summary>
        ///     Gets or sets the open property.
        /// </summary>
        /// <value>
        ///     The open property.
        /// </value>
        public string open { get; set; }

        /// Gets or sets the value of the 'high' property.
        /// @property   {string} high   The value of the 'high' property.
        /// /
        public string high { get; set; }

        /// <summary>
        ///     Gets or sets the value of the 'low' property.
        /// </summary>
        /// <value>
        ///     The value of the 'low' property.
        /// </value>
        public string low { get; set; }

        /// <summary>
        ///     Represents the previous closing price of a stock or financial instrument.
        /// </summary>
        /// <remarks>
        ///     The prevClose property stores the value of the previous closing price as a string.
        /// </remarks>
        /// <value>
        ///     A string representing the previous closing price.
        /// </value>
        /// /
        public string prevClose { get; set; }
    }

    /// <summary>
    ///     Represents a time sale stream.
    /// </summary>
    public class TimeSaleStream
    {
        /// <summary>
        ///     Represents the type of a property.
        /// </summary>
        /// <value>
        ///     A <see cref="System.String" /> representing the type of the property.
        /// </value>
        public string type { get; set; }

        /// <summary>
        ///     Gets or sets the symbol for the property.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        public string symbol { get; set; }

        /// <summary>
        ///     Gets or sets the value of the exch property.
        /// </summary>
        /// <value>
        ///     A string representing the value of the exch property.
        /// </value>
        public string exch { get; set; }

        /// <summary>
        ///     Gets or sets the bid value.
        /// </summary>
        /// <value>
        ///     The bid value.
        /// </value>
        public string bid { get; set; }

        /// <summary>
        ///     Gets or sets the value of the ask property.
        /// </summary>
        /// <value>
        ///     The value of the ask property.
        /// </value>
        public string ask { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string last { get; set; }

        /// <summary>
        ///     Gets or sets the size of the property.
        /// </summary>
        /// <value>
        ///     The size of the property.
        /// </value>
        public string size { get; set; }

        /// <summary>
        ///     Gets or sets the date property.
        /// </summary>
        /// <value>
        ///     The date as a string.
        /// </value>
        public string date { get; set; }

        /// <summary>
        ///     Gets or sets the value of the 'seq' property.
        /// </summary>
        /// <value>
        ///     The value of the 'seq' property. Default value is 0.
        /// </value>
        public int seq { get; set; }

        /// <summary>
        ///     Gets or sets the flag property.
        /// </summary>
        /// <value>
        ///     The flag property.
        /// </value>
        public string flag { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this property has been cancelled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if cancelled; otherwise, <c>false</c>.
        /// </value>
        public bool cancel { get; set; }

        /// <summary>
        ///     Gets or sets a boolean value indicating whether the property should be corrected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the property should be corrected; otherwise, <c>false</c>.
        /// </value>
        public bool correction { get; set; }

        /// <summary>
        ///     Gets or sets the session property.
        /// </summary>
        /// <value>
        ///     A string representing the session.
        /// </value>
        public string session { get; set; }
    }

    /// <summary>
    ///     Represents a trade in a streaming feed.
    /// </summary>
    public class TradeXStream
    {
        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        public string type { get; set; }

        /// <summary>
        ///     Gets or sets the symbol property.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        public string symbol { get; set; }

        /// <summary>
        ///     Gets or sets the value of the exch property.
        /// </summary>
        /// <value>
        ///     The value of the exch property.
        /// </value>
        public string exch { get; set; }

        /// <summary>
        ///     Gets or sets the price of the property.
        /// </summary>
        /// <value>
        ///     The price of the property.
        /// </value>
        public string price { get; set; }

        /// <summary>
        ///     Gets or sets the size of the property.
        /// </summary>
        /// <value>
        ///     The size of the property.
        /// </value>
        public string size { get; set; }

        /// <summary>
        ///     Gets or sets the cvol property.
        /// </summary>
        /// <value>
        ///     The cvol property.
        /// </value>
        public string cvol { get; set; }

        /// <summary>
        ///     Gets or sets the date property.
        /// </summary>
        /// <value>
        ///     The date as a string.
        /// </value>
        public string date { get; set; }

        /// <summary>
        ///     This property gets or sets the last name of an entity.
        /// </summary>
        public string last { get; set; }
    }
}