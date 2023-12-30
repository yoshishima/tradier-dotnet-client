#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603


using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    public class Financials
    {
        [JsonPropertyName("request")] public string Request { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("results")] public Result[] Results { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("tables")] public Tables Tables { get; set; }
    }

    public class Tables
    {
        [JsonPropertyName("segmentation")] public Segmentation Segmentation { get; set; }

        [JsonPropertyName("financial_statements_restate")]
        public FinancialStatementsRestate FinancialStatementsRestate { get; set; }

        [JsonPropertyName("historical_returns")]
        public HistoricalReturns HistoricalReturns { get; set; }

        [JsonPropertyName("earning_reports_restate")]
        public EarningReports[] EarningReportsRestate { get; set; }

        [JsonPropertyName("earning_reports_a_o_r")]
        public EarningReports[] EarningReportsAOR { get; set; }
    }

    public class EarningReports
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_3m")]
        public EarningReportsAORPeriod12M Period3M { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_9m")]
        public EarningReportsAORPeriod12M Period9M { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_12m")]
        public EarningReportsAORPeriod12M Period12M { get; set; }
    }

    public class EarningReportsAORPeriod12M
    {
        [JsonPropertyName("share_class_id")] public ShareClassId ShareClassId { get; set; }

        [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

        [JsonPropertyName("currency_id")] public CurrencyId CurrencyId { get; set; }

        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        [JsonPropertyName("period")] public Period Period { get; set; }

        [JsonPropertyName("report_type")] public string ReportType { get; set; }

        [JsonPropertyName("basic_average_shares")]
        public long BasicAverageShares { get; set; }

        [JsonPropertyName("basic_continuous_operations")]
        public double BasicContinuousOperations { get; set; }

        [JsonPropertyName("basic_e_p_s")] public double BasicEPS { get; set; }

        [JsonPropertyName("continuing_and_discontinued_basic_e_p_s")]
        public double ContinuingAndDiscontinuedBasicEPS { get; set; }

        [JsonPropertyName("continuing_and_discontinued_diluted_e_p_s")]
        public double ContinuingAndDiscontinuedDilutedEPS { get; set; }

        [JsonPropertyName("diluted_average_shares")]
        public long DilutedAverageShares { get; set; }

        [JsonPropertyName("diluted_continuous_operations")]
        public double DilutedContinuousOperations { get; set; }

        [JsonPropertyName("diluted_e_p_s")] public double DilutedEPS { get; set; }

        [JsonPropertyName("file_date")] public DateTimeOffset FileDate { get; set; }

        [JsonPropertyName("fiscal_year_end_change")]
        public bool FiscalYearEndChange { get; set; }

        [JsonPropertyName("normalized_basic_e_p_s")]
        public double NormalizedBasicEPS { get; set; }

        [JsonPropertyName("normalized_diluted_e_p_s")]
        public double NormalizedDilutedEPS { get; set; }

        [JsonPropertyName("period_ending_date")]
        public DateTimeOffset PeriodEndingDate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("accession_number")]
        public string AccessionNumber { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("form_type")]
        public string FormType { get; set; }
    }

    public class FinancialStatementsRestate
    {
        [JsonPropertyName("company_id")] public string CompanyId { get; set; }

        [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

        [JsonPropertyName("balance_sheet")] public BalanceSheet[] BalanceSheet { get; set; }

        [JsonPropertyName("cash_flow_statement")]
        public CashFlowStatement[] CashFlowStatement { get; set; }

        [JsonPropertyName("income_statement")] public IncomeStatement[] IncomeStatement { get; set; }
    }

    public class BalanceSheet
    {
        [JsonPropertyName("period_3m")] public Period3M Period3M { get; set; }
    }

    public class Period3M
    {
        [JsonPropertyName("currency_id")] public CurrencyId CurrencyId { get; set; }

        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        [JsonPropertyName("period")] public Period Period { get; set; }

        [JsonPropertyName("report_type")] public string ReportType { get; set; }

        [JsonPropertyName("accession_number")] public string AccessionNumber { get; set; }

        [JsonPropertyName("accounts_payable")] public long AccountsPayable { get; set; }

        [JsonPropertyName("accounts_receivable")]
        public long AccountsReceivable { get; set; }

        [JsonPropertyName("additional_paid_in_capital")]
        public long AdditionalPaidInCapital { get; set; }

        [JsonPropertyName("b_s_file_date")] public DateTimeOffset BSFileDate { get; set; }

        [JsonPropertyName("capital_lease_obligations")]
        public long CapitalLeaseObligations { get; set; }

        [JsonPropertyName("capital_stock")] public long CapitalStock { get; set; }

        [JsonPropertyName("cash_and_cash_equivalents")]
        public long CashAndCashEquivalents { get; set; }

        [JsonPropertyName("cash_cash_equivalents_and_marketable_securities")]
        public long CashCashEquivalentsAndMarketableSecurities { get; set; }

        [JsonPropertyName("common_stock")] public long CommonStock { get; set; }

        [JsonPropertyName("common_stock_equity")]
        public long CommonStockEquity { get; set; }

        [JsonPropertyName("com_tre_sha_num")] public long ComTreShaNum { get; set; }

        [JsonPropertyName("current_accrued_expenses")]
        public long CurrentAccruedExpenses { get; set; }

        [JsonPropertyName("current_assets")] public long CurrentAssets { get; set; }

        [JsonPropertyName("current_deferred_liabilities")]
        public long CurrentDeferredLiabilities { get; set; }

        [JsonPropertyName("current_deferred_revenue")]
        public long CurrentDeferredRevenue { get; set; }

        [JsonPropertyName("current_liabilities")]
        public long CurrentLiabilities { get; set; }

        [JsonPropertyName("file_date")] public DateTimeOffset FileDate { get; set; }

        [JsonPropertyName("fiscal_year_end_change")]
        public bool FiscalYearEndChange { get; set; }

        [JsonPropertyName("form_type")] public string FormType { get; set; }

        [JsonPropertyName("gains_losses_not_affecting_retained_earnings")]
        public long GainsLossesNotAffectingRetainedEarnings { get; set; }

        [JsonPropertyName("goodwill")] public long Goodwill { get; set; }

        [JsonPropertyName("goodwill_and_other_intangible_assets")]
        public long GoodwillAndOtherIntangibleAssets { get; set; }

        [JsonPropertyName("gross_p_p_e")] public long GrossPPE { get; set; }

        [JsonPropertyName("inventory")] public long Inventory { get; set; }

        [JsonPropertyName("invested_capital")] public long InvestedCapital { get; set; }

        [JsonPropertyName("long_term_capital_lease_obligation")]
        public long LongTermCapitalLeaseObligation { get; set; }

        [JsonPropertyName("long_term_debt")] public long LongTermDebt { get; set; }

        [JsonPropertyName("long_term_debt_and_capital_lease_obligation")]
        public long LongTermDebtAndCapitalLeaseObligation { get; set; }

        [JsonPropertyName("net_p_p_e")] public long NetPPE { get; set; }

        [JsonPropertyName("net_tangible_assets")]
        public long NetTangibleAssets { get; set; }

        [JsonPropertyName("non_current_deferred_liabilities")]
        public long NonCurrentDeferredLiabilities { get; set; }

        [JsonPropertyName("non_current_deferred_revenue")]
        public long NonCurrentDeferredRevenue { get; set; }

        [JsonPropertyName("non_current_deferred_taxes_liabilities")]
        public long NonCurrentDeferredTaxesLiabilities { get; set; }

        [JsonPropertyName("number_of_share_holders")]
        public long NumberOfShareHolders { get; set; }

        [JsonPropertyName("ordinary_shares_number")]
        public long OrdinarySharesNumber { get; set; }

        [JsonPropertyName("other_current_assets")]
        public long OtherCurrentAssets { get; set; }

        [JsonPropertyName("other_equity_adjustments")]
        public long OtherEquityAdjustments { get; set; }

        [JsonPropertyName("other_intangible_assets")]
        public long OtherIntangibleAssets { get; set; }

        [JsonPropertyName("other_non_current_assets")]
        public long OtherNonCurrentAssets { get; set; }

        [JsonPropertyName("other_non_current_liabilities")]
        public long OtherNonCurrentLiabilities { get; set; }

        [JsonPropertyName("other_properties")] public long OtherProperties { get; set; }

        [JsonPropertyName("other_short_term_investments")]
        public long OtherShortTermInvestments { get; set; }

        [JsonPropertyName("payables")] public long Payables { get; set; }

        [JsonPropertyName("payables_and_accrued_expenses")]
        public long PayablesAndAccruedExpenses { get; set; }

        [JsonPropertyName("period_ending_date")]
        public DateTimeOffset PeriodEndingDate { get; set; }

        [JsonPropertyName("receivables")] public long Receivables { get; set; }

        [JsonPropertyName("restricted_cash")] public long RestrictedCash { get; set; }

        [JsonPropertyName("retained_earnings")]
        public long RetainedEarnings { get; set; }

        [JsonPropertyName("share_issued")] public long ShareIssued { get; set; }

        [JsonPropertyName("stockholders_equity")]
        public long StockholdersEquity { get; set; }

        [JsonPropertyName("tangible_book_value")]
        public long TangibleBookValue { get; set; }

        [JsonPropertyName("total_assets")] public long TotalAssets { get; set; }

        [JsonPropertyName("total_capitalization")]
        public long TotalCapitalization { get; set; }

        [JsonPropertyName("total_debt")] public long TotalDebt { get; set; }

        [JsonPropertyName("total_equity")] public long TotalEquity { get; set; }

        [JsonPropertyName("total_equity_gross_minority_interest")]
        public long TotalEquityGrossMinorityInterest { get; set; }

        [JsonPropertyName("total_liabilities_net_minority_interest")]
        public long TotalLiabilitiesNetMinorityInterest { get; set; }

        [JsonPropertyName("total_non_current_assets")]
        public long TotalNonCurrentAssets { get; set; }

        [JsonPropertyName("total_non_current_liabilities_net_minority_interest")]
        public long TotalNonCurrentLiabilitiesNetMinorityInterest { get; set; }

        [JsonPropertyName("treasury_shares_number")]
        public long TreasurySharesNumber { get; set; }

        [JsonPropertyName("working_capital")] public long WorkingCapital { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("accumulated_depreciation")]
        public long? AccumulatedDepreciation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("allowance_for_doubtful_accounts_receivable")]
        public long? AllowanceForDoubtfulAccountsReceivable { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("construction_in_progress")]
        public long? ConstructionInProgress { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("finished_goods")]
        public long? FinishedGoods { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("gross_accounts_receivable")]
        public long? GrossAccountsReceivable { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("leases")]
        public long? Leases { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("machinery_furniture_equipment")]
        public long? MachineryFurnitureEquipment { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("other_current_liabilities")]
        public long? OtherCurrentLiabilities { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("preferred_stock")]
        public long? PreferredStock { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("prepaid_assets")]
        public long? PrepaidAssets { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("properties")]
        public long? Properties { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("raw_materials")]
        public long? RawMaterials { get; set; }
    }

    public class CashFlowStatement
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_3m")]
        public CashFlowStatementPeriod12M Period3M { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_9m")]
        public CashFlowStatementPeriod12M Period9M { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_12m")]
        public CashFlowStatementPeriod12M Period12M { get; set; }
    }

    public class CashFlowStatementPeriod12M
    {
        [JsonPropertyName("currency_id")] public CurrencyId CurrencyId { get; set; }

        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        [JsonPropertyName("period")] public Period Period { get; set; }

        [JsonPropertyName("report_type")] public string ReportType { get; set; }

        [JsonPropertyName("beginning_cash_position")]
        public long BeginningCashPosition { get; set; }

        [JsonPropertyName("capital_expenditure")]
        public long CapitalExpenditure { get; set; }

        [JsonPropertyName("cash_flow_from_continuing_financing_activities")]
        public long CashFlowFromContinuingFinancingActivities { get; set; }

        [JsonPropertyName("cash_flow_from_continuing_investing_activities")]
        public long CashFlowFromContinuingInvestingActivities { get; set; }

        [JsonPropertyName("cash_flow_from_continuing_operating_activities")]
        public long CashFlowFromContinuingOperatingActivities { get; set; }

        [JsonPropertyName("c_f_file_date")] public DateTimeOffset CFFileDate { get; set; }

        [JsonPropertyName("change_in_inventory")]
        public long ChangeInInventory { get; set; }

        [JsonPropertyName("change_in_other_working_capital")]
        public long ChangeInOtherWorkingCapital { get; set; }

        [JsonPropertyName("change_in_payables_and_accrued_expense")]
        public long ChangeInPayablesAndAccruedExpense { get; set; }

        [JsonPropertyName("change_in_prepaid_assets")]
        public long ChangeInPrepaidAssets { get; set; }

        [JsonPropertyName("change_in_receivables")]
        public long ChangeInReceivables { get; set; }

        [JsonPropertyName("change_in_working_capital")]
        public long ChangeInWorkingCapital { get; set; }

        [JsonPropertyName("changes_in_account_receivables")]
        public long ChangesInAccountReceivables { get; set; }

        [JsonPropertyName("changes_in_cash")] public long ChangesInCash { get; set; }

        [JsonPropertyName("common_stock_issuance")]
        public long CommonStockIssuance { get; set; }

        [JsonPropertyName("depreciation_amortization_depletion")]
        public long DepreciationAmortizationDepletion { get; set; }

        [JsonPropertyName("depreciation_and_amortization")]
        public long DepreciationAndAmortization { get; set; }

        [JsonPropertyName("effect_of_exchange_rate_changes")]
        public long EffectOfExchangeRateChanges { get; set; }

        [JsonPropertyName("end_cash_position")]
        public long EndCashPosition { get; set; }

        [JsonPropertyName("file_date")] public DateTimeOffset FileDate { get; set; }

        [JsonPropertyName("financing_cash_flow")]
        public long FinancingCashFlow { get; set; }

        [JsonPropertyName("fiscal_year_end_change")]
        public bool FiscalYearEndChange { get; set; }

        [JsonPropertyName("free_cash_flow")] public long FreeCashFlow { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("income_tax_paid_supplemental_data")]
        public long? IncomeTaxPaidSupplementalData { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("interest_paid_supplemental_data")]
        public long? InterestPaidSupplementalData { get; set; }

        [JsonPropertyName("investing_cash_flow")]
        public long InvestingCashFlow { get; set; }

        [JsonPropertyName("issuance_of_capital_stock")]
        public long IssuanceOfCapitalStock { get; set; }

        [JsonPropertyName("issuance_of_debt")] public long IssuanceOfDebt { get; set; }

        [JsonPropertyName("long_term_debt_issuance")]
        public long LongTermDebtIssuance { get; set; }

        [JsonPropertyName("net_business_purchase_and_sale")]
        public long NetBusinessPurchaseAndSale { get; set; }

        [JsonPropertyName("net_common_stock_issuance")]
        public long NetCommonStockIssuance { get; set; }

        [JsonPropertyName("net_income_from_continuing_operations")]
        public long NetIncomeFromContinuingOperations { get; set; }

        [JsonPropertyName("net_investment_purchase_and_sale")]
        public long NetInvestmentPurchaseAndSale { get; set; }

        [JsonPropertyName("net_issuance_payments_of_debt")]
        public long NetIssuancePaymentsOfDebt { get; set; }

        [JsonPropertyName("net_long_term_debt_issuance")]
        public long NetLongTermDebtIssuance { get; set; }

        [JsonPropertyName("net_other_financing_charges")]
        public long NetOtherFinancingCharges { get; set; }

        [JsonPropertyName("net_p_p_e_purchase_and_sale")]
        public long NetPPEPurchaseAndSale { get; set; }

        [JsonPropertyName("number_of_share_holders")]
        public long NumberOfShareHolders { get; set; }

        [JsonPropertyName("operating_cash_flow")]
        public long OperatingCashFlow { get; set; }

        [JsonPropertyName("other_non_cash_items")]
        public long OtherNonCashItems { get; set; }

        [JsonPropertyName("period_ending_date")]
        public DateTimeOffset PeriodEndingDate { get; set; }

        [JsonPropertyName("proceeds_from_stock_option_exercised")]
        public long ProceedsFromStockOptionExercised { get; set; }

        [JsonPropertyName("purchase_of_business")]
        public long PurchaseOfBusiness { get; set; }

        [JsonPropertyName("purchase_of_investment")]
        public long PurchaseOfInvestment { get; set; }

        [JsonPropertyName("purchase_of_p_p_e")]
        public long PurchaseOfPPE { get; set; }

        [JsonPropertyName("sale_of_investment")]
        public long SaleOfInvestment { get; set; }

        [JsonPropertyName("stock_based_compensation")]
        public long StockBasedCompensation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("change_in_account_payable")]
        public long? ChangeInAccountPayable { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("change_in_payable")]
        public long? ChangeInPayable { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("asset_impairment_charge")]
        public long? AssetImpairmentCharge { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("accession_number")]
        public string AccessionNumber { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("form_type")]
        public string FormType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("provisionand_write_offof_assets")]
        public long? ProvisionandWriteOffofAssets { get; set; }
    }

    public class IncomeStatement
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_3m")]
        public IncomeStatementPeriod12M Period3M { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_9m")]
        public IncomeStatementPeriod12M Period9M { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("period_12m")]
        public IncomeStatementPeriod12M Period12M { get; set; }
    }

    public class IncomeStatementPeriod12M
    {
        [JsonPropertyName("currency_id")] public CurrencyId CurrencyId { get; set; }

        [JsonPropertyName("fiscal_year_end")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FiscalYearEnd { get; set; }

        [JsonPropertyName("period")] public Period Period { get; set; }

        [JsonPropertyName("report_type")] public string ReportType { get; set; }

        [JsonPropertyName("cost_of_revenue")] public long CostOfRevenue { get; set; }

        [JsonPropertyName("diluted_n_i_availto_com_stockholders")]
        public long DilutedNIAvailtoComStockholders { get; set; }

        [JsonPropertyName("e_b_i_t")] public long EBIT { get; set; }

        [JsonPropertyName("e_b_i_t_d_a")] public long EBITDA { get; set; }

        [JsonPropertyName("file_date")] public DateTimeOffset FileDate { get; set; }

        [JsonPropertyName("fiscal_year_end_change")]
        public bool FiscalYearEndChange { get; set; }

        [JsonPropertyName("general_and_administrative_expense")]
        public long GeneralAndAdministrativeExpense { get; set; }

        [JsonPropertyName("gross_profit")] public long GrossProfit { get; set; }

        [JsonPropertyName("interest_expense")] public long InterestExpense { get; set; }

        [JsonPropertyName("interest_expense_non_operating")]
        public long InterestExpenseNonOperating { get; set; }

        [JsonPropertyName("interest_income")] public long InterestIncome { get; set; }

        [JsonPropertyName("interest_income_non_operating")]
        public long InterestIncomeNonOperating { get; set; }

        [JsonPropertyName("i_s_file_date")] public DateTimeOffset ISFileDate { get; set; }

        [JsonPropertyName("net_income")] public long NetIncome { get; set; }

        [JsonPropertyName("net_income_common_stockholders")]
        public long NetIncomeCommonStockholders { get; set; }

        [JsonPropertyName("net_income_continuous_operations")]
        public long NetIncomeContinuousOperations { get; set; }

        [JsonPropertyName("net_income_from_continuing_and_discontinued_operation")]
        public long NetIncomeFromContinuingAndDiscontinuedOperation { get; set; }

        [JsonPropertyName("net_income_from_continuing_operation_net_minority_interest")]
        public long NetIncomeFromContinuingOperationNetMinorityInterest { get; set; }

        [JsonPropertyName("net_income_including_noncontrolling_interests")]
        public long NetIncomeIncludingNoncontrollingInterests { get; set; }

        [JsonPropertyName("net_interest_income")]
        public long NetInterestIncome { get; set; }

        [JsonPropertyName("net_non_operating_interest_income_expense")]
        public long NetNonOperatingInterestIncomeExpense { get; set; }

        [JsonPropertyName("normalized_e_b_i_t_d_a")]
        public long NormalizedEBITDA { get; set; }

        [JsonPropertyName("normalized_income")]
        public long NormalizedIncome { get; set; }

        [JsonPropertyName("normalized_pre_tax_income")]
        public long NormalizedPreTaxIncome { get; set; }

        [JsonPropertyName("number_of_share_holders")]
        public long NumberOfShareHolders { get; set; }

        [JsonPropertyName("operating_expense")]
        public long OperatingExpense { get; set; }

        [JsonPropertyName("operating_income")] public long OperatingIncome { get; set; }

        [JsonPropertyName("operating_revenue")]
        public long OperatingRevenue { get; set; }

        [JsonPropertyName("other_gn_a")] public long OtherGnA { get; set; }

        [JsonPropertyName("other_income_expense")]
        public long OtherIncomeExpense { get; set; }

        [JsonPropertyName("other_non_operating_income_expenses")]
        public long OtherNonOperatingIncomeExpenses { get; set; }

        [JsonPropertyName("period_ending_date")]
        public DateTimeOffset PeriodEndingDate { get; set; }

        [JsonPropertyName("pretax_income")] public long PretaxIncome { get; set; }

        [JsonPropertyName("reconciled_cost_of_revenue")]
        public long ReconciledCostOfRevenue { get; set; }

        [JsonPropertyName("reconciled_depreciation")]
        public long ReconciledDepreciation { get; set; }

        [JsonPropertyName("research_and_development")]
        public long ResearchAndDevelopment { get; set; }

        [JsonPropertyName("selling_and_marketing_expense")]
        public long SellingAndMarketingExpense { get; set; }

        [JsonPropertyName("selling_general_and_administration")]
        public long SellingGeneralAndAdministration { get; set; }

        [JsonPropertyName("tax_effect_of_unusual_items")]
        public long TaxEffectOfUnusualItems { get; set; }

        [JsonPropertyName("tax_provision")] public long TaxProvision { get; set; }

        [JsonPropertyName("tax_rate_for_calcs")]
        public double TaxRateForCalcs { get; set; }

        [JsonPropertyName("total_expenses")] public long TotalExpenses { get; set; }

        [JsonPropertyName("total_operating_income_as_reported")]
        public long TotalOperatingIncomeAsReported { get; set; }

        [JsonPropertyName("total_revenue")] public long TotalRevenue { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("total_unusual_items")]
        public long? TotalUnusualItems { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("total_unusual_items_excluding_goodwill")]
        public long? TotalUnusualItemsExcludingGoodwill { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("accession_number")]
        public string AccessionNumber { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("form_type")]
        public string FormType { get; set; }
    }

    public class HistoricalReturns
    {
        [JsonPropertyName("period_1w")] public Period1W Period1W { get; set; }
    }

    public class Period1W
    {
        [JsonPropertyName("share_class_id")] public ShareClassId ShareClassId { get; set; }

        [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

        [JsonPropertyName("period")] public string Period { get; set; }

        [JsonPropertyName("total_return")] public double TotalReturn { get; set; }
    }

    public class Segmentation
    {
        [JsonPropertyName("period_3m")] public SegmentationPeriod12M Period3M { get; set; }

        [JsonPropertyName("period_6m")] public Period6MClass Period6M { get; set; }

        [JsonPropertyName("period_9m")] public Period6MClass Period9M { get; set; }

        [JsonPropertyName("period_12m")] public SegmentationPeriod12M Period12M { get; set; }
    }

    public class SegmentationPeriod12M
    {
        [JsonPropertyName("company_id")] public string CompanyId { get; set; }

        [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

        [JsonPropertyName("period")] public Period Period { get; set; }

        [JsonPropertyName("operating_revenue")]
        public long OperatingRevenue { get; set; }

        [JsonPropertyName("total_assets")] public double TotalAssets { get; set; }

        [JsonPropertyName("total_non_current_assets")]
        public long TotalNonCurrentAssets { get; set; }
    }

    public class Period6MClass
    {
        [JsonPropertyName("company_id")] public string CompanyId { get; set; }

        [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

        [JsonPropertyName("period")] public string Period { get; set; }

        [JsonPropertyName("operating_revenue")]
        public long OperatingRevenue { get; set; }
    }

    public enum CurrencyId
    {
        Usd
    }

    public enum Period
    {
        The12M,
        The3M,
        The9M
    }

    public enum ShareClassId
    {
        The0P0001Mkrd
    }

    public class Temperatures
    {
        public static Temperatures[] FromJson(string json)
        {
            return JsonSerializer.Deserialize<Temperatures[]>(json, QuickType.Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Temperatures[] self)
        {
            return JsonSerializer.Serialize(self, QuickType.Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
        {
            Converters =
            {
                CurrencyIdConverter.Singleton,
                PeriodConverter.Singleton,
                ShareClassIdConverter.Singleton,
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
                IsoDateTimeOffsetConverter.Singleton
            }
        };
    }

    internal class CurrencyIdConverter : JsonConverter<CurrencyId>
    {
        public static readonly CurrencyIdConverter Singleton = new CurrencyIdConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(CurrencyId);
        }

        public override CurrencyId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == "USD") return CurrencyId.Usd;
            throw new Exception("Cannot unmarshal type CurrencyId");
        }

        public override void Write(Utf8JsonWriter writer, CurrencyId value, JsonSerializerOptions options)
        {
            if (value == CurrencyId.Usd)
            {
                JsonSerializer.Serialize(writer, "USD", options);
                return;
            }

            throw Exceptions("Cannot marshal type CurrencyId");
        }
    }

    internal class ParseStringConverter : JsonConverter<long>
    {
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(long);
        }

        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            long l;
            if (long.TryParse(value, out l)) return l;
            throw new Exception("Cannot unmarshal type long");
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToString(), options);
        }
    }

    internal class PeriodConverter : JsonConverter<Period>
    {
        public static readonly PeriodConverter Singleton = new PeriodConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(Period);
        }

        public override Period Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            switch (value)
            {
                case "12M":
                    return Period.The12M;
                case "3M":
                    return Period.The3M;
                case "9M":
                    return Period.The9M;
            }

            throw new Exception("Cannot unmarshal type Period");
        }

        public override void Write(Utf8JsonWriter writer, Period value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case Period.The12M:
                    JsonSerializer.Serialize(writer, "12M", options);
                    return;
                case Period.The3M:
                    JsonSerializer.Serialize(writer, "3M", options);
                    return;
                case Period.The9M:
                    JsonSerializer.Serialize(writer, "9M", options);
                    return;
            }

            throw new Exception("Cannot marshal type Period");
        }
    }

    internal class ShareClassIdConverter : JsonConverter<ShareClassId>
    {
        public static readonly ShareClassIdConverter Singleton = new ShareClassIdConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(ShareClassId);
        }

        public override ShareClassId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == "0P0001MKRD") return ShareClassId.The0P0001Mkrd;
            throw new Exception("Cannot unmarshal type ShareClassId");
        }

        public override void Write(Utf8JsonWriter writer, ShareClassId value, JsonSerializerOptions options)
        {
            if (value == ShareClassId.The0P0001Mkrd)
            {
                JsonSerializer.Serialize(writer, "0P0001MKRD", options);
                return;
            }

            throw new Exception("Cannot marshal type ShareClassId");
        }
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;

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