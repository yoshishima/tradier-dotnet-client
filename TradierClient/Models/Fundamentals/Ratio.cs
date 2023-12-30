#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuickType
{
    /// <summary>
    ///     Represents a root object which contains the request, type, and results information.
    /// </summary>
    public class RootObject
    {
        /// <summary>
        ///     Gets or sets the value of the Request property.
        /// </summary>
        /// <value>
        ///     A string representing the request.
        /// </value>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the array of results.
        /// </summary>
        /// <value>
        ///     An array of Result objects representing the results.
        /// </value>
        [JsonPropertyName("results")]
        public Result[] Results { get; set; }
    }

    public class Result
    {
        /// <summary>
        ///     Gets or sets the type property.
        /// </summary>
        /// <value>
        ///     The type property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the Id of the property.
        /// </summary>
        /// <value>
        ///     The Id of the property.
        /// </value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Represents the table property.
        /// </summary>
        [JsonPropertyName("tables")]
        public Tables Tables { get; set; }
    }

    /// <summary>
    ///     Represents a collection of tables containing financial ratios.
    /// </summary>
    public class Tables
    {
        /// <summary>
        ///     Gets or sets the operation ratios for restated financial data.
        /// </summary>
        /// <value>
        ///     An array of <see cref="OperationRatios" /> objects representing the operation ratios for restated financial data.
        /// </value>
        [JsonPropertyName("operation_ratios_restate")]
        public OperationRatios[] OperationRatiosRestate { get; set; }

        /// <summary>
        ///     Gets or sets the operation ratios for AOR (OperationRatiosAOR).
        /// </summary>
        /// <value>
        ///     An array of OperationRatios.
        /// </value>
        [JsonPropertyName("operation_ratios_a_o_r")]
        public OperationRatios[] OperationRatiosAOR { get; set; }

        /// <summary>
        ///     Gets or sets the earning ratios restate.
        /// </summary>
        /// <value>
        ///     The earning ratios restate.
        /// </value>
        [JsonPropertyName("earning_ratios_restate")]
        public EarningRatiosRestate EarningRatiosRestate { get; set; }

        /// <summary>
        ///     Gets or sets the Valuation Ratios property.
        /// </summary>
        /// <value>
        ///     The Valuation Ratios.
        /// </value>
        [JsonPropertyName("valuation_ratios")]
        public ValuationRatios ValuationRatios { get; set; }

        /// <summary>
        ///     Gets or sets the AlphaBeta property.
        /// </summary>
        /// <value>
        ///     The AlphaBeta property.
        /// </value>
        [JsonPropertyName("alpha_beta")]
        public AlphaBeta AlphaBeta { get; set; }
    }

    /// <summary>
    ///     Represents the AlphaBeta class.
    /// </summary>
    public class AlphaBeta
    {
        /// <summary>
        ///     Represents a property Period60M.
        /// </summary>
        [JsonPropertyName("period_60m")]
        public Period60M Period60M { get; set; }
    }

    /// <summary>
    ///     Represents a 60-minute period.
    /// </summary>
    public class Period60M
    {
        [JsonPropertyName("share_class_id")] public string ShareClassId { get; set; }

        /// <summary>
        ///     Gets or sets the date and time the property was last updated or accessed.
        /// </summary>
        /// <value>
        ///     The date and time in the form of a <see cref="DateTimeOffset" />.
        /// </value>
        [JsonPropertyName("as_of_date")]
        public DateTimeOffset AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the period.
        /// </summary>
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        ///     Gets or sets the value of the Alpha property.
        /// </summary>
        /// <value>
        ///     The value of the Alpha property.
        /// </value>
        [JsonPropertyName("alpha")]
        public double Alpha { get; set; }

        /// <summary>
        ///     Gets or sets the beta property.
        /// </summary>
        /// <value>
        ///     The beta value.
        /// </value>
        [JsonPropertyName("beta")]
        public double Beta { get; set; }
    }

    /// <summary>
    ///     Represents the restated earning ratios for a specific period.
    /// </summary>
    public class EarningRatiosRestate
    {
        /// <summary>
        ///     Gets or sets the earning ratios restate period 3M.
        /// </summary>
        [JsonPropertyName("period_3m")]
        public EarningRatiosRestatePeriod3M Period3M { get; set; }
    }

    /// <summary>
    ///     Represents the financial earning ratios for a restated period of 3 months.
    /// </summary>
    public class EarningRatiosRestatePeriod3M
    {
        /// <summary>
        ///     Gets or sets the share class ID.
        /// </summary>
        /// <value>
        ///     The share class ID.
        /// </value>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// Gets or sets the as of date.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public DateTimeOffset AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the fiscal year end.
        /// </summary>
        /// <value>
        ///     The fiscal year end.
        /// </value>
        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        /// <summary>
        ///     Gets or sets the period value.
        /// </summary>
        /// <value>
        ///     The period value.
        /// </value>
        /// /
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        ///     Gets or sets the report type.
        /// </summary>
        /// <value>
        ///     The report type.
        /// </value>
        [JsonPropertyName("report_type")]
        public string ReportType { get; set; }

        /// <summary>
        ///     Gets or sets the book value per share growth.
        /// </summary>
        [JsonPropertyName("book_value_per_share_growth")]
        public double BookValuePerShareGrowth { get; set; }

        /// <summary>
        ///     Gets or sets the equity per share growth.
        /// </summary>
        /// <value>
        ///     The equity per share growth.
        /// </value>
        [JsonPropertyName("equity_per_share_growth")]
        public double EquityPerShareGrowth { get; set; }
    }

    /// <summary>
    ///     Class representing the ratios for a specific operation.
    /// </summary>
    public class OperationRatios
    {
        /// <summary>
        ///     Gets or sets the operation ratios AOR period for 3 months.
        /// </summary>
        /// <remarks>
        ///     This property represents the operation ratios AOR period for 3 months.
        ///     It is decorated with the <see cref="JsonIgnoreAttribute" /> and <see cref="JsonPropertyNameAttribute" /> attributes
        ///     to control JSON serialization.
        ///     When the value is null, it will be skipped during JSON serialization.
        /// </remarks>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_3m")]
        public OperationRatiosAORPeriod3M Period3M { get; set; }

        /// <summary>
        ///     Gets or sets the value for the property "Period9M".
        /// </summary>
        /// <remarks>
        ///     This property is decorated with the [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] attribute,
        ///     which specifies that the property should be ignored (not serialized) when its value is null.
        ///     Additionally, the property is decorated with the [JsonPropertyName("period_9m")] attribute,
        ///     which specifies the custom JSON property name when serialized/deserialized.
        /// </remarks>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_9m")]
        public Period9M Period9M { get; set; }

        /// Specifies the property representing the period of 1 year.
        /// This property is decorated with the [JsonIgnore] and [JsonPropertyName] attributes.
        /// It is used to serialize and deserialize the "period_1y" JSON property.
        /// /
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_1y")]
        public Period1Y Period1Y { get; set; }
    }

    /// <summary>
    ///     Represents a period of 1 year for financial analysis.
    /// </summary>
    public class Period1Y
    {
        /// <summary>
        ///     Represents the Company ID property.
        /// </summary>
        /// <value>
        ///     The unique identifier for the company.
        /// </value>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the date and time representing the "As of" date.
        /// </summary>
        /// <value>
        ///     The date and time representing the "As of" date.
        /// </value>
        [JsonPropertyName("as_of_date")]
        public DateTimeOffset AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the fiscal year end for the property.
        /// </summary>
        /// <value>
        ///     The fiscal year end as a Unix timestamp represented as a long.
        /// </value>
        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        /// <summary>
        ///     Gets or sets the period property.
        /// </summary>
        /// <value>
        ///     The value of the period property.
        /// </value>
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        ///     Gets or sets the report type.
        /// </summary>
        /// <value>
        ///     The report type.
        /// </value>
        [JsonPropertyName("report_type")]
        public string ReportType { get; set; }

        /// <summary>
        ///     Gets or sets the assets turnover.
        /// </summary>
        /// <value>
        ///     The assets turnover.
        /// </value>
        [JsonPropertyName("assets_turnover")]
        public double AssetsTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the CapEx to Sales Ratio.
        /// </summary>
        /// <value>
        ///     The CapEx to Sales Ratio as a double value.
        /// </value>
        [JsonPropertyName("cap_ex_sales_ratio")]
        public double CapExSalesRatio { get; set; }

        /// <summary>
        ///     Gets or sets the cash conversion cycle.
        /// </summary>
        /// <value>
        ///     The cash conversion cycle.
        /// </value>
        [JsonPropertyName("cash_conversion_cycle")]
        public double CashConversionCycle { get; set; }

        /// <summary>
        ///     Gets or sets the number of days the inventory is expected to last.
        /// </summary>
        /// <value>
        ///     The number of days in inventory.
        /// </value>
        [JsonPropertyName("days_in_inventory")]
        public double DaysInInventory { get; set; }

        /// <summary>
        ///     Gets or sets the number of days it takes for a payment to be processed.
        /// </summary>
        /// <value>
        ///     The number of days in payment.
        /// </value>
        /// <remarks>
        ///     This property is used to specify the average number of days it takes for a payment to be processed.
        ///     A higher value indicates a longer processing time, while a lower value indicates a shorter processing time.
        /// </remarks>
        [JsonPropertyName("days_in_payment")]
        public double DaysInPayment { get; set; }

        /// The number of days the asset has been in sales.
        /// /
        [JsonPropertyName("days_in_sales")]
        public double DaysInSales { get; set; }

        /// <summary>
        ///     Gets or sets the EBITDA margin property.
        /// </summary>
        /// <value>The EBITDA margin as a double.</value>
        [JsonPropertyName("e_b_i_t_d_a_margin")]
        public double EBITDAMargin { get; set; }

        /// <summary>
        ///     Gets or sets the EBIT (Earnings Before Interest and Taxes) Margin.
        /// </summary>
        /// <value>
        ///     The EBIT Margin.
        /// </value>
        [JsonPropertyName("e_b_i_t_margin")]
        public double EBITMargin { get; set; }

        /// <summary>
        ///     Gets or sets the FixAssetsTuronver property.
        /// </summary>
        /// <value>
        ///     The FixAssetsTuronver.
        /// </value>
        [JsonPropertyName("fix_assets_turonver")]
        public double FixAssetsTuronver { get; set; }

        /// <summary>
        ///     Gets or sets the gross margin.
        /// </summary>
        /// <value>
        ///     The gross margin.
        /// </value>
        [JsonPropertyName("gross_margin")]
        public double GrossMargin { get; set; }

        /// <summary>
        ///     Gets or sets the value of the InterestCoverage property.
        /// </summary>
        /// <remarks>
        ///     The interest coverage ratio is a financial metric that measures a company's ability to pay its interest expenses.
        ///     It is calculated by dividing a company's earnings before interest and taxes (EBIT) by its interest expenses.
        ///     A higher interest coverage ratio indicates a company's strong ability to meet its interest obligations.
        /// </remarks>
        /// <value>
        ///     The interest coverage ratio as a double value.
        /// </value>
        [JsonPropertyName("interest_coverage")]
        public double InterestCoverage { get; set; }

        /// <summary>
        ///     Gets or sets the inventory turnover.
        /// </summary>
        [JsonPropertyName("inventory_turnover")]
        public double InventoryTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the net margin.
        /// </summary>
        /// <value>
        ///     The net margin.
        /// </value>
        [JsonPropertyName("net_margin")]
        public double NetMargin { get; set; }

        /// <summary>
        ///     Gets or sets the normalized net profit margin.
        /// </summary>
        /// <value>
        ///     The normalized net profit margin.
        /// </value>
        [JsonPropertyName("normalized_net_profit_margin")]
        public double NormalizedNetProfitMargin { get; set; }

        /// <summary>
        ///     Gets or sets the normalized ROIC (Return on Invested Capital) value.
        /// </summary>
        /// <remarks>
        ///     This property represents the normalized ROIC value.
        /// </remarks>
        [JsonPropertyName("normalized_r_o_i_c")]
        public double NormalizedROIC { get; set; }

        /// <summary>
        ///     Gets or sets the operation margin.
        /// </summary>
        /// <value>
        ///     The operation margin.
        /// </value>
        [JsonPropertyName("operation_margin")]
        public double OperationMargin { get; set; }

        /// <summary>
        ///     Gets or sets the payment turnover value.
        /// </summary>
        /// <value>The payment turnover value.</value>
        [JsonPropertyName("payment_turnover")]
        public double PaymentTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the pretax margin.
        /// </summary>
        /// <value>
        ///     The pretax margin.
        /// </value>
        [JsonPropertyName("pretax_margin")]
        public double PretaxMargin { get; set; }

        /// <summary>
        ///     Represents the receivable turnover property.
        /// </summary>
        /// <value>
        ///     The receivable turnover.
        /// </value>
        [JsonPropertyName("receivable_turnover")]
        public double ReceivableTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the Return on Assets (ROA).
        /// </summary>
        [JsonPropertyName("r_o_a")]
        public double ROA { get; set; }

        /// <summary>
        ///     Gets or sets the Return on Equity (ROE) value.
        /// </summary>
        /// <remarks>
        ///     This property represents the Return on Equity (ROE) which is a measure of a company's profitability that evaluates
        ///     how well a company is using its shareholders' equity to generate
        ///     profit.
        ///     It is expressed as a percentage and is calculated by dividing the net income by the shareholders' equity.
        /// </remarks>
        [JsonPropertyName("r_o_e")]
        public double ROE { get; set; }

        /// <summary>
        ///     Represents the Return on Invested Capital (ROIC) property.
        /// </summary>
        /// <remarks>
        ///     ROIC is a financial metric that measures a company's profitability and the efficiency with which it uses its
        ///     capital.
        ///     It is calculated as the company's net operating profit after taxes (NOPAT) divided by its total invested capital.
        /// </remarks>
        [JsonPropertyName("r_o_i_c")]
        public double ROIC { get; set; }

        /// <summary>
        ///     Gets or sets the sales per employee.
        /// </summary>
        /// <value>
        ///     The sales per employee.
        /// </value>
        [JsonPropertyName("sales_per_employee")]
        public double SalesPerEmployee { get; set; }

        /// <summary>
        ///     Gets or sets the working capital turnover ratio.
        /// </summary>
        /// <remarks>
        ///     The working capital turnover ratio is a measure of how efficiently a company is utilizing its working capital to
        ///     generate revenue.
        /// </remarks>
        /// <value>
        ///     The working capital turnover ratio.
        /// </value>
        [JsonPropertyName("working_capital_turnover_ratio")]
        public double WorkingCapitalTurnoverRatio { get; set; }
    }

    /// <summary>
    ///     Represents the financial ratios for a company for a specific period.
    /// </summary>
    public class OperationRatiosAORPeriod3M
    {
        /// <summary>
        ///     Gets or sets the CompanyId.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the as of date.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public DateTimeOffset AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the fiscal year end.
        /// </summary>
        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        /// <summary>
        ///     Gets or sets the period value.
        /// </summary>
        /// <value>
        ///     The period value.
        /// </value>
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        ///     Gets or sets the report type.
        /// </summary>
        /// <value>
        ///     The report type.
        /// </value>
        [JsonPropertyName("report_type")]
        public string ReportType { get; set; }

        /// <summary>
        ///     Gets or sets the assets turnover of the property.
        /// </summary>
        /// <value>The assets turnover.</value>
        /// <remarks>
        ///     The assets turnover measures how effectively a company is utilizing its assets to generate revenue.
        ///     It is calculated by dividing the net sales by the average total assets.
        ///     A higher assets turnover indicates higher efficiency in generating sales from the assets.
        ///     On the other hand, a lower assets turnover may suggest inefficiency in asset utilization.
        /// </remarks>
        [JsonPropertyName("assets_turnover")]
        public double AssetsTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the cash conversion cycle.
        /// </summary>
        /// <remarks>
        ///     The cash conversion cycle (CCC) is a financial metric that represents the time it takes for a company to convert
        ///     its investments in inventory and other resources into cash flows
        ///     from sales.
        ///     It measures the number of days it takes for a company to convert its inventory into sales and for those sales to
        ///     turn into cash flows.
        ///     A lower CCC is generally considered favorable, as it indicates that the company is able to convert its resources
        ///     into cash quickly.
        /// </remarks>
        [JsonPropertyName("cash_conversion_cycle")]
        public double CashConversionCycle { get; set; }

        /// <summary>
        ///     Gets or sets the cash ratio.
        /// </summary>
        /// <value>
        ///     The cash ratio.
        /// </value>
        [JsonPropertyName("cash_ratio")]
        public double CashRatio { get; set; }

        /// <summary>
        ///     Gets or sets the cash to total assets ratio.
        /// </summary>
        /// <value>The cash to total assets ratio.</value>
        [JsonPropertyName("cashto_total_assets")]
        public double CashtoTotalAssets { get; set; }

        /// <summary>
        ///     Gets or sets the common equity to assets ratio.
        /// </summary>
        /// <value>
        ///     The common equity to assets ratio.
        /// </value>
        [JsonPropertyName("common_equity_to_assets")]
        public double CommonEquityToAssets { get; set; }

        /// <summary>
        ///     Gets or sets the current ratio.
        /// </summary>
        [JsonPropertyName("current_ratio")]
        public double CurrentRatio { get; set; }

        /// <summary>
        ///     Gets or sets the number of days the inventory is held by the business.
        /// </summary>
        /// <value>
        ///     The number of days the inventory is held by the business.
        /// </value>
        [JsonPropertyName("days_in_inventory")]
        public double DaysInInventory { get; set; }

        /// <summary>
        ///     Gets or sets the number of days in payment.
        /// </summary>
        /// <value>
        ///     The number of days in payment.
        /// </value>
        [JsonPropertyName("days_in_payment")]
        public double DaysInPayment { get; set; }

        /// <summary>
        ///     Gets or sets the number of days in sales.
        /// </summary>
        /// <value>
        ///     The number of days in sales.
        /// </value>
        [JsonPropertyName("days_in_sales")]
        public double DaysInSales { get; set; }

        /// <summary>
        ///     Gets or sets the Debt to Assets ratio.
        /// </summary>
        /// <value>
        ///     The Debt to Assets ratio.
        /// </value>
        [JsonPropertyName("debtto_assets")]
        public double DebttoAssets { get; set; }

        /// <summary>
        ///     Gets or sets the EBITDA margin.
        /// </summary>
        /// <value>
        ///     The EBITDA margin.
        /// </value>
        [JsonPropertyName("e_b_i_t_d_a_margin")]
        public double EBITDAMargin { get; set; }

        /// <summary>
        ///     Gets or sets the EBIT (Earnings Before Interest and Taxes) margin.
        /// </summary>
        /// <value>
        ///     The EBIT margin as a percentage.
        /// </value>
        [JsonPropertyName("e_b_i_t_margin")]
        public double EBITMargin { get; set; }

        /// Gets or sets the financial leverage.
        /// </summary>
        [JsonPropertyName("financial_leverage")]
        public double FinancialLeverage { get; set; }

        /// <summary>
        ///     Gets or sets the fix_assets_turonver property.
        /// </summary>
        /// <remarks>
        ///     The fix_assets_turonver property represents the turnover of fixed assets.
        /// </remarks>
        /// <value>
        ///     The turnover of fixed assets.
        /// </value>
        [JsonPropertyName("fix_assets_turonver")]
        public double FixAssetsTuronver { get; set; }

        /// <summary>
        ///     Gets or sets the gross margin.
        /// </summary>
        [JsonPropertyName("gross_margin")]
        public double GrossMargin { get; set; }

        /// <summary>
        ///     Represents the interest coverage property.
        /// </summary>
        /// <remarks>
        ///     The interest coverage measures a company's ability to pay its interest obligations on its outstanding debt.
        ///     A higher interest coverage ratio indicates a greater ability to meet interest payments.
        /// </remarks>
        /// <value>
        ///     The interest coverage value.
        /// </value>
        [JsonPropertyName("interest_coverage")]
        public double InterestCoverage { get; set; }

        /// <summary>
        ///     Gets or sets the inventory turnover.
        /// </summary>
        /// <value>
        ///     The inventory turnover.
        /// </value>
        [JsonPropertyName("inventory_turnover")]
        public double InventoryTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the long-term debt to equity ratio.
        /// </summary>
        /// <value>
        ///     The long-term debt to equity ratio.
        /// </value>
        [JsonPropertyName("long_term_debt_equity_ratio")]
        public double LongTermDebtEquityRatio { get; set; }

        /// <summary>
        ///     Gets or sets the long-term debt to total capital ratio.
        /// </summary>
        /// <value>
        ///     The long-term debt to total capital ratio.
        /// </value>
        [JsonPropertyName("long_term_debt_total_capital_ratio")]
        public double LongTermDebtTotalCapitalRatio { get; set; }

        /// <summary>
        ///     Gets or sets the net margin of the property.
        /// </summary>
        /// <value>
        ///     The net margin value.
        /// </value>
        [JsonPropertyName("net_margin")]
        public double NetMargin { get; set; }

        /// <summary>
        ///     Gets or sets the normalized net profit margin.
        /// </summary>
        /// <value>
        ///     The normalized net profit margin.
        /// </value>
        [JsonPropertyName("normalized_net_profit_margin")]
        public double NormalizedNetProfitMargin { get; set; }

        /// <summary>
        ///     Gets or sets the Normalized Return on Invested Capital (ROIC).
        /// </summary>
        /// <value>
        ///     The value of the normalized ROIC.
        /// </value>
        [JsonPropertyName("normalized_r_o_i_c")]
        public double NormalizedROIC { get; set; }

        /// <summary>
        ///     Gets or sets the operation margin.
        /// </summary>
        [JsonPropertyName("operation_margin")]
        public double OperationMargin { get; set; }

        /// <summary>
        ///     Gets or sets the three-month average operation revenue growth.
        /// </summary>
        /// <value>
        ///     The three-month average operation revenue growth.
        /// </value>
        [JsonPropertyName("operation_revenue_growth3_month_avg")]
        public double OperationRevenueGrowth3MonthAvg { get; set; }

        /// <summary>
        ///     Gets or sets the payment turnover.
        /// </summary>
        [JsonPropertyName("payment_turnover")]
        public double PaymentTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the PretaxMargin property.
        /// </summary>
        /// <value>
        ///     The PretaxMargin property represents the pretax margin.
        /// </value>
        [JsonPropertyName("pretax_margin")]
        public double PretaxMargin { get; set; }

        /// <summary>
        ///     Gets or sets the quick ratio of an object.
        /// </summary>
        /// <value>
        ///     The quick ratio is a financial metric that measures a company's ability to pay off its current liabilities with its
        ///     most liquid assets.
        /// </value>
        /// <remarks>
        ///     This property is mapped to the JSON property "quick_ratio".
        /// </remarks>
        /// <seealso cref="JsonPropertyNameAttribute" />
        /// <example>
        ///     This example demonstrates how to access and set the QuickRatio property.
        ///     <code>
        /// // Create an object
        /// MyObject obj = new MyObject();
        /// // Get the current quick ratio
        /// double ratio = obj.QuickRatio;
        /// // Set the quick ratio
        /// obj.QuickRatio = 1.5; </code>
        /// </example>
        /// /
        [JsonPropertyName("quick_ratio")]
        public double QuickRatio { get; set; }

        /// <summary>
        ///     Gets or sets the receivable turnover of a property.
        /// </summary>
        /// <value>
        ///     The receivable turnover value.
        /// </value>
        [JsonPropertyName("receivable_turnover")]
        public double ReceivableTurnover { get; set; }

        /// <summary>
        ///     Gets or sets the revenue growth for a property.
        /// </summary>
        /// <value>
        ///     The revenue growth.
        /// </value>
        [JsonPropertyName("revenue_growth")]
        public double RevenueGrowth { get; set; }

        /// <summary>
        ///     Gets or sets the Return on Assets (ROA).
        /// </summary>
        [JsonPropertyName("r_o_a")]
        public double ROA { get; set; }

        /// <summary>
        ///     Gets or sets the Return on Equity (ROE) value.
        /// </summary>
        [JsonPropertyName("r_o_e")]
        public double ROE { get; set; }

        /// <summary>
        ///     Gets or sets the ROIC (Return on Invested Capital) property.
        /// </summary>
        [JsonPropertyName("r_o_i_c")]
        public double ROIC { get; set; }

        /// <summary>
        ///     Gets or sets the sales per employee.
        /// </summary>
        /// <value>
        ///     The sales per employee.
        /// </value>
        [JsonPropertyName("sales_per_employee")]
        public double SalesPerEmployee { get; set; }

        /// <summary>
        ///     Represents the total debt-to-equity ratio.
        /// </summary>
        /// <value>
        ///     The total debt-to-equity ratio.
        /// </value>
        [JsonPropertyName("total_debt_equity_ratio")]
        public double TotalDebtEquityRatio { get; set; }

        /// <summary>
        ///     Represents the working capital turnover ratio.
        /// </summary>
        /// <value>
        ///     The working capital turnover ratio.
        /// </value>
        [JsonPropertyName("working_capital_turnover_ratio")]
        public double WorkingCapitalTurnoverRatio { get; set; }
    }

    /// <summary>
    ///     Represents a financial period for a company.
    /// </summary>
    public class Period9M
    {
        /// <summary>
        ///     Gets or sets the company ID.
        /// </summary>
        /// <value>
        ///     The company ID.
        /// </value>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the AsOfDate.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public DateTimeOffset AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the fiscal year end.
        /// </summary>
        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        /// <summary>
        ///     Gets or sets the period property.
        /// </summary>
        /// <value>
        ///     The period.
        /// </value>
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        ///     Gets or sets the report type.
        /// </summary>
        /// <value>
        ///     The report type.
        /// </value>
        [JsonPropertyName("report_type")]
        public string ReportType { get; set; }

        /// <summary>
        ///     Gets or sets the EBITDA margin.
        /// </summary>
        /// <value>
        ///     The EBITDA margin.
        /// </value>
        [JsonPropertyName("e_b_i_t_d_a_margin")]
        public double EBITDAMargin { get; set; }

        /// <summary>
        ///     Gets or sets the EBIT Margin property.
        /// </summary>
        /// <value>The EBIT Margin as a double value.</value>
        /// /
        [JsonPropertyName("e_b_i_t_margin")]
        public double EBITMargin { get; set; }

        /// <summary>
        ///     Gets or sets the gross margin.
        /// </summary>
        /// <value>
        ///     The gross margin.
        /// </value>
        [JsonPropertyName("gross_margin")]
        public double GrossMargin { get; set; }

        /// <summary>
        ///     The interest coverage property represents the ratio of a company's earnings before interest and taxes (EBIT) to its
        ///     interest expense.
        /// </summary>
        /// <value>
        ///     The interest coverage ratio as a double value.
        /// </value>
        [JsonPropertyName("interest_coverage")]
        public double InterestCoverage { get; set; }

        /// <summary>
        ///     Represents the net margin property.
        /// </summary>
        /// <remarks>
        ///     The net margin is a financial metric that represents the percentage of net profit a company generates from its
        ///     revenue. It is calculated by dividing the net profit by the revenue
        ///     and multiplying it by 100.
        /// </remarks>
        /// <value>
        ///     The net margin as a double value.
        /// </value>
        [JsonPropertyName("net_margin")]
        public double NetMargin { get; set; }

        /// <summary>
        ///     Gets or sets the normalized net profit margin.
        /// </summary>
        /// <value>
        ///     A <see cref="System.Double" /> representing the normalized net profit margin.
        /// </value>
        [JsonPropertyName("normalized_net_profit_margin")]
        public double NormalizedNetProfitMargin { get; set; }

        /// <summary>
        ///     Represents the operation margin property of a class.
        /// </summary>
        [JsonPropertyName("operation_margin")]
        public double OperationMargin { get; set; }

        /// <summary>
        ///     Gets or sets the pretax margin.
        /// </summary>
        /// <value>
        ///     The pretax margin.
        /// </value>
        [JsonPropertyName("pretax_margin")]
        public double PretaxMargin { get; set; }

        /// <summary>
        ///     Gets or sets the sales per employee.
        /// </summary>
        [JsonPropertyName("sales_per_employee")]
        public double SalesPerEmployee { get; set; }

        /// <summary>
        ///     Gets or sets the average 3-month operation revenue growth.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("operation_revenue_growth3_month_avg")]
        public double? OperationRevenueGrowth3MonthAvg { get; set; }

        /// <summary>
        ///     Gets or sets the revenue growth.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("revenue_growth")]
        public double? RevenueGrowth { get; set; }
    }

    /// <summary>
    ///     Represents a class for storing valuation ratios.
    /// </summary>
    public class ValuationRatios
    {
        /// <summary>
        ///     Gets or sets the share class ID.
        /// </summary>
        /// <value>
        ///     The share class ID.
        /// </value>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the estimated EPS growth in the first year.
        /// </summary>
        /// <value>
        ///     The estimated EPS growth in the first year.
        /// </value>
        /// <remarks>
        ///     This property is mapped to the JSON property "1st_year_estimated_e_p_s_growth".
        /// </remarks>
        [JsonPropertyName("1st_year_estimated_e_p_s_growth")]
        public double The1StYearEstimatedEPSGrowth { get; set; }

        /// <summary>
        ///     Gets or sets the 2nd year estimated EPS growth.
        /// </summary>
        /// <value>
        ///     The 2nd year estimated EPS growth.
        /// </value>
        [JsonPropertyName("2nd_year_estimated_e_p_s_growth")]
        public double The2NdYearEstimatedEPSGrowth { get; set; }

        /// <summary>
        ///     Gets or sets the 2 years forward earning yield.
        /// </summary>
        /// <value>
        ///     The 2 years forward earning yield.
        /// </value>
        [JsonPropertyName("2_years_forward_earning_yield")]
        public double The2_YearsForwardEarningYield { get; set; }

        /// <summary>
        ///     Gets or sets the value of the 2 Year Enterprise Value to Forward EBIT property.
        /// </summary>
        /// <value>The value of the 2 Year Enterprise Value to Forward EBIT.</value>
        [JsonPropertyName("2_yrs_e_v_to_forward_e_b_i_t")]
        public double The2_YrsEVToForwardEBIT { get; set; }

        /// <summary>
        ///     Gets or sets the value of The2_YrsEVToForwardEBITDA.
        /// </summary>
        /// <value>
        ///     The value of The2_YrsEVToForwardEBITDA.
        /// </value>
        /// <remarks>
        ///     The 2-year enterprise value (EV) to forward EBITDA ratio.
        /// </remarks>
        [JsonPropertyName("2_yrs_e_v_to_forward_e_b_i_t_d_a")]
        public double The2_YrsEVToForwardEBITDA { get; set; }

        /// <summary>
        ///     Gets or sets the book value per share.
        /// </summary>
        /// <value>
        ///     The book value per share.
        /// </value>
        [JsonPropertyName("book_value_per_share")]
        public double BookValuePerShare { get; set; }

        /// <summary>
        ///     Gets or sets the book value yield of a property.
        /// </summary>
        /// <value>
        ///     The book value yield as a double.
        /// </value>
        [JsonPropertyName("book_value_yield")]
        public double BookValueYield { get; set; }

        /// <summary>
        ///     Gets or sets the cash return.
        /// </summary>
        /// <value>
        ///     The cash return.
        /// </value>
        [JsonPropertyName("cash_return")]
        public double CashReturn { get; set; }

        /// <summary>
        ///     Gets or sets the CFOPerShare property.
        /// </summary>
        /// <value>
        ///     The CFOPerShare.
        /// </value>
        [JsonPropertyName("c_f_o_per_share")]
        public double CFOPerShare { get; set; }

        /// <summary>
        ///     Represents the CFYield property.
        /// </summary>
        /// <value>
        ///     The CFYield value.
        /// </value>
        [JsonPropertyName("c_f_yield")]
        public double CFYield { get; set; }

        /// <summary>
        ///     Gets or sets the earning yield property.
        /// </summary>
        /// <value>
        ///     The earning yield.
        /// </value>
        [JsonPropertyName("earning_yield")]
        public double EarningYield { get; set; }

        /// <summary>
        ///     Gets or sets the EVToForwardEBIT property.
        /// </summary>
        /// <value>
        ///     The EVToForwardEBIT value.
        /// </value>
        [JsonPropertyName("e_v_to_forward_e_b_i_t")]
        public double EVToForwardEBIT { get; set; }

        /// <summary>
        ///     Gets or sets the EV to Forward EBITDA ratio.
        /// </summary>
        /// <value>
        ///     The EV to Forward EBITDA ratio.
        /// </value>
        [JsonPropertyName("e_v_to_forward_e_b_i_t_d_a")]
        public double EVToForwardEBITDA { get; set; }

        /// <summary>
        ///     Gets or sets the EV To Forward Revenue property.
        /// </summary>
        /// <value>
        ///     The EV To Forward Revenue.
        /// </value>
        [JsonPropertyName("e_v_to_forward_revenue")]
        public double EVToForwardRevenue { get; set; }

        /// <summary>
        ///     Gets or sets the EV to Revenue value of an object.
        /// </summary>
        /// <value>
        ///     The EV to Revenue value of an object.
        /// </value>
        [JsonPropertyName("e_vto_revenue")]
        public double EVtoRevenue { get; set; }

        /// <summary>
        ///     Gets or sets the EV-to-TotalAssets ratio.
        /// </summary>
        /// <value>
        ///     The EV-to-TotalAssets ratio.
        /// </value>
        [JsonPropertyName("e_vto_total_assets")]
        public double EVtoTotalAssets { get; set; }

        /// <summary>
        ///     Gets or sets the free cash flow per share.
        /// </summary>
        /// <value>
        ///     The free cash flow per share.
        /// </value>
        [JsonPropertyName("f_c_f_per_share")]
        public double FCFPerShare { get; set; }

        /// <summary>
        ///     Gets or sets the Free Cash Flow Yield (FCFYield).
        /// </summary>
        /// <value>
        ///     The Free Cash Flow Yield (FCFYield).
        /// </value>
        [JsonPropertyName("f_c_f_yield")]
        public double FCFYield { get; set; }

        /// <summary>
        ///     Gets or sets the forward earning yield property.
        /// </summary>
        /// <value>
        ///     The forward earning yield.
        /// </value>
        [JsonPropertyName("forward_earning_yield")]
        public double ForwardEarningYield { get; set; }

        /// <summary>
        ///     Gets or sets the Payout Ratio.
        /// </summary>
        /// <value>
        ///     The Payout Ratio.
        /// </value>
        [JsonPropertyName("payout_ratio")]
        public long PayoutRatio { get; set; }

        /// <summary>
        ///     Gets or sets the P/B ratio.
        /// </summary>
        /// <value>
        ///     The P/B ratio.
        /// </value>
        [JsonPropertyName("p_b_ratio")]
        public double PBRatio { get; set; }

        /// <summary>
        ///     Gets or sets the PB Ratio 1 Year Growth property.
        /// </summary>
        /// <value>
        ///     The PB Ratio 1 Year Growth value.
        /// </value>
        [JsonPropertyName("p_b_ratio1_year_growth")]
        public double PBRatio1YearGrowth { get; set; }

        /// <summary>
        ///     Gets or sets the P/B ratio 3-year average.
        /// </summary>
        /// <value>
        ///     The P/B ratio 3-year average.
        /// </value>
        [JsonPropertyName("p_b_ratio3_yr_avg")]
        public double PBRatio3YrAvg { get; set; }

        /// The average cash ratio over a period of three years.
        /// <value>
        ///     A double representing the average cash ratio over a period of three years.
        /// </value>
        [JsonPropertyName("p_cash_ratio3_yr_avg")]
        public double PCashRatio3YrAvg { get; set; }

        /// <summary>
        ///     Gets or sets the price change value in the last 1 month.
        /// </summary>
        /// <value>
        ///     The price change value in the last 1 month.
        /// </value>
        [JsonPropertyName("price_change1_m")]
        public double PriceChange1M { get; set; }

        /// <summary>
        ///     Gets or sets the price-to-cash ratio of the property.
        /// </summary>
        /// <value>
        ///     The price-to-cash ratio.
        /// </value>
        [JsonPropertyName("priceto_cash_ratio")]
        public double PricetoCashRatio { get; set; }

        /// <summary>
        ///     Gets or sets the PS ratio.
        /// </summary>
        /// <remarks>
        ///     This property represents the P/S ratio, also known as the price-to-sales ratio. It is used to evaluate the
        ///     valuation of a company by comparing its market capitalization to the revenue
        ///     generated.
        /// </remarks>
        [JsonPropertyName("p_s_ratio")]
        public double PSRatio { get; set; }

        /// <summary>
        ///     Gets or sets the PS Ratio 1 Year Growth property.
        /// </summary>
        /// <value>
        ///     The PS Ratio 1 Year Growth.
        /// </value>
        [JsonPropertyName("p_s_ratio1_year_growth")]
        public double PSRatio1YearGrowth { get; set; }

        /// <summary>
        ///     Gets or sets the average PS ratio over a 3-year period.
        /// </summary>
        /// <value>
        ///     The average PS ratio over a 3-year period.
        /// </value>
        [JsonPropertyName("p_s_ratio3_yr_avg")]
        public double PSRatio3YrAvg { get; set; }

        [JsonPropertyName("sales_per_share")] public double SalesPerShare { get; set; }

        [JsonPropertyName("sales_yield")] public double SalesYield { get; set; }

        [JsonPropertyName("sustainable_growth_rate")]
        public double SustainableGrowthRate { get; set; }

        [JsonPropertyName("tangible_book_value_per_share")]
        public double TangibleBookValuePerShare { get; set; }

        /// <summary>
        ///     Gets or sets the 3-year average tangible book value per share.
        /// </summary>
        /// <value>
        ///     The 3-year average tangible book value per share.
        /// </value>
        [JsonPropertyName("tangible_b_v_per_share3_yr_avg")]
        public double TangibleBVPerShare3YrAvg { get; set; }

        [JsonPropertyName("total_asset_per_share")]
        public double TotalAssetPerShare { get; set; }

        [JsonPropertyName("working_capital_per_share")]
        public double WorkingCapitalPerShare { get; set; }

        /// <summary>
        ///     Gets or sets the average working capital per share over a period of three years.
        /// </summary>
        /// <value>
        ///     The working capital per share for the specified period.
        /// </value>
        [JsonPropertyName("working_capital_per_share3_yr_avg")]
        public double WorkingCapitalPerShare3YrAvg { get; set; }
    }

    /// <summary>
    ///     Represents the Temperatures class which provides methods for working with temperature data.
    /// </summary>
    public class Temperatures
    {
        /// <summary>
        ///     Deserializes a JSON string into an array of Temperatures objects.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>An array of Temperatures objects.</returns>
        public static Temperatures[] FromJson(string json)
        {
            return JsonSerializer.Deserialize<Temperatures[]>(json, Converter.Settings);
        }
    }

    /// <summary>
    ///     The Serialize class provides methods for serializing objects to JSON.
    /// </summary>
    public static class Serialize
    {
        /// <summary>
        ///     Converts an array of Temperatures objects to a JSON string.
        /// </summary>
        /// <param name="self">The array of Temperatures objects to convert.</param>
        /// <returns>A JSON string representing the array of Temperatures objects.</returns>
        public static string ToJson(this Temperatures[] self)
        {
            return JsonSerializer.Serialize(self, Converter.Settings);
        }
    }

    /// <summary>
    ///     A static class used for converting JSON data.
    /// </summary>
    internal static class Converter
    {
        /// <summary>
        ///     Represents the settings for JSON serialization/deserialization.
        /// </summary>
        public static readonly JsonSerializerOptions Settings =
            new JsonSerializerOptions(JsonSerializerDefaults.General)
            {
                Converters =
                {
                    new DateOnlyConverter(),
                    new TimeOnlyConverter(),
                    IsoDateTimeOffsetConverter.Singleton
                }
            };
    }

    /// <summary>
    ///     Custom JSON converter for parsing string values as long.
    /// </summary>
    internal class ParseStringConverter : JsonConverter<long>
    {
        /// <summary>
        ///     Represents a singleton instance of the ParseStringConverter class.
        /// </summary>
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();

        /// <summary>
        ///     Determines whether the type can be converted to a long.
        /// </summary>
        /// <param name="t">The type to check.</param>
        /// <returns>True if the type can be converted to a long, false otherwise.</returns>
        public override bool CanConvert(Type t)
        {
            return t == typeof(long);
        }

        /// <summary>
        ///     Reads a JSON value as a long.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to be converted.</param>
        /// <param name="options">The JSON serializer options.</param>
        /// <returns>The deserialized long value.</returns>
        /// <exception cref="System.Exception">Thrown when the JSON value cannot be unmarshaled as a long.</exception>
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            long l;
            if (long.TryParse(value, out l)) return l;
            throw new Exception("Cannot unmarshal type long");
        }

        /// <summary>
        ///     This method writes a long value to the specified Utf8JsonWriter using the specified JsonSerializerOptions.
        /// </summary>
        /// <param name="writer">The Utf8JsonWriter to write to.</param>
        /// <param name="value">The long value to write.</param>
        /// <param name="options">The JsonSerializerOptions to use.</param>
        /// <returns>Nothing.</returns>
        /// /
        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToString(), options);
        }
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        /// <summary>
        ///     The serialization format used for encoding and decoding data.
        /// </summary>
        private readonly string serializationFormat;

        /// <summary>
        ///     Initializes a new instance of the DateOnlyConverter class with an optional format string.
        /// </summary>
        /// <param name="format">The format string to use for converting the date.</param>
        public DateOnlyConverter() : this(null)
        {
        }

        public DateOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(serializationFormat));
        }
    }

    /// <summary>
    ///     A custom JSON converter for serializing and deserializing TimeOnly objects.
    /// </summary>
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null)
        {
        }

        public TimeOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(serializationFormat));
        }
    }

    internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";


        public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
        private CultureInfo? _culture;
        private string? _dateTimeFormat;

        public DateTimeStyles DateTimeStyles { get; set; } = DateTimeStyles.RoundtripKind;

        public string? DateTimeFormat
        {
            get => _dateTimeFormat ?? string.Empty;
            set => _dateTimeFormat = string.IsNullOrEmpty(value) ? null : value;
        }

        public CultureInfo Culture
        {
            get => _culture ?? CultureInfo.CurrentCulture;
            set => _culture = value;
        }

        public override bool CanConvert(Type t)
        {
            return t == typeof(DateTimeOffset);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            string text;


            if ((DateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                || (DateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                value = value.ToUniversalTime();

            text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

            writer.WriteStringValue(text);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var dateText = reader.GetString();

            if (string.IsNullOrEmpty(dateText) == false)
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, DateTimeStyles);
                return DateTimeOffset.Parse(dateText, Culture, DateTimeStyles);
            }

            return default;
        }
    }
}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603