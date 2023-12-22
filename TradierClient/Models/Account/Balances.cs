using System.Text.Json.Serialization;


namespace Tradier.Client.Models.Account
{
    /// <summary>
    /// Represents a root object containing balances.
    /// </summary>
    public class BalanceRootObject
    {
        /// <summary>
        /// Gets or sets the balances for the property.
        /// </summary>
        [JsonPropertyName("balances")]
        public Balances Balances { get; set; }
    }

    /// <summary>
    /// Represents the balances of a trading account.
    /// </summary>
    public class Balances
    {
        /// <summary>
        /// Gets or sets the value of the "option_short_value" property.
        /// </summary>
        /// <remarks>
        /// This property represents a floating-point value that corresponds to the JSON property "option_short_value".
        /// </remarks>
        /// <value>
        /// A float value representing the "option_short_value".
        /// </value>
        [JsonPropertyName("option_short_value")]
        public float OptionShortValue { get; set; }

        /// <summary>
        /// Gets or sets the TotalEquity of the object.
        /// </summary>
        /// <remarks>
        /// The TotalEquity property represents the total equity of an object.
        /// </remarks>
        /// <value>
        /// The total equity.
        /// </value>
        [JsonPropertyName("total_equity")]
        public float TotalEquity { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the account type.
        /// </summary>
        /// <value>
        /// The account type.
        /// </value>
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or sets the close PL (Profit/Loss).
        /// </summary>
        /// <value>
        /// The close PL (Profit/Loss).
        /// </value>
        [JsonPropertyName("close_pl")]
        public float ClosePL { get; set; }

        /// <summary>
        /// Gets or sets the current requirement.
        /// </summary>
        /// <value>
        /// The current requirement.
        /// </value>
        [JsonPropertyName("current_requirement")]
        public float CurrentRequirement { get; set; }

        /// <summary>
        /// Gets or sets the equity.
        /// </summary>
        /// <value>
        /// The equity.
        /// </value>
        [JsonPropertyName("equity")]
        public int Equity { get; set; }

        /// <summary>
        /// Gets or sets the long market value.
        /// </summary>
        /// <value>
        /// The long market value.
        /// </value>
        [JsonPropertyName("long_market_value")]
        public float LongMarketValue { get; set; }

        /// <summary>
        /// The market value of a property.
        /// </summary>
        /// <value>
        /// The market value of the property.
        /// </value>
        [JsonPropertyName("market_value")]
        public float MarketValue { get; set; }

        /// <summary>
        /// Property representing the Open P&L (Profit and Loss) value.
        /// </summary>
        /// <value>
        /// The Open P&L value.
        /// </value>
        [JsonPropertyName("open_pl")]
        public float OpenPL { get; set; }

        /// <summary>
        /// Gets or sets the value of the OptionLongValue property.
        /// </summary>
        /// <value>
        /// The value of the OptionLongValue property.
        /// </value>
        /// <remarks>
        /// This property represents the long value of an option.
        /// </remarks>
        [JsonPropertyName("option_long_value")]
        public float OptionLongValue { get; set; }

        /// <summary>
        /// Represents the option requirement property.
        /// </summary>
        [JsonPropertyName("option_requirement")]
        public float OptionRequirement { get; set; }

        /// <summary>
        /// Gets or sets the count of pending orders.
        /// </summary>
        /// <value>
        /// The count of pending orders.
        /// </value>
        [JsonPropertyName("pending_orders_count")]
        public int PendingOrdersCount { get; set; }

        /// <summary>
        /// Gets or sets the short market value of the property.
        /// </summary>
        /// <value>
        /// The short market value.
        /// </value>
        /// [JsonPropertyName("short_market_value")]
        [JsonPropertyName("short_market_value")]
        public float ShortMarketValue { get; set; }

        /// <summary>
        /// Gets or sets the value of the stock as a long.
        /// </summary>
        /// <value>
        /// The value of the stock as a long.
        /// </value>
        [JsonPropertyName("stock_long_value")]
        public float StockLongValue { get; set; }

        /// <summary>
        /// Gets or sets the TotalCash property. </summary> <value>
        /// The total cash value. </value> <remarks>
        /// This property represents the total cash value. </remarks> <example>
        /// This example demonstrates how to use the TotalCash property. <code>
        /// MyClass myObj = new MyClass();
        /// float cash = myObj.TotalCash; </code> </example>
        /// /
        [JsonPropertyName("total_cash")]
        public float TotalCash { get; set; }

        /// <summary>
        /// Represents the amount of uncleared funds.
        /// </summary>
        /// <value>
        /// The amount of uncleared funds.
        /// </value>
        [JsonPropertyName("uncleared_funds")]
        public float UnclearedFunds { get; set; }

        /// <summary>
        /// Gets or sets the pending cash.
        /// </summary>
        /// <value>
        /// The pending cash.
        /// </value>
        [JsonPropertyName("pending_cash")]
        public float PendingCash { get; set; }

        /// <summary>
        /// Gets or sets the margin value.
        /// </summary>
        [JsonPropertyName("margin")]
        public Margin Margin { get; set; }

        /// <summary>
        /// Represents cash in a financial transaction.
        /// </summary>
        [JsonPropertyName("cash")]
        public Cash Cash { get; set; }

        /// <summary>
        /// Gets or sets the instance of PatternDayTrader.
        /// </summary>
        /// <remarks>
        /// The PatternDayTrader property represents the pattern day trading status of a trader.
        /// </remarks>
        /// <value>
        /// The PatternDayTrader instance.
        /// </value>
        [JsonPropertyName("pdt")]
        public PatternDayTrader PatternDayTrader { get; set; }
    }

    /// <summary>
    /// Represents the margin details for a trading account.
    /// </summary>
    public class Margin
    {
        /// <summary>
        /// Gets or sets the value of the property "FedCall".
        /// </summary>
        /// <value>
        /// The value of "FedCall".
        /// </value>
        /// <remarks>
        /// This property is used to store an integer value for "FedCall".
        /// </remarks>
        [JsonPropertyName("fed_call")]
        public int FedCall { get; set; }

        /// <summary>
        /// Gets or sets the maintenance call property.
        /// </summary>
        /// <value>
        /// The maintenance call.
        /// </value>
        [JsonPropertyName("maintenance_call")]
        public int MaintenanceCall { get; set; }

        /// <summary>
        /// Gets or sets the option buying power.
        /// </summary>
        /// <value>
        /// The option buying power.
        /// </value>
        [JsonPropertyName("option_buying_power")]
        public float OptionBuyingPower { get; set; }

        /// <summary>
        /// Gets or sets the stock buying power.
        /// </summary>
        /// <value>
        /// The stock buying power.
        /// </value>
        [JsonPropertyName("stock_buying_power")]
        public float StockBuyingPower { get; set; }

        /// <summary>
        /// Gets or sets the stock short value.
        /// </summary>
        /// <value>
        /// The stock short value.
        /// </value>
        [JsonPropertyName("stock_short_value")]
        public int StockShortValue { get; set; }

        /// <summary>
        /// Gets or sets the value of the Sweep property.
        /// </summary>
        /// <value>
        /// The value of the Sweep property.
        /// </value>
        [JsonPropertyName("sweep")]
        public int Sweep { get; set; }
    }

    /// <summary>
    /// Represents cash related information.
    /// </summary>
    public class Cash
    {
        /// <summary>
        /// Gets or sets the available cash for the user.
        /// </summary>
        /// <value>
        /// The available cash.
        /// </value>
        [JsonPropertyName("cash_available")]
        public float CashAvailable { get; set; }

        /// <summary>
        /// Gets or sets the sweep property.
        /// </summary>
        /// <value>
        /// The sweep.
        /// </value>
        [JsonPropertyName("sweep")]
        public int Sweep { get; set; }

        /// <summary>
        /// Gets or sets the amount of funds that are currently unsettled. </summary>
        /// <value>
        /// The amount of unsettled funds. </value>
        /// /
        [JsonPropertyName("unsettled_funds")]
        public float UnsettledFunds { get; set; }
    }

    /// <summary>
    /// Represents a pattern day trader with their trading information.
    /// </summary>
    public class PatternDayTrader
    {
        /// <summary>
        /// Represents the value of the FedCall property.
        /// </summary>
        /// <value>
        /// The value of the FedCall property.
        /// </value>
        [JsonPropertyName("fed_call")]
        public int FedCall { get; set; }

        /// Represents a property maintenance call.
        /// /
        [JsonPropertyName("maintenance_call")]
        public int MaintenanceCall { get; set; }

        /// Gets or sets the option buying power. </summary> <value>
        /// The option buying power. </value>
        [JsonPropertyName("option_buying_power")]
        public float OptionBuyingPower { get; set; }

        /// <summary>
        /// Gets or sets the stock buying power.
        /// </summary>
        /// <value>
        /// The stock buying power.
        /// </value>
        [JsonPropertyName("stock_buying_power")]
        public float StockBuyingPower { get; set; }

        /// <summary>
        /// Gets or sets the stock short value.
        /// </summary>
        /// <value>
        /// The stock short value.
        /// </value>
        [JsonPropertyName("stock_short_value")]
        public int StockShortValue { get; set; }
    }

}