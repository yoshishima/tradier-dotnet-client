using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    /// <summary>
    /// Represents the root object for company information.
    /// </summary>
    public class CompanyInfo
    {
        /// <summary>
        /// Represents the root object for company information.
        /// </summary>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        /// Represents the root object for company information.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Represents the root object for company information.
        /// </summary>
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }

    /// .
    public partial class Result
    {
        /// <summary>
        /// Represents the root object for company information.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Represents a result object.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Represents a collection of tables related to a company's profile, asset classification, ownership details, and share class information.
        /// </summary>
        [JsonPropertyName("tables")]
        public Tables Tables { get; set; }
    }

    /// <summary>
    /// Represents a collection of tables related to a company's profile, asset classification, ownership details, and share class information.
    /// </summary>
    public class Tables
    {
        /// <summary>
        /// Represents the company profile.
        /// </summary>
        [JsonPropertyName("company_profile")]
        public CompanyProfile CompanyProfile { get; set; }

        /// <summary>
        /// Represents the asset classification of a company.
        /// </summary>
        [JsonPropertyName("asset_classification")]
        public AssetClassification AssetClassification { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("historical_asset_classification")]
        public HistoricalAssetClassification HistoricalAssetClassification { get; set; }

        /// <summary>
        /// Represents a collection of tables related to a company's profile, asset classification, ownership details, and share class information.
        /// </summary>
        [JsonPropertyName("long_descriptions")]
        public string LongDescriptions { get; set; }

        /// Represents the ownership summary of a company's shares.
        [JsonPropertyName("ownership_summary")]
        public OwnershipSummary OwnershipSummary { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("share_class_profile")]
        public ShareClassProfile ShareClassProfile { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("ownership_details")]
        public List<OwnershipDetail> OwnershipDetails { get; set; }

        /// <summary>
        /// The ShareClass class represents a share class of a company.
        /// </summary>
        [JsonPropertyName("share_class")]
        public ShareClass ShareClass { get; set; }
    }

    /// <summary>
    /// Represents the company profile.
    /// </summary>
    public class CompanyProfile
    {
        /// <summary>
        /// Represents the company profile.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// Represents the company profile.
        /// </summary>
        [JsonPropertyName("average_employee_number")]
        public int AverageEmployeeNumber { get; set; }

        /// <summary>
        /// Represents the company profile.
        /// </summary>
        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Represents a headquarter location.
        /// </summary>
        [JsonPropertyName("headquarter")]
        public Headquarter Headquarter { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the head office location is the same as the registered office location.
        /// </summary>
        /// <remarks>
        /// This property is part of the <see cref="CompanyProfile"/> class in the <see cref="Tradier.Client.Models.Fundamentals"/> namespace.
        /// The head office location is represented by the <see cref="Headquarter"/> class.
        /// </remarks>
        /// <value>
        /// <c>true</c> if the head office location is the same as the registered office location; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("is_head_office_same_with_registered_office_flag")]
        public bool IsHeadOfficeSameWithRegisteredOfficeFlag { get; set; }

        /// <summary>
        /// Represents the company profile.
        /// </summary>
        [JsonPropertyName("total_employee_number")]
        public int TotalEmployeeNumber { get; set; }

        /// <summary>
        /// Represents the total number of employees as of a specific date.
        /// </summary>
        [JsonPropertyName("TotalEmployeeNumber.asOfDate")]
        public string TotalEmployeeNumberAsOfDate { get; set; }
    }

    /// <summary>
    /// Represents a headquarter location.
    /// </summary>
    public class Headquarter
    {
        /// <summary>
        /// Represents a headquarter location.
        /// </summary>
        [JsonPropertyName("address_line1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Represents a headquarter location.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Represents a headquarter location.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Represents a headquarter location.
        /// </summary>
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        /// <summary>
        /// Represents the root object for company information.
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Represents the headquarter location of a company.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Represents a headquarter location.
        /// </summary>
        [JsonPropertyName("province")]
        public string Province { get; set; }
    }

    /// <summary>
    /// Represents the classification information for an asset.
    /// </summary>
    public class AssetClassification
    {
        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("c_a_n_n_a_i_c_s")]
        public int CANNAICS { get; set; }

        /// <summary>
        /// Represents the financial health grade of an asset.
        /// </summary>
        [JsonPropertyName("financial_health_grade")]
        public string FinancialHealthGrade { get; set; }

        /// <summary>
        /// Represents the financial health grade of an asset as of a specific date.
        /// </summary>
        [JsonPropertyName("FinancialHealthGrade.asOfDate")]
        public string FinancialHealthGradeAsOfDate { get; set; }

        /// <summary>
        /// Represents the growth grade of an asset.
        /// </summary>
        [JsonPropertyName("growth_grade")]
        public string GrowthGrade { get; set; }

        /// <summary>
        /// Represents the growth grade as of a specific date for an asset.
        /// </summary>
        [JsonPropertyName("GrowthGrade.asOfDate")]
        public string GrowthGradeAsOfDate { get; set; }

        /// Represents the growth score of a company.
        /// The growth score indicates the growth potential of a company based on various factors such as financial health,
        /// profitability, and industry growth. It is used to evaluate the strength and growth prospects of a company.
        /// /
        [JsonPropertyName("growth_score")]
        public double GrowthScore { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("morningstar_economy_sphere_code")]
        public int MorningstarEconomySphereCode { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("morningstar_industry_code")]
        public long MorningstarIndustryCode { get; set; }

        /// <summary>
        /// Represents the Morningstar industry group code for an asset.
        /// </summary>
        [JsonPropertyName("morningstar_industry_group_code")]
        public int MorningstarIndustryGroupCode { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("morningstar_sector_code")]
        public int MorningstarSectorCode { get; set; }

        /// Represents the classification information for an asset.
        /// /
        [JsonPropertyName("n_a_c_e")]
        public double NACE { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("n_a_i_c_s")]
        public int NAICS { get; set; }

        /// <summary>
        /// Represents the profitability grade of an asset.
        /// </summary>
        [JsonPropertyName("profitability_grade")]
        public string ProfitabilityGrade { get; set; }

        /// <summary>
        /// Represents the profitability grade classification information for an asset.
        /// </summary>
        [JsonPropertyName("ProfitabilityGrade.asOfDate")]
        public string ProfitabilityGradeAsOfDate { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("s_i_c")]
        public int SIC { get; set; }

        /// <summary>
        /// Represents the size score of an asset.
        /// </summary>
        [JsonPropertyName("size_score")]
        public double SizeScore { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("stock_type")]
        public int StockType { get; set; }

        /// <summary>
        /// Represents the as-of date for the stock type classification information.
        /// </summary>
        [JsonPropertyName("StockType.asOfDate")]
        public string StockTypeAsOfDate { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("style_box")]
        public int StyleBox { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("StyleBox.asOfDate")]
        public string StyleBoxAsOfDate { get; set; }

        /// <summary>
        /// Gets or sets the style score of the asset.
        /// </summary>
        /// <remarks>
        /// The style score represents the classification of the asset based on its investment style.
        /// It is a numeric value that indicates the ranking of the asset's investment style among its peers.
        /// Higher style score typically indicates a favorable investment style.
        /// </remarks>
        [JsonPropertyName("style_score")]
        public double StyleScore { get; set; }

        /// <summary>
        /// Represents the classification information for an asset.
        /// </summary>
        [JsonPropertyName("value_score")]
        public double ValueScore { get; set; }
    }

    /// <summary>
    /// Represents the historical classification of an asset.
    /// </summary>
    public class HistoricalAssetClassification
    {
        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public string AsOfDate { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("financial_health_grade")]
        public string FinancialHealthGrade { get; set; }

        /// data.
        [JsonPropertyName("growth_score")]
        public double GrowthScore { get; set; }

        /// asset.
        [JsonPropertyName("morningstar_economy_sphere_code")]
        public int MorningstarEconomySphereCode { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("morningstar_industry_code")]
        public long MorningstarIndustryCode { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("morningstar_industry_group_code")]
        public int MorningstarIndustryGroupCode { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("morningstar_sector_code")]
        public int MorningstarSectorCode { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("profitability_grade")]
        public string ProfitabilityGrade { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("size_score")]
        public double SizeScore { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("stock_type")]
        public int StockType { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("style_box")]
        public int StyleBox { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("style_score")]
        public double StyleScore { get; set; }

        /// <summary>
        /// Represents the historical classification of an asset.
        /// </summary>
        [JsonPropertyName("value_score")]
        public double ValueScore { get; set; }
    }

    /// <summary>
    /// Represents the ownership summary data for a company.
    /// </summary>
    public class OwnershipSummary
    {
        /// <summary>
        /// Represents the share class ID of a company.
        /// </summary>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        /// Gets or sets the date for which the ownership summary information is valid.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public string AsOfDate { get; set; }

        /// <summary>
        /// Represents the 13F holder number of an ownership summary.
        /// </summary>
        [JsonPropertyName("13_f_holder_number")]
        public int HolderNumber13F { get; set; }

        /// <summary>
        /// Gets the number of existing owners buying 13F.
        /// </summary>
        [JsonPropertyName("13_f_number_of_existing_owner_buying")]
        public int NumberOfExistingOwnerBuying13F { get; set; }

        /// <summary>
        /// The number of existing owners selling in 13F reporting.
        /// </summary>
        [JsonPropertyName("13_f_number_of_existing_owner_selling")]
        public int NumberOfExistingOwnerSelling13F { get; set; }

        /// <summary>
        /// Represents the number of new owners of a share class based on 13F filing.
        /// </summary>
        [JsonPropertyName("13_f_number_of_new_owners")]
        public int NumberOfNewOwners13F { get; set; }

        /// <summary>
        /// Gets or sets the number of sold out owners for 13F filings.
        /// </summary>
        [JsonPropertyName("13_f_number_of_sold_out_owners")]
        public int NumberOfSoldOutOwners13F { get; set; }

        /// <summary>
        /// Represents the number of shares bought by existing owners as reported in the 13F filing.
        /// </summary>
        [JsonPropertyName("13_f_shares_bought")]
        public long SharesBought13F { get; set; }

        /// <summary>
        /// Represents the number of shares held for the 13F ownership summary.
        /// </summary>
        [JsonPropertyName("13_f_shares_held")]
        public long SharesHeld13F { get; set; }

        /// <summary>
        /// Represents the number of shares sold as reported in the 13F filing.
        /// </summary>
        [JsonPropertyName("13_f_shares_sold")]
        public long SharesSold13F { get; set; }

        /// <summary>
        /// Represents the total market value for the 13F ownership summary.
        /// </summary>
        [JsonPropertyName("13_f_total_market_value")]
        public decimal TotalMarketValue13F { get; set; }

        /// <summary>
        /// Represents the total number of shares bought by new owners in the 13F ownership summary.
        /// </summary>
        [JsonPropertyName("13_f_total_shares_bought_by_new_owners")]
        public long TotalSharesBoughtByNewOwners13F { get; set; }

        /// <summary>
        /// Represents the total number of shares sold out by owners according to 13F filings.
        /// </summary>
        [JsonPropertyName("13_f_total_shares_sold_out")]
        public long TotalSharesSoldOut13F { get; set; }

        /// <summary>
        /// Represents the float property of the OwnershipSummary class.
        /// </summary>
        /// <remarks>
        /// The float property represents the number of shares that are available
        /// for public trading in a company's stock. It is the total number of
        /// shares issued by the company minus the restricted shares, insider
        /// holdings, and shares owned by major shareholders or institutional
        /// investors.
        /// </remarks>
        [JsonPropertyName("float")] public long Float { get; set; }

        /// <summary>
        /// The number of existing owners buying for a specific fund company.
        /// </summary>
        /// <value>
        /// The number of existing owners buying.
        /// </value>
        [JsonPropertyName("fund_company_number_of_existing_owner_buying")]
        public int FundCompanyNumberOfExistingOwnerBuying { get; set; }

        /// <summary>
        /// Gets the number of existing owners selling for the fund company.
        /// </summary>
        /// <value>The number of existing owners selling.</value>
        [JsonPropertyName("fund_company_number_of_existing_owner_selling")]
        public int FundCompanyNumberOfExistingOwnerSelling { get; set; }

        /// <summary>
        /// Gets the number of new owners for the fund company.
        /// </summary>
        [JsonPropertyName("fund_company_number_of_new_owners")]
        public int FundCompanyNumberOfNewOwners { get; set; }

        /// <summary>
        /// Gets the number of sold out owners for the fund company.
        /// </summary>
        [JsonPropertyName("fund_company_number_of_sold_out_owners")]
        public int FundCompanyNumberOfSoldOutOwners { get; set; }

        /// <summary>
        /// Represents the total market value of the fund company.
        /// </summary>
        /// <remarks>
        /// This property is defined in the CompanyInfo class of the Tradier.Client.Models.Fundamentals namespace.
        /// The value represents the aggregate market value of all the shares held by the fund company.
        /// </remarks>
        [JsonPropertyName("fund_company_total_market_value")]
        public decimal FundCompanyTotalMarketValue { get; set; }

        /// <summary>
        /// Gets the total number of shares bought by new owners for the fund company.
        /// </summary>
        /// <remarks>
        /// This value is obtained from the <see cref="OwnershipSummary"/> class.
        /// </remarks>
        /// <value>The total number of shares bought by new owners for the fund company.</value>
        [JsonPropertyName("fund_company_total_shares_bought_by_new_owners")]
        public long FundCompanyTotalSharesBoughtByNewOwners { get; set; }

        /// <summary>
        /// Represents the total number of shares sold out by the fund company.
        /// </summary>
        /// <remarks>
        /// The property is part of the <see cref="OwnershipSummary"/> class.
        /// </remarks>
        /// <seealso cref="OwnershipSummary"/>
        [JsonPropertyName("fund_company_total_shares_sold_out")]
        public long FundCompanyTotalSharesSoldOut { get; set; }

        /// <summary>
        /// Represents the number of insider shares bought.
        /// </summary>
        [JsonPropertyName("insider_shares_bought")]
        public long InsiderSharesBought { get; set; }

        /// <summary>
        /// The number of insider shares owned for a company.
        /// </summary>
        [JsonPropertyName("insider_shares_owned")]
        public long InsiderSharesOwned { get; set; }

        /// <summary>
        /// Gets or sets the number of insider shares sold.
        /// </summary>
        [JsonPropertyName("insider_shares_sold")]
        public long InsiderSharesSold { get; set; }

        /// <summary>
        /// The number of institutional holders.
        /// </summary>
        [JsonPropertyName("institution_holder_number")]
        public int InstitutionHolderNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of shares bought by institutions.
        /// </summary>
        [JsonPropertyName("institution_shares_bought")]
        public long InstitutionSharesBought { get; set; }

        /// <summary>
        /// Gets or sets the number of shares held by institutions.
        /// </summary>
        [JsonPropertyName("institution_shares_held")]
        public long InstitutionSharesHeld { get; set; }

        /// <summary>
        /// Represents the number of shares sold by institutions.
        /// </summary>
        [JsonPropertyName("institution_shares_sold")]
        public long InstitutionSharesSold { get; set; }

        /// <summary>
        /// Gets the number of insider buys.
        /// </summary>
        [JsonPropertyName("number_of_insider_buys")]
        public int NumberOfInsiderBuys { get; set; }

        /// <summary>
        /// Gets the number of insider sellers.
        /// </summary>
        [JsonPropertyName("number_of_insider_sellers")]
        public int NumberOfInsiderSellers { get; set; }

        /// <summary>
        /// Gets or sets the number of quoted shares outstanding.
        /// </summary>
        [JsonPropertyName("quoted_shares_outstanding")]
        public long QuotedSharesOutstanding { get; set; }

        /// <summary>
        /// Represents the number of shares outstanding at the share class level as indicated in the balance sheet.
        /// </summary>
        [JsonPropertyName("share_class_level_shares_outstanding_balance_sheet")]
        public long ShareClassLevelSharesOutstandingBalanceSheet { get; set; }

        /// <summary>
        /// Represents the interim value of the number of shares outstanding at the share class level.
        /// </summary>
        [JsonPropertyName("share_class_level_shares_outstanding_interim")]
        public long ShareClassLevelSharesOutstandingInterim { get; set; }

        /// <summary>
        /// Gets the treasury share outstanding at the share class level.
        /// </summary>
        [JsonPropertyName("share_class_level_treasury_share_outstanding")]
        public long ShareClassLevelTreasuryShareOutstanding { get; set; }

        /// <summary>
        /// Gets the number of shares outstanding for the company.
        /// </summary>
        /// <remarks>
        /// This property represents the total number of shares of a company's stock that are currently owned by shareholders.
        /// It is an important metric used by investors to assess the market value and liquidity of a company's stock.
        /// The shares outstanding can change over time due to factors such as stock buybacks, stock issuances, and stock splits.
        /// </remarks>
        [JsonPropertyName("shares_outstanding")]
        public long SharesOutstanding { get; set; }

        /// <summary>
        /// Gets or sets the shares outstanding with balance sheet ending date.
        /// </summary>
        [JsonPropertyName("shares_outstanding_with_balance_sheet_ending_date")]
        public string SharesOutstandingWithBalanceSheetEndingDate { get; set; }

        /// <summary>
        /// Gets or sets the number of unquoted shares outstanding.
        /// </summary>
        [JsonPropertyName("un_quoted_shares_outstanding")]
        public long UnQuotedSharesOutstanding { get; set; }
    }

    /// <summary>
    /// Represents the profile of a share class.
    /// </summary>
    public class ShareClassProfile
    {
        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("enterprise_value")]
        public decimal EnterpriseValue { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("EnterpriseValue.asOfDate")]
        public string EnterpriseValueAsOfDate { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("MarketCap.asOfDate")]
        public string MarketCapAsOfDate { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("reasonof_shares_change")]
        public string ReasonOfSharesChange { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("ReasonofSharesChange.asOfDate")]
        public string ReasonOfSharesChangeAsOfDate { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("share_class_level_shares_outstanding")]
        public long ShareClassLevelSharesOutstanding { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("ShareClassLevelSharesOutstanding.asOfDate")]
        public string ShareClassLevelSharesOutstandingAsOfDate { get; set; }

        /// <summary>
        /// Represents the profile of a share class including shares outstanding information.
        /// </summary>
        [JsonPropertyName("shares_outstanding")]
        public long SharesOutstanding { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("SharesOutstanding.asOfDate")]
        public string SharesOutstandingAsOfDate { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("shares_outstanding_with_balance_sheet_ending_date")]
        public string SharesOutstandingWithBalanceSheetEndingDate { get; set; }

        /// <summary>
        /// Represents the profile of a share class.
        /// </summary>
        [JsonPropertyName("SharesOutstandingWithBalanceSheetEndingDate.asOfDate")]
        public string SharesOutstandingWithBalanceSheetEndingDateAsOfDate { get; set; }
    }

    /// <summary>
    /// Represents ownership details of a share.
    /// </summary>
    public class OwnershipDetail
    {
        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("as_of_date")]
        public string AsOfDate { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("owner_type")]
        public string OwnerType { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("market_value")]
        public decimal MarketValue { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("number_of_shares")]
        public float NumberOfShares { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("owner_c_i_k")]
        public int OwnerCIK { get; set; }

        /// <summary>
        ///     Gets or sets the owner name of the property.
        /// </summary>
        /// <remarks>
        ///     This property is used to store the name of the person who owns the property.
        /// </remarks>
        /// <value>
        ///     A <see cref="System.String" /> representing the owner name.
        /// </value>
        [JsonPropertyName("owner_name")]
        public string OwnerName { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("share_change")]
        public int ShareChange { get; set; }

        /// <summary>
        /// Represents ownership details of a share.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Represents the root object for company information.
    /// </summary>
    public class ShareClass
    {
        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        /// <summary>
        /// The ShareClass class represents a share class of a company.
        /// </summary>
        [JsonPropertyName("delisting_date")]
        public string DelistingDate { get; set; }

        /// <summary>
        /// The ShareClass class represents a share class of a company.
        /// </summary>
        [JsonPropertyName("exchange_id")]
        public string ExchangeId { get; set; }

        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("i_p_o_date")]
        public string IPODate { get; set; }

        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("is_depositary_receipt")]
        public bool IsDepositaryReceipt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the share class is a direct investment.
        /// </summary>
        [JsonPropertyName("is_direct_invest")]
        public bool IsDirectInvest { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the dividend is reinvested for the ShareClass.
        /// </summary>
        [JsonPropertyName("is_dividend_reinvest")]
        public bool IsDividendReinvest { get; set; }

        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("is_primary_share")]
        public bool IsPrimaryShare { get; set; }

        /// <summary>
        /// Represents the ShareClass class of a company.
        /// </summary>
        [JsonPropertyName("m_i_c")]
        public string MIC { get; set; }

        /// <summary>
        /// Represents the par value of a share class.
        /// </summary>
        /// <remarks>
        /// The par value of a share class is the nominal value assigned to each share.
        /// It represents the minimum price at which a share can be issued.
        /// </remarks>
        [JsonPropertyName("par_value")]
        public decimal ParValue { get; set; }

        /// <summary>
        /// Represents the security type of a share class of a company.
        /// </summary>
        [JsonPropertyName("security_type")]
        public string SecurityType { get; set; }

        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("share_class_description")]
        public string ShareClassDescription { get; set; }

        /// <summary>
        /// The ShareClassStatus property represents the status of a share class of a company.
        /// </summary>
        /// <remarks>
        /// The ShareClassStatus property is a string that represents the current status of a share class.
        /// It can have different values, such as "Active", "Delisted", "Suspended", etc.
        /// </remarks>
        /// <seealso cref="ShareClass"/>
        [JsonPropertyName("share_class_status")]
        public string ShareClassStatus { get; set; }

        /// <summary>
        /// Represents a share class of a company.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Represents the trading status of a share class.
        /// </summary>
        [JsonPropertyName("trading_status")]
        public bool TradingStatus { get; set; }
    }
}