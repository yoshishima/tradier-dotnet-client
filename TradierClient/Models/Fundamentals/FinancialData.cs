using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tradier.Client.Models.Fundamentals
{
    public class FinancialsRootObject
    {
        /// <summary>
        /// Gets or sets the request information.
        /// </summary>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        /// Gets or sets the type of the financial data.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the list of financial results.
        /// </summary>
        [JsonPropertyName("results")]
        public List<FinancialResult> Results { get; set; }
    }

    /// <summary>
    /// Represents a financial result for a specific company.
    /// </summary>
    public class FinancialResult
    {
        /// <summary>
        /// Gets or sets the type of the financial result.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tables containing the financial data.
        /// </summary>
        [JsonPropertyName("tables")]
        public FinancialTables Tables { get; set; }
    }

    /// <summary>
    /// Represents the financial data tables for a company.
    /// </summary>
    public class FinancialTables
    {
        /// <summary>
        /// Gets or sets the annual income statements.
        /// </summary>
        [JsonPropertyName("income_annual")]
        public List<IncomeStatement> IncomeAnnual { get; set; }

        /// <summary>
        /// Gets or sets the quarterly income statements.
        /// </summary>
        [JsonPropertyName("income_quarterly")]
        public List<IncomeStatement> IncomeQuarterly { get; set; }

        /// <summary>
        /// Gets or sets the annual balance sheets.
        /// </summary>
        [JsonPropertyName("balance_annual")]
        public List<BalanceSheet> BalanceAnnual { get; set; }

        /// <summary>
        /// Gets or sets the quarterly balance sheets.
        /// </summary>
        [JsonPropertyName("balance_quarterly")]
        public List<BalanceSheet> BalanceQuarterly { get; set; }

        /// <summary>
        /// Gets or sets the annual cash flow statements.
        /// </summary>
        [JsonPropertyName("cash_annual")]
        public List<CashFlowStatement> CashAnnual { get; set; }

        /// <summary>
        /// Gets or sets the quarterly cash flow statements.
        /// </summary>
        [JsonPropertyName("cash_quarterly")]
        public List<CashFlowStatement> CashQuarterly { get; set; }
    }

    /// <summary>
    /// Represents an income statement for a company.
    /// </summary>
    public class IncomeStatement
    {
        /// <summary>
        /// Gets or sets the end date of the reporting period.
        /// </summary>
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the type of fiscal period.
        /// </summary>
        [JsonPropertyName("fiscal_period")]
        public string FiscalPeriod { get; set; }

        /// <summary>
        /// Gets or sets the fiscal year.
        /// </summary>
        [JsonPropertyName("fiscal_year")]
        public int FiscalYear { get; set; }

        /// <summary>
        /// Gets or sets the total revenue.
        /// </summary>
        [JsonPropertyName("total_revenue")]
        public decimal? TotalRevenue { get; set; }

        /// <summary>
        /// Gets or sets the cost of revenue.
        /// </summary>
        [JsonPropertyName("cost_of_revenue")]
        public decimal? CostOfRevenue { get; set; }

        /// <summary>
        /// Gets or sets the gross profit.
        /// </summary>
        [JsonPropertyName("gross_profit")]
        public decimal? GrossProfit { get; set; }

        /// <summary>
        /// Gets or sets the operating expenses.
        /// </summary>
        [JsonPropertyName("operating_expense")]
        public decimal? OperatingExpense { get; set; }

        /// <summary>
        /// Gets or sets the operating income.
        /// </summary>
        [JsonPropertyName("operating_income")]
        public decimal? OperatingIncome { get; set; }

        /// <summary>
        /// Gets or sets the net income.
        /// </summary>
        [JsonPropertyName("net_income")]
        public decimal? NetIncome { get; set; }

        /// <summary>
        /// Gets or sets the earnings per share (basic).
        /// </summary>
        [JsonPropertyName("eps_basic")]
        public decimal? EpsBasic { get; set; }

        /// <summary>
        /// Gets or sets the earnings per share (diluted).
        /// </summary>
        [JsonPropertyName("eps_diluted")]
        public decimal? EpsDiluted { get; set; }

        /// <summary>
        /// Gets or sets the weighted average shares outstanding (basic).
        /// </summary>
        [JsonPropertyName("weighted_shares_outstanding_basic")]
        public decimal? WeightedSharesOutstandingBasic { get; set; }

        /// <summary>
        /// Gets or sets the weighted average shares outstanding (diluted).
        /// </summary>
        [JsonPropertyName("weighted_shares_outstanding_diluted")]
        public decimal? WeightedSharesOutstandingDiluted { get; set; }

        /// <summary>
        /// Gets or sets the dividend per share.
        /// </summary>
        [JsonPropertyName("dividend_per_share")]
        public decimal? DividendPerShare { get; set; }

        /// <summary>
        /// Gets or sets the EBITDA.
        /// </summary>
        [JsonPropertyName("ebitda")]
        public decimal? Ebitda { get; set; }

        /// <summary>
        /// Gets or sets the EBIT.
        /// </summary>
        [JsonPropertyName("ebit")]
        public decimal? Ebit { get; set; }
    }

    /// <summary>
    /// Represents a balance sheet for a company.
    /// </summary>
    public class BalanceSheet
    {
        /// <summary>
        /// Gets or sets the end date of the reporting period.
        /// </summary>
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the type of fiscal period.
        /// </summary>
        [JsonPropertyName("fiscal_period")]
        public string FiscalPeriod { get; set; }

        /// <summary>
        /// Gets or sets the fiscal year.
        /// </summary>
        [JsonPropertyName("fiscal_year")]
        public int FiscalYear { get; set; }

        /// <summary>
        /// Gets or sets the total assets.
        /// </summary>
        [JsonPropertyName("total_assets")]
        public decimal? TotalAssets { get; set; }

        /// <summary>
        /// Gets or sets the current assets.
        /// </summary>
        [JsonPropertyName("current_assets")]
        public decimal? CurrentAssets { get; set; }

        /// <summary>
        /// Gets or sets the cash and equivalents.
        /// </summary>
        [JsonPropertyName("cash_and_equivalents")]
        public decimal? CashAndEquivalents { get; set; }

        /// <summary>
        /// Gets or sets the total liabilities.
        /// </summary>
        [JsonPropertyName("total_liabilities")]
        public decimal? TotalLiabilities { get; set; }

        /// <summary>
        /// Gets or sets the current liabilities.
        /// </summary>
        [JsonPropertyName("current_liabilities")]
        public decimal? CurrentLiabilities { get; set; }

        /// <summary>
        /// Gets or sets the long-term debt.
        /// </summary>
        [JsonPropertyName("long_term_debt")]
        public decimal? LongTermDebt { get; set; }

        /// <summary>
        /// Gets or sets the total shareholders' equity.
        /// </summary>
        [JsonPropertyName("total_shareholders_equity")]
        public decimal? TotalShareholdersEquity { get; set; }
    }

    /// <summary>
    /// Represents a cash flow statement for a company.
    /// </summary>
    public class CashFlowStatement
    {
        /// <summary>
        /// Gets or sets the end date of the reporting period.
        /// </summary>
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the type of fiscal period.
        /// </summary>
        [JsonPropertyName("fiscal_period")]
        public string FiscalPeriod { get; set; }

        /// <summary>
        /// Gets or sets the fiscal year.
        /// </summary>
        [JsonPropertyName("fiscal_year")]
        public int FiscalYear { get; set; }

        /// <summary>
        /// Gets or sets the net cash flow from operating activities.
        /// </summary>
        [JsonPropertyName("net_cash_flow_from_operating_activities")]
        public decimal? NetCashFlowFromOperatingActivities { get; set; }

        /// <summary>
        /// Gets or sets the net cash flow from investing activities.
        /// </summary>
        [JsonPropertyName("net_cash_flow_from_investing_activities")]
        public decimal? NetCashFlowFromInvestingActivities { get; set; }

        /// <summary>
        /// Gets or sets the net cash flow from financing activities.
        /// </summary>
        [JsonPropertyName("net_cash_flow_from_financing_activities")]
        public decimal? NetCashFlowFromFinancingActivities { get; set; }

        /// <summary>
        /// Gets or sets the net change in cash.
        /// </summary>
        [JsonPropertyName("net_change_in_cash")]
        public decimal? NetChangeInCash { get; set; }

        /// <summary>
        /// Gets or sets the free cash flow.
        /// </summary>
        [JsonPropertyName("free_cash_flow")]
        public decimal? FreeCashFlow { get; set; }

        /// <summary>
        /// Gets or sets the capital expenditures.
        /// </summary>
        [JsonPropertyName("capital_expenditure")]
        public decimal? CapitalExpenditure { get; set; }
    }

}
