using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    /// <summary>
    ///     Represents the root object for company statistics.
    /// </summary>
    public class StatisticsRootObject
    {
        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the results.
        /// </summary>
        [JsonPropertyName("results")]
        public List<StatisticsResult> Results { get; set; }
    }

    /// <summary>
    ///     Represents a result containing company statistics.
    /// </summary>
    public class StatisticsResult
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the tables containing statistics data.
        /// </summary>
        [JsonPropertyName("tables")]
        public StatisticsTables Tables { get; set; }
    }

    /// <summary>
    ///     Represents tables containing various statistics data.
    /// </summary>
    public class StatisticsTables
    {
        /// <summary>
        ///     Gets or sets the basic financial ratios.
        /// </summary>
        [JsonPropertyName("financial_ratios")]
        public List<FinancialRatio> FinancialRatios { get; set; }

        /// <summary>
        ///     Gets or sets the value ratios.
        /// </summary>
        [JsonPropertyName("valuation_ratios")]
        public List<ValuationRatio> ValuationRatios { get; set; }

        /// <summary>
        ///     Gets or sets the per-share statistics.
        /// </summary>
        [JsonPropertyName("per_share_data")]
        public List<PerShareData> PerShareData { get; set; }

        /// <summary>
        ///     Gets or sets the company analysis data.
        /// </summary>
        [JsonPropertyName("analyst_estimates")]
        public List<AnalystEstimate> AnalystEstimates { get; set; }
    }

    /// <summary>
    ///     Represents financial ratios for a company.
    /// </summary>
    public class FinancialRatio
    {
        /// <summary>
        ///     Gets or sets the company ID.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the as-of date.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public DateTime AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the current ratio.
        /// </summary>
        [JsonPropertyName("current_ratio")]
        public double? CurrentRatio { get; set; }

        /// <summary>
        ///     Gets or sets the quick ratio.
        /// </summary>
        [JsonPropertyName("quick_ratio")]
        public double? QuickRatio { get; set; }

        /// <summary>
        ///     Gets or sets the debt-to-equity ratio.
        /// </summary>
        [JsonPropertyName("debt_to_equity")]
        public double? DebtToEquity { get; set; }

        /// <summary>
        ///     Gets or sets the gross margin.
        /// </summary>
        [JsonPropertyName("gross_margin")]
        public double? GrossMargin { get; set; }

        /// <summary>
        ///     Gets or sets the operating margin.
        /// </summary>
        [JsonPropertyName("operating_margin")]
        public double? OperatingMargin { get; set; }

        /// <summary>
        ///     Gets or sets the profit margin.
        /// </summary>
        [JsonPropertyName("profit_margin")]
        public double? ProfitMargin { get; set; }

        /// <summary>
        ///     Gets or sets the return on assets.
        /// </summary>
        [JsonPropertyName("return_on_assets")]
        public double? ReturnOnAssets { get; set; }

        /// <summary>
        ///     Gets or sets the return on equity.
        /// </summary>
        [JsonPropertyName("return_on_equity")]
        public double? ReturnOnEquity { get; set; }

        /// <summary>
        ///     Gets or sets the return on invested capital.
        /// </summary>
        [JsonPropertyName("return_on_invested_capital")]
        public double? ReturnOnInvestedCapital { get; set; }

        /// <summary>
        ///     Gets or sets the interest coverage.
        /// </summary>
        [JsonPropertyName("interest_coverage")]
        public double? InterestCoverage { get; set; }
    }

    /// <summary>
    ///     Represents valuation ratios for a company.
    /// </summary>
    public class ValuationRatio
    {
        /// <summary>
        ///     Gets or sets the company ID.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the as-of date.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public DateTime AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the price-to-earnings ratio.
        /// </summary>
        [JsonPropertyName("price_to_earnings")]
        public double? PriceToEarnings { get; set; }

        /// <summary>
        ///     Gets or sets the price-to-book ratio.
        /// </summary>
        [JsonPropertyName("price_to_book")]
        public double? PriceToBook { get; set; }

        /// <summary>
        ///     Gets or sets the price-to-sales ratio.
        /// </summary>
        [JsonPropertyName("price_to_sales")]
        public double? PriceToSales { get; set; }

        /// <summary>
        ///     Gets or sets the price-to-cash-flow ratio.
        /// </summary>
        [JsonPropertyName("price_to_cash_flow")]
        public double? PriceToCashFlow { get; set; }

        /// <summary>
        ///     Gets or sets the price-to-free-cash-flow ratio.
        /// </summary>
        [JsonPropertyName("price_to_free_cash_flow")]
        public double? PriceToFreeCashFlow { get; set; }

        /// <summary>
        ///     Gets or sets the enterprise value to EBITDA ratio.
        /// </summary>
        [JsonPropertyName("enterprise_value_to_ebitda")]
        public double? EnterpriseValueToEbitda { get; set; }

        /// <summary>
        ///     Gets or sets the enterprise value to sales ratio.
        /// </summary>
        [JsonPropertyName("enterprise_value_to_sales")]
        public double? EnterpriseValueToSales { get; set; }
    }

    /// <summary>
    ///     Represents per-share data for a company.
    /// </summary>
    public class PerShareData
    {
        /// <summary>
        ///     Gets or sets the company ID.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the as-of date.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public DateTime AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the earnings per share.
        /// </summary>
        [JsonPropertyName("earnings_per_share")]
        public double? EarningsPerShare { get; set; }

        /// <summary>
        ///     Gets or sets the sales per share.
        /// </summary>
        [JsonPropertyName("sales_per_share")]
        public double? SalesPerShare { get; set; }

        /// <summary>
        ///     Gets or sets the book value per share.
        /// </summary>
        [JsonPropertyName("book_value_per_share")]
        public double? BookValuePerShare { get; set; }

        /// <summary>
        ///     Gets or sets the tangible book value per share.
        /// </summary>
        [JsonPropertyName("tangible_book_value_per_share")]
        public double? TangibleBookValuePerShare { get; set; }

        /// <summary>
        ///     Gets or sets the free cash flow per share.
        /// </summary>
        [JsonPropertyName("free_cash_flow_per_share")]
        public double? FreeCashFlowPerShare { get; set; }

        /// <summary>
        ///     Gets or sets the cash per share.
        /// </summary>
        [JsonPropertyName("cash_per_share")]
        public double? CashPerShare { get; set; }

        /// <summary>
        ///     Gets or sets the dividend per share.
        /// </summary>
        [JsonPropertyName("dividend_per_share")]
        public double? DividendPerShare { get; set; }

        /// <summary>
        ///     Gets or sets the dividend yield.
        /// </summary>
        [JsonPropertyName("dividend_yield")]
        public double? DividendYield { get; set; }
    }

    /// <summary>
    ///     Represents analyst estimates for a company.
    /// </summary>
    public class AnalystEstimate
    {
        /// <summary>
        ///     Gets or sets the company ID.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the as-of date.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public DateTime AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the number of analysts providing estimates.
        /// </summary>
        [JsonPropertyName("number_of_analysts")]
        public int? NumberOfAnalysts { get; set; }

        /// <summary>
        ///     Gets or sets the average target price.
        /// </summary>
        [JsonPropertyName("average_target_price")]
        public double? AverageTargetPrice { get; set; }

        /// <summary>
        ///     Gets or sets the high target price.
        /// </summary>
        [JsonPropertyName("high_target_price")]
        public double? HighTargetPrice { get; set; }

        /// <summary>
        ///     Gets or sets the low target price.
        /// </summary>
        [JsonPropertyName("low_target_price")]
        public double? LowTargetPrice { get; set; }

        /// <summary>
        ///     Gets or sets the standard deviation.
        /// </summary>
        [JsonPropertyName("standard_deviation")]
        public double? StandardDeviation { get; set; }

        /// <summary>
        ///     Gets or sets the recommendation mean.
        /// </summary>
        [JsonPropertyName("recommendation_mean")]
        public double? RecommendationMean { get; set; }

        /// <summary>
        ///     Gets or sets the strong buy recommendations.
        /// </summary>
        [JsonPropertyName("recommendation_strong_buy")]
        public int? RecommendationStrongBuy { get; set; }

        /// <summary>
        ///     Gets or sets the buy recommendations.
        /// </summary>
        [JsonPropertyName("recommendation_buy")]
        public int? RecommendationBuy { get; set; }

        /// <summary>
        ///     Gets or sets the hold recommendations.
        /// </summary>
        [JsonPropertyName("recommendation_hold")]
        public int? RecommendationHold { get; set; }

        /// <summary>
        ///     Gets or sets the sell recommendations.
        /// </summary>
        [JsonPropertyName("recommendation_sell")]
        public int? RecommendationSell { get; set; }

        /// <summary>
        ///     Gets or sets the strong sell recommendations.
        /// </summary>
        [JsonPropertyName("recommendation_strong_sell")]
        public int? RecommendationStrongSell { get; set; }
    }
}