using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{

    public class OptionChainRootobject
    {
        [JsonPropertyName("options")]
        public Options Options { get; set; }
    }

    public class Options
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(SingleOrArrayConverter<Option>))]
        public List<Option> Option { get; set; }
    }

    public class Option
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("exch")]
        public string Exchange { get; set; }

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

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        [JsonPropertyName("strike")]
        public float Strike { get; set; }

        [JsonPropertyName("change_percentage")]
        public float? ChangePercentage { get; set; }

        [JsonPropertyName("average_volume")]
        public int AverageVolume { get; set; }

        [JsonPropertyName("last_volume")]
        public int LastVolume { get; set; }

        [JsonPropertyName("trade_date")]
        [JsonConverter(typeof(MillisecondsEpochConverter))]
        public DateTime TradeDate { get; set; }

        [JsonPropertyName("prevclose")]
        public float? PreviousClose { get; set; }

        [JsonPropertyName("week_52_high")]
        public float Week52High { get; set; }

        [JsonPropertyName("week_52_low")]
        public float Week52Low { get; set; }

        [JsonPropertyName("bidsize")]
        public int BidSize { get; set; }

        [JsonPropertyName("bidexch")]
        public string BidExchange { get; set; }

        [JsonPropertyName("bid_date")]
        [JsonConverter(typeof(MillisecondsEpochConverter))]
        public DateTime BidDate { get; set; }

        [JsonPropertyName("asksize")]
        public int AskSize { get; set; }

        [JsonPropertyName("askexch")]
        public string AskExchange { get; set; }

        [JsonPropertyName("ask_date")]
        [JsonConverter(typeof(MillisecondsEpochConverter))]
        public DateTime AskDate { get; set; }

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

        [JsonPropertyName("greeks")]
        public Greeks Greeks { get; set; }

    }

    public class Greeks
    {
        [JsonPropertyName("delta")]
        public float Delta { get; set; }

        [JsonPropertyName("gamma")]
        public float Gamma { get; set; }

        [JsonPropertyName("theta")]
        public float Theta { get; set; }

        [JsonPropertyName("vega")]
        public float Vega { get; set; }

        [JsonPropertyName("rho")]
        public float Rho { get; set; }

        [JsonPropertyName("phi")]
        public float Phi { get; set; }

        [JsonPropertyName("bid_iv")]
        public float BidIV { get; set; }

        [JsonPropertyName("mid_iv")]
        public float MidIV { get; set; }

        [JsonPropertyName("ask_iv")]
        public float AskIV { get; set; }

        [JsonPropertyName("smv_vol")]
        public float SmvIV { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(ParseExactConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}