using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    /// <summary>
    /// Represents the root object for financial ratios data.
    /// </summary>
    public class RatiosRootObject
    {
        /// <summary>
        /// Gets or sets the request information.
        /// </summary>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the list of ratio results.
        /// </summary>
        [JsonPropertyName("results")]
        public List<RatioResult> Results { get; set; }
    }

    /// <summary>
    /// Represents a financial ratio result for a specific company.
    /// </summary>
    public class RatioResult
    {
        /// <summary>
        /// Gets or sets the type of the ratio result.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tables containing the ratio data.
        /// </summary>
        [JsonPropertyName("tables")]
        public RatioTables Tables { get; set; }
    }

    /// <summary>
    /// Represents the financial ratio tables for a company.
    /// </summary>
    public class RatioTables
    {
        /// <summary>
        /// Gets or sets the valuation ratios for the company.
        /// </summary>
        [JsonPropertyName("valuation_ratios")]
        public List<CompanyValuationRatio> ValuationRatios { get; set; }

        /// <summary>
        /// Gets or sets the financial strength ratios for the company.
        /// </summary>
        [JsonPropertyName("financial_strength")]
        public List<FinancialStrengthRatio> FinancialStrength { get; set; }

        /// <summary>
        /// Gets or sets the management effectiveness ratios for the company.
        /// </summary>
        [JsonPropertyName("management_effectiveness")]
        public List<ManagementEffectivenessRatio> ManagementEffectiveness { get; set; }

        /// <summary>
        /// Gets or sets the profitability ratios for the company.
        /// </summary>
        [JsonPropertyName("profitability")]
        public List<ProfitabilityRatio> Profitability { get; set; }

        /// <summary>
        /// Gets or sets the growth ratios for the company.
        /// </summary>
        [JsonPropertyName("growth")]
        public List<GrowthRatio> Growth { get; set; }

        /// <summary>
        /// Gets or sets the efficiency ratios for the company.
        /// </summary>
        [JsonPropertyName("efficiency")]
        public List<EfficiencyRatio> Efficiency { get; set; }
    }

    /// <summary>
    /// Represents valuation ratios for a company.
    /// </summary>
    public class CompanyValuationRatio
    {
        /// <summary>
        /// Gets or sets the date when the ratio was calculated.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the price-to-earnings ratio.
        /// </summary>
        [JsonPropertyName("pe_ratio")]
        public decimal? PeRatio { get; set; }

        /// <summary>
        /// Gets or sets the forward price-to-earnings ratio.
        /// </summary>
        [JsonPropertyName("forward_pe")]
        public decimal? ForwardPe { get; set; }

        /// <summary>
        /// Gets or sets the price-to-sales ratio.
        /// </summary>
        [JsonPropertyName("price_to_sales")]
        public decimal? PriceToSales { get; set; }

        /// <summary>
        /// Gets or sets the price-to-book ratio.
        /// </summary>
        [JsonPropertyName("price_to_book")]
        public decimal? PriceToBook { get; set; }

        /// <summary>
        /// Gets or sets the enterprise value to EBITDA ratio.
        /// </summary>
        [JsonPropertyName("enterprise_value_to_ebitda")]
        public decimal? EnterpriseValueToEbitda { get; set; }

        /// <summary>
        /// Gets or sets the enterprise value to revenue ratio.
        /// </summary>
        [JsonPropertyName("enterprise_value_to_revenue")]
        public decimal? EnterpriseValueToRevenue { get; set; }

        /// <summary>
        /// Gets or sets the price-to-earnings-to-growth ratio.
        /// </summary>
        [JsonPropertyName("peg_ratio")]
        public decimal? PegRatio { get; set; }

        /// <summary>
        /// Gets or sets the dividend yield.
        /// </summary>
        [JsonPropertyName("dividend_yield")]
        public decimal? DividendYield { get; set; }
    }

    /// <summary>
    /// Represents financial strength ratios for a company.
    /// </summary>
    public class FinancialStrengthRatio
    {
        /// <summary>
        /// Gets or sets the date when the ratio was calculated.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the current ratio.
        /// </summary>
        [JsonPropertyName("current_ratio")]
        public decimal? CurrentRatio { get; set; }

        /// <summary>
        /// Gets or sets the quick ratio.
        /// </summary>
        [JsonPropertyName("quick_ratio")]
        public decimal? QuickRatio { get; set; }

        /// <summary>
        /// Gets or sets the debt-to-equity ratio.
        /// </summary>
        [JsonPropertyName("debt_to_equity")]
        public decimal? DebtToEquity { get; set; }

        /// <summary>
        /// Gets or sets the interest coverage ratio.
        /// </summary>
        [JsonPropertyName("interest_coverage")]
        public decimal? InterestCoverage { get; set; }
    }

    /// <summary>
    /// Represents management effectiveness ratios for a company.
    /// </summary>
    public class ManagementEffectivenessRatio
    {
        /// <summary>
        /// Gets or sets the date when the ratio was calculated.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the return on assets.
        /// </summary>
        [JsonPropertyName("return_on_assets")]
        public decimal? ReturnOnAssets { get; set; }

        /// <summary>
        /// Gets or sets the return on equity.
        /// </summary>
        [JsonPropertyName("return_on_equity")]
        public decimal? ReturnOnEquity { get; set; }

        /// <summary>
        /// Gets or sets the return on invested capital.
        /// </summary>
        [JsonPropertyName("return_on_invested_capital")]
        public decimal? ReturnOnInvestedCapital { get; set; }
    }

    /// <summary>
    /// Represents profitability ratios for a company.
    /// </summary>
    public class ProfitabilityRatio
    {
        /// <summary>
        /// Gets or sets the date when the ratio was calculated.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the gross margin.
        /// </summary>
        [JsonPropertyName("gross_margin")]
        public decimal? GrossMargin { get; set; }

        /// <summary>
        /// Gets or sets the operating margin.
        /// </summary>
        [JsonPropertyName("operating_margin")]
        public decimal? OperatingMargin { get; set; }

        /// <summary>
        /// Gets or sets the net margin.
        /// </summary>
        [JsonPropertyName("net_margin")]
        public decimal? NetMargin { get; set; }

        /// <summary>
        /// Gets or sets the free cash flow margin.
        /// </summary>
        [JsonPropertyName("free_cash_flow_margin")]
        public decimal? FreeCashFlowMargin { get; set; }
    }

    /// <summary>
    /// Represents growth ratios for a company.
    /// </summary>
    public class GrowthRatio
    {
        /// <summary>
        /// Gets or sets the date when the ratio was calculated.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the three-year revenue growth rate.
        /// </summary>
        [JsonPropertyName("three_year_revenue_growth")]
        public decimal? ThreeYearRevenueGrowth { get; set; }

        /// <summary>
        /// Gets or sets the three-year earnings growth rate.
        /// </summary>
        [JsonPropertyName("three_year_earnings_growth")]
        public decimal? ThreeYearEarningsGrowth { get; set; }

        /// <summary>
        /// Gets or sets the three-year dividend growth rate.
        /// </summary>
        [JsonPropertyName("three_year_dividend_growth")]
        public decimal? ThreeYearDividendGrowth { get; set; }

        /// <summary>
        /// Gets or sets the five-year revenue growth rate.
        /// </summary>
        [JsonPropertyName("five_year_revenue_growth")]
        public decimal? FiveYearRevenueGrowth { get; set; }

        /// <summary>
        /// Gets or sets the five-year earnings growth rate.
        /// </summary>
        [JsonPropertyName("five_year_earnings_growth")]
        public decimal? FiveYearEarningsGrowth { get; set; }

        /// <summary>
        /// Gets or sets the five-year dividend growth rate.
        /// </summary>
        [JsonPropertyName("five_year_dividend_growth")]
        public decimal? FiveYearDividendGrowth { get; set; }
    }

    /// <summary>
    /// Represents efficiency ratios for a company.
    /// </summary>
    public class EfficiencyRatio
    {
        /// <summary>
        /// Gets or sets the date when the ratio was calculated.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the asset turnover ratio.
        /// </summary>
        [JsonPropertyName("asset_turnover")]
        public decimal? AssetTurnover { get; set; }

        /// <summary>
        /// Gets or sets the inventory turnover ratio.
        /// </summary>
        [JsonPropertyName("inventory_turnover")]
        public decimal? InventoryTurnover { get; set; }

        /// <summary>
        /// Gets or sets the receivables turnover ratio.
        /// </summary>
        [JsonPropertyName("receivables_turnover")]
        public decimal? ReceivablesTurnover { get; set; }

        /// <summary>
        /// Gets or sets the days sales outstanding.
        /// </summary>
        [JsonPropertyName("days_sales_outstanding")]
        public decimal? DaysSalesOutstanding { get; set; }

        /// <summary>
        /// Gets or sets the days inventory.
        /// </summary>
        [JsonPropertyName("days_inventory")]
        public decimal? DaysInventory { get; set; }

        /// <summary>
        /// Gets or sets the operating cycle.
        /// </summary>
        [JsonPropertyName("operating_cycle")]
        public decimal? OperatingCycle { get; set; }
    }
}