using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{

    public class QuoteRootobject
    {
        [JsonPropertyName("quotes")]
        public Quotes Quotes { get; set; }
    }

    public class Quotes
    {
        [JsonPropertyName("quote")]
        [JsonConverter(typeof(SingleOrArrayConverter<Quote>))]
        public List<Quote> Quote { get; set; }
    }

    public class Quote
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("exch")]
        public string Exch { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("last")]
        public float? Last { get; set; }

        [JsonPropertyName("change")]
        public float? Change { get; set; }

        [JsonPropertyName("volume")]
        public int Volume { get; set; }

        [JsonPropertyName("open")]
        public float? Open { get; set; }

        [JsonPropertyName("high")]
        public float? High { get; set; }

        [JsonPropertyName("low")]
        public float? Low { get; set; }

        [JsonPropertyName("close")]
        public float? Close { get; set; }

        [JsonPropertyName("bid")]
        public float? Bid { get; set; }

        [JsonPropertyName("ask")]
        public float? Ask { get; set; }

        [JsonPropertyName("change_percentage")]
        public float? ChangePercentage { get; set; }

        [JsonPropertyName("average_volume")]
        public int AverageVolume { get; set; }

        [JsonPropertyName("last_volume")]
        public int LastVolume { get; set; }

        [JsonPropertyName("trade_date")]
        public long TradeDate { get; set; }

        [JsonPropertyName("prevclose")]
        public float? Prevclose { get; set; }

        [JsonPropertyName("week_52_high")]
        public float Week52High { get; set; }

        [JsonPropertyName("week_52_low")]
        public float Week52Low { get; set; }

        [JsonPropertyName("bidsize")]
        public int Bidsize { get; set; }

        [JsonPropertyName("bidexch")]
        public string Bidexch { get; set; }

        [JsonPropertyName("bid_date")]
        public long BidDate { get; set; }

        [JsonPropertyName("asksize")]
        public int Asksize { get; set; }

        [JsonPropertyName("askexch")]
        public string Askexch { get; set; }

        [JsonPropertyName("ask_date")]
        public long AskDate { get; set; }

        [JsonPropertyName("root_symbols")]
        public string RootSymbols { get; set; }

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        [JsonPropertyName("strike")]
        public float Strike { get; set; }

        [JsonPropertyName("open_interest")]
        public int OpenInterest { get; set; }

        [JsonPropertyName("contract_size")]
        public int ContractSize { get; set; }

        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("expiration_type")]
        public string ExpirationType { get; set; }

        [JsonPropertyName("option_type")]
        public string OptionType { get; set; }

        [JsonPropertyName("root_symbol")]
        public string RootSymbol { get; set; }
    }
}
