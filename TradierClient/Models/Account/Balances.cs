using System.Text.Json.Serialization;


namespace Tradier.Client.Models.Account
{
    public class BalanceRootObject
    {
        [JsonPropertyName("balances")]
        public Balances Balances { get; set; }
    }

    public class Balances
    {
        [JsonPropertyName("option_short_value")]
        public float OptionShortValue { get; set; }

        [JsonPropertyName("total_equity")]
        public float TotalEquity { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        [JsonPropertyName("close_pl")]
        public float ClosePL { get; set; }

        [JsonPropertyName("current_requirement")]
        public float CurrentRequirement { get; set; }

        [JsonPropertyName("equity")]
        public int Equity { get; set; }

        [JsonPropertyName("long_market_value")]
        public float LongMarketValue { get; set; }

        [JsonPropertyName("market_value")]
        public float MarketValue { get; set; }

        [JsonPropertyName("open_pl")]
        public float OpenPL { get; set; }

        [JsonPropertyName("option_long_value")]
        public float OptionLongValue { get; set; }

        [JsonPropertyName("option_requirement")]
        public float OptionRequirement { get; set; }

        [JsonPropertyName("pending_orders_count")]
        public int PendingOrdersCount { get; set; }

        [JsonPropertyName("short_market_value")]
        public float ShortMarketValue { get; set; }

        [JsonPropertyName("stock_long_value")]
        public float StockLongValue { get; set; }

        [JsonPropertyName("total_cash")]
        public float TotalCash { get; set; }

        [JsonPropertyName("uncleared_funds")]
        public int UnclearedFunds { get; set; }

        [JsonPropertyName("pending_cash")]
        public float PendingCash { get; set; }

        [JsonPropertyName("margin")]
        public Margin Margin { get; set; }

        [JsonPropertyName("cash")]
        public Cash Cash { get; set; }

        [JsonPropertyName("pdt")]
        public PatternDayTrader PatternDayTrader { get; set; }
    }

    public class Margin
    {
        [JsonPropertyName("fed_call")]
        public int FedCall { get; set; }

        [JsonPropertyName("maintenance_call")]
        public int MaintenanceCall { get; set; }

        [JsonPropertyName("option_buying_power")]
        public float OptionBuyingPower { get; set; }

        [JsonPropertyName("stock_buying_power")]
        public float StockBuyingPower { get; set; }

        [JsonPropertyName("stock_short_value")]
        public int StockShortValue { get; set; }

        [JsonPropertyName("sweep")]
        public int Sweep { get; set; }
    }

    public class Cash
    {
        [JsonPropertyName("cash_available")]
        public float CashAvailable { get; set; }

        [JsonPropertyName("sweep")]
        public int Sweep { get; set; }

        [JsonPropertyName("unsettled_funds")]
        public float UnsettledFunds { get; set; }
    }

    public class PatternDayTrader
    {
        [JsonPropertyName("fed_call")]
        public int FedCall { get; set; }

        [JsonPropertyName("maintenance_call")]
        public int MaintenanceCall { get; set; }

        [JsonPropertyName("option_buying_power")]
        public float OptionBuyingPower { get; set; }

        [JsonPropertyName("stock_buying_power")]
        public float StockBuyingPower { get; set; }

        [JsonPropertyName("stock_short_value")]
        public int StockShortValue { get; set; }
    }

}