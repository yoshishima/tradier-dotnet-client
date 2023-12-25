using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    /// <summary>
    ///     Represents the root object for company information.
    /// </summary>
    public class CompanyInfo
    {
        /// <summary>
        ///     Gets or sets the request property.
        /// </summary>
        /// <value>
        ///     The request property.
        /// </value>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        ///     Gets or sets the value of the Type property.
        /// </summary>
        /// <remarks>
        ///     This property represents the type of an object.
        /// </remarks>
        /// <value>
        ///     A string value representing the type of the object.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the list of results.
        /// </summary>
        /// <value>
        ///     The list of results.
        /// </value>
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }

    /// <summary>
    ///     Represents a result object.
    /// </summary>
    public class Result
    {
        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the property.
        /// </summary>
        /// <value>The ID of the property.</value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the property "Tables".
        /// </summary>
        /// <value>The <see cref="Tables" /> object.</value>
        [JsonPropertyName("tables")]
        public Tables Tables { get; set; }
    }

    /// <summary>
    ///     Represents a collection of tables related to a company's profile, asset classification, ownership details, and
    ///     share class information.
    /// </summary>
    public class Tables
    {
        /// <summary>
        ///     Gets or sets the company profile.
        /// </summary>
        /// <value>
        ///     The company profile.
        /// </value>
        [JsonPropertyName("company_profile")]
        public CompanyProfile CompanyProfile { get; set; }

        /// <summary>
        ///     Gets or sets the asset classification.
        /// </summary>
        [JsonPropertyName("asset_classification")]
        public AssetClassification AssetClassification { get; set; }

        /// <summary>
        ///     Gets or sets the historical asset classification.
        /// </summary>
        /// <value>
        ///     The historical asset classification.
        /// </value>
        [JsonPropertyName("historical_asset_classification")]
        public HistoricalAssetClassification HistoricalAssetClassification { get; set; }

        /// <summary>
        ///     Gets or sets the long descriptions.
        /// </summary>
        /// <value>
        ///     The long descriptions.
        /// </value>
        [JsonPropertyName("long_descriptions")]
        public string LongDescriptions { get; set; }

        /// <summary>
        ///     Represents the ownership summary of a property.
        /// </summary>
        [JsonPropertyName("ownership_summary")]
        public OwnershipSummary OwnershipSummary { get; set; }

        /// <summary>
        ///     Gets or sets the share class profile.
        /// </summary>
        /// <value>
        ///     The share class profile.
        /// </value>
        [JsonPropertyName("share_class_profile")]
        public ShareClassProfile ShareClassProfile { get; set; }

        /// <summary>
        ///     Gets or sets the list of ownership details.
        /// </summary>
        /// <value>
        ///     The ownership details.
        /// </value>
        [JsonPropertyName("ownership_details")]
        public List<OwnershipDetail> OwnershipDetails { get; set; }

        /// <summary>
        ///     Represents the share class of a property.
        /// </summary>
        [JsonPropertyName("share_class")]
        public ShareClass ShareClass { get; set; }
    }

    /// <summary>
    ///     Represents the company profile.
    /// </summary>
    public class CompanyProfile
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
        ///     Gets or sets the average number of employees.
        /// </summary>
        /// <value>
        ///     The average number of employees.
        /// </value>
        [JsonPropertyName("average_employee_number")]
        public int AverageEmployeeNumber { get; set; }

        /// <summary>
        ///     Gets or sets the contact email.
        /// </summary>
        /// <value>
        ///     The contact email.
        /// </value>
        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }

        /// <summary>
        ///     Gets or sets the Headquarter property.
        /// </summary>
        /// <value>The Headquarter property.</value>
        [JsonPropertyName("headquarter")]
        public Headquarter Headquarter { get; set; }

        /// <summary>
        ///     Gets or sets a flag indicating whether the head office is the same as the registered office.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the head office is the same as the registered office; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("is_head_office_same_with_registered_office_flag")]
        public bool IsHeadOfficeSameWithRegisteredOfficeFlag { get; set; }

        /// <summary>
        ///     Gets or sets the total number of employees.
        /// </summary>
        /// <value>The total employee number.</value>
        [JsonPropertyName("total_employee_number")]
        public int TotalEmployeeNumber { get; set; }

        /// <summary>
        ///     Gets or sets the total employee number as of a specific date.
        /// </summary>
        /// <remarks>
        ///     This property represents the total number of employees as of a specific date.
        ///     The date is provided in the "TotalEmployeeNumber.asOfDate" JSON property.
        /// </remarks>
        /// <value>
        ///     A string representing the date of when the total employee number was determined.
        /// </value>
        [JsonPropertyName("TotalEmployeeNumber.asOfDate")]
        public string TotalEmployeeNumberAsOfDate { get; set; }
    }

    /// <summary>
    ///     Represents a headquarter location.
    /// </summary>
    public class Headquarter
    {
        /// <summary>
        ///     Gets or sets the first line of the address.
        /// </summary>
        /// <value>
        ///     The first line of the address.
        /// </value>
        /// <remarks>
        ///     This property is decorated with the <see cref="JsonPropertyNameAttribute" /> which specifies the JSON property name
        ///     as "address_line1".
        /// </remarks>
        [JsonPropertyName("address_line1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        ///     Represents the city property.
        /// </summary>
        /// <value>
        ///     The name of the city.
        /// </value>
        /// /
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the country.
        /// </summary>
        /// <value>
        ///     The country.
        /// </value>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets the homepage of the property.
        /// </summary>
        /// <value>
        ///     A string representing the homepage URL of the property.
        /// </value>
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        /// <summary>
        ///     Gets or sets the phone number of an entity.
        /// </summary>
        /// <value>
        ///     The phone number.
        /// </value>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// /
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        ///     Gets or sets the province.
        /// </summary>
        [JsonPropertyName("province")]
        public string Province { get; set; }
    }

    /// <summary>
    ///     Represents the classification information for an asset.
    /// </summary>
    public class AssetClassification
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
        ///     Gets or sets the CANNAICS property.
        /// </summary>
        /// <value>
        ///     The CANNAICS property.
        /// </value>
        [JsonPropertyName("c_a_n_n_a_i_c_s")]
        public int CANNAICS { get; set; }

        /// <summary>
        ///     Gets or sets the financial health grade of the property.
        /// </summary>
        /// <remarks>
        ///     The financial health grade provides an indication of the overall financial stability or well-being of the property.
        ///     This property is typically represented by a string value.
        /// </remarks>
        /// <value>
        ///     The financial health grade.
        /// </value>
        [JsonPropertyName("financial_health_grade")]
        public string FinancialHealthGrade { get; set; }

        /// <summary>
        ///     Gets or sets the As-Of Date value for the Financial Health Grade.
        /// </summary>
        /// <value>
        ///     A string representing the As-Of Date for the Financial Health Grade property.
        /// </value>
        [JsonPropertyName("FinancialHealthGrade.asOfDate")]
        public string FinancialHealthGradeAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the growth grade of a property.
        /// </summary>
        /// <value>
        ///     The growth grade of the property.
        /// </value>
        [JsonPropertyName("growth_grade")]
        public string GrowthGrade { get; set; }

        /// <summary>
        ///     Gets or sets the growth grade as of date.
        /// </summary>
        /// <value>
        ///     The growth grade as of date.
        /// </value>
        [JsonPropertyName("GrowthGrade.asOfDate")]
        public string GrowthGradeAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the GrowthScore property.
        /// </summary>
        /// <value>
        ///     The GrowthScore property represents the growth score value.
        /// </value>
        [JsonPropertyName("growth_score")]
        public double GrowthScore { get; set; }

        /// <summary>
        ///     Gets or sets the Morningstar economy sphere code.
        /// </summary>
        /// <value>
        ///     The Morningstar economy sphere code.
        /// </value>
        [JsonPropertyName("morningstar_economy_sphere_code")]
        public int MorningstarEconomySphereCode { get; set; }

        /// <summary>
        ///     Gets or sets the Morningstar industry code.
        /// </summary>
        /// <value>
        ///     The Morningstar industry code.
        /// </value>
        [JsonPropertyName("morningstar_industry_code")]
        public long MorningstarIndustryCode { get; set; }

        /// <summary>
        ///     Gets or sets the Morningstar industry group code.
        /// </summary>
        /// <value>
        ///     The Morningstar industry group code.
        /// </value>
        [JsonPropertyName("morningstar_industry_group_code")]
        public int MorningstarIndustryGroupCode { get; set; }

        /// <summary>
        ///     Gets or sets the Morningstar sector code.
        /// </summary>
        /// <value>
        ///     The Morningstar sector code.
        /// </value>
        [JsonPropertyName("morningstar_sector_code")]
        public int MorningstarSectorCode { get; set; }

        /// <summary>
        ///     Represents the NACE property.
        /// </summary>
        [JsonPropertyName("n_a_c_e")]
        public double NACE { get; set; }

        /// <summary>
        ///     Gets or sets the NAICS (North American Industry Classification System) property.
        /// </summary>
        /// <value>The NAICS code.</value>
        [JsonPropertyName("n_a_i_c_s")]
        public int NAICS { get; set; }

        /// <summary>
        ///     Gets or sets the profitability grade.
        /// </summary>
        /// <value>
        ///     The profitability grade.
        /// </value>
        [JsonPropertyName("profitability_grade")]
        public string ProfitabilityGrade { get; set; }

        /// <summary>
        ///     Gets or sets the date representing the profitability grade as of date.
        /// </summary>
        /// <remarks>
        ///     This property represents the date when the profitability grade was assigned or calculated.
        /// </remarks>
        /// <value>
        ///     The profitability grade as of date.
        /// </value>
        [JsonPropertyName("ProfitabilityGrade.asOfDate")]
        public string ProfitabilityGradeAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the SIC property.
        /// </summary>
        /// <value>
        ///     The SIC property.
        /// </value>
        [JsonPropertyName("s_i_c")]
        public int SIC { get; set; }

        /// <summary>
        ///     Gets or sets the size score value.
        /// </summary>
        /// <value>
        ///     The size score.
        /// </value>
        [JsonPropertyName("size_score")]
        public double SizeScore { get; set; }

        /// <summary>
        ///     Represents the type of stock.
        /// </summary>
        /// <remarks>
        ///     This property specifies the type of stock for a particular item.
        ///     The value represents the category or classification of the stock.
        /// </remarks>
        [JsonPropertyName("stock_type")]
        public int StockType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the StockType as of a specific date.
        /// </summary>
        /// <value>
        ///     The value of the StockType as of a specific date.
        /// </value>
        [JsonPropertyName("StockType.asOfDate")]
        public string StockTypeAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the <see cref="StyleBox" /> property.
        /// </summary>
        /// <value>
        ///     The value of the <see cref="StyleBox" /> property.
        /// </value>
        [JsonPropertyName("style_box")]
        public int StyleBox { get; set; }

        /// <summary>
        ///     Gets or sets the as-of date for the StyleBox property.
        /// </summary>
        /// <value>
        ///     The as-of date for the StyleBox property.
        /// </value>
        [JsonPropertyName("StyleBox.asOfDate")]
        public string StyleBoxAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the style score for the given property.
        /// </summary>
        /// <value>The style score.</value>
        [JsonPropertyName("style_score")]
        public double StyleScore { get; set; }

        /// <summary>
        ///     Gets or sets the value score.
        /// </summary>
        [JsonPropertyName("value_score")]
        public double ValueScore { get; set; }
    }

    /// <summary>
    ///     Represents the historical classification of an asset.
    /// </summary>
    public class HistoricalAssetClassification
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
        ///     Gets or sets the AsOfDate property.
        /// </summary>
        /// <value>
        ///     The AsOfDate.
        /// </value>
        [JsonPropertyName("as_of_date")]
        public string AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the financial health grade.
        /// </summary>
        /// <value>
        ///     The financial health grade.
        /// </value>
        [JsonPropertyName("financial_health_grade")]
        public string FinancialHealthGrade { get; set; }

        /// <summary>
        ///     The growth score of a property.
        /// </summary>
        /// <value>
        ///     The growth score value.
        /// </value>
        [JsonPropertyName("growth_score")]
        public double GrowthScore { get; set; }

        /// <summary>
        ///     Gets or sets the Morningstar Economy Sphere Code.
        /// </summary>
        /// <value>
        ///     The Morningstar Economy Sphere Code.
        /// </value>
        [JsonPropertyName("morningstar_economy_sphere_code")]
        public int MorningstarEconomySphereCode { get; set; }

        /// <summary>
        ///     Gets or sets the Morningstar industry code.
        /// </summary>
        /// <remarks>
        ///     This property represents the Morningstar industry code.
        /// </remarks>
        [JsonPropertyName("morningstar_industry_code")]
        public long MorningstarIndustryCode { get; set; }

        /// <summary>
        ///     Represents the Morningstar industry group code.
        /// </summary>
        /// <value>
        ///     The Morningstar industry group code.
        /// </value>
        [JsonPropertyName("morningstar_industry_group_code")]
        public int MorningstarIndustryGroupCode { get; set; }

        /// <summary>
        ///     Represents the Morningstar sector code property.
        /// </summary>
        /// <remarks>
        ///     This property holds the code representing the sector of a financial asset according to Morningstar classification.
        /// </remarks>
        [JsonPropertyName("morningstar_sector_code")]
        public int MorningstarSectorCode { get; set; }

        /// <summary>
        ///     Gets or sets the profitability grade.
        /// </summary>
        /// <value>
        ///     The profitability grade.
        /// </value>
        [JsonPropertyName("profitability_grade")]
        public string ProfitabilityGrade { get; set; }

        /// <summary>
        ///     Gets or sets the SizeScore property.
        /// </summary>
        /// <value>
        ///     The SizeScore property represents the score based on the size of an object.
        /// </value>
        /// /
        [JsonPropertyName("size_score")]
        public double SizeScore { get; set; }

        /// <summary>
        ///     Gets or sets the stock type.
        /// </summary>
        /// <value>
        ///     The stock type.
        /// </value>
        [JsonPropertyName("stock_type")]
        public int StockType { get; set; }

        /// <summary>
        ///     Gets or sets the StyleBox property.
        /// </summary>
        /// <value>
        ///     The style box.
        /// </value>
        [JsonPropertyName("style_box")]
        public int StyleBox { get; set; }

        /// <summary>
        ///     Represents the style score of an item.
        /// </summary>
        /// <value>
        ///     The style score of an item.
        /// </value>
        [JsonPropertyName("style_score")]
        public double StyleScore { get; set; }

        /// <summary>
        ///     Gets or sets the value score.
        /// </summary>
        /// <value>
        ///     The value score.
        /// </value>
        [JsonPropertyName("value_score")]
        public double ValueScore { get; set; }
    }

    /// <summary>
    ///     Represents the ownership summary of a share class.
    /// </summary>
    public class OwnershipSummary
    {
        /// <summary>
        ///     Gets or sets the share class ID.
        /// </summary>
        /// <value>
        ///     The share class ID.
        /// </value>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        ///     The date when the property was last updated.
        /// </summary>
        /// <remarks>
        ///     This property represents the "as_of_date" field in the JSON data.
        /// </remarks>
        [JsonPropertyName("as_of_date")]
        public string AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the 13F holder number.
        /// </summary>
        /// <value>
        ///     The 13F holder number.
        /// </value>
        [JsonPropertyName("13_f_holder_number")]
        public int HolderNumber13F { get; set; }

        /// <summary>
        ///     Gets or sets the number of existing owners buying 13F.
        /// </summary>
        /// <value>
        ///     The number of existing owners buying 13F.
        /// </value>
        [JsonPropertyName("13_f_number_of_existing_owner_buying")]
        public int NumberOfExistingOwnerBuying13F { get; set; }

        /// <summary>
        ///     Gets or sets the number of existing owners selling in 13F.
        /// </summary>
        /// <value>
        ///     The number of existing owners selling in 13F.
        /// </value>
        [JsonPropertyName("13_f_number_of_existing_owner_selling")]
        public int NumberOfExistingOwnerSelling13F { get; set; }

        /// <summary>
        ///     Gets or sets the number of new owners for a certain property (13F).
        /// </summary>
        /// <value>
        ///     The number of new owners for the property.
        /// </value>
        [JsonPropertyName("13_f_number_of_new_owners")]
        public int NumberOfNewOwners13F { get; set; }

        /// <summary>
        ///     Gets or sets the number of sold out owners for 13F.
        /// </summary>
        /// <value>
        ///     The number of sold out owners for 13F.
        /// </value>
        [JsonPropertyName("13_f_number_of_sold_out_owners")]
        public int NumberOfSoldOutOwners13F { get; set; }

        /// <summary>
        ///     Gets or sets the number of shares bought for the property SharesBought13F.
        /// </summary>
        /// <value>
        ///     The number of shares bought.
        /// </value>
        [JsonPropertyName("13_f_shares_bought")]
        public long SharesBought13F { get; set; }

        /// <summary>
        ///     Gets or sets the number of shares held as reported in the 13-F form.
        /// </summary>
        /// <remarks>
        ///     This property defines the number of shares held by an entity as reported in the 13-F form, which is a quarterly
        ///     filing that discloses institutional holdings of publicly traded securities
        ///     .
        /// </remarks>
        /// <value>
        ///     The number of shares held as reported in the 13-F form.
        /// </value>
        [JsonPropertyName("13_f_shares_held")]
        public long SharesHeld13F { get; set; }

        /// <summary>
        ///     Gets or sets the number of 13F shares sold.
        /// </summary>
        /// <value>
        ///     The number of 13F shares sold.
        /// </value>
        [JsonPropertyName("13_f_shares_sold")]
        public long SharesSold13F { get; set; }

        /// <summary>
        ///     Gets or sets the total market value for 13F.
        /// </summary>
        /// <value>
        ///     The total market value for 13F.
        /// </value>
        [JsonPropertyName("13_f_total_market_value")]
        public decimal TotalMarketValue13F { get; set; }

        /// <summary>
        ///     Represents the total number of shares bought by new owners as reported in the 13F filing.
        /// </summary>
        /// <value>The total number of shares bought by new owners.</value>
        [JsonPropertyName("13_f_total_shares_bought_by_new_owners")]
        public long TotalSharesBoughtByNewOwners13F { get; set; }

        /// <summary>
        ///     Gets or sets the total number of shares sold out in 13F.
        /// </summary>
        /// <value>
        ///     The total number of shares sold out in 13F.
        /// </value>
        [JsonPropertyName("13_f_total_shares_sold_out")]
        public long TotalSharesSoldOut13F { get; set; }

        [JsonPropertyName("float")] public long Float { get; set; }

        /// <summary>
        ///     Gets or sets the number of existing owners buying from the fund company.
        /// </summary>
        /// <value>
        ///     The number of existing owners buying.
        /// </value>
        [JsonPropertyName("fund_company_number_of_existing_owner_buying")]
        public int FundCompanyNumberOfExistingOwnerBuying { get; set; }

        /// <summary>
        ///     Gets or sets the number of existing owners selling shares in the fund company.
        /// </summary>
        /// <value>
        ///     An integer value representing the number of existing owners selling shares.
        /// </value>
        /// <remarks>
        ///     This property is decorated with the JsonPropertyName attribute to specify the corresponding name in the JSON data.
        /// </remarks>
        [JsonPropertyName("fund_company_number_of_existing_owner_selling")]
        public int FundCompanyNumberOfExistingOwnerSelling { get; set; }

        /// <summary>
        ///     Gets or sets the number of new owners for the fund company.
        /// </summary>
        /// <value>
        ///     The number of new owners for the fund company.
        /// </value>
        [JsonPropertyName("fund_company_number_of_new_owners")]
        public int FundCompanyNumberOfNewOwners { get; set; }

        /// <summary>
        ///     Gets or sets the number of sold out owners for the fund company.
        /// </summary>
        /// <value>
        ///     The number of sold out owners for the fund company.
        /// </value>
        [JsonPropertyName("fund_company_number_of_sold_out_owners")]
        public int FundCompanyNumberOfSoldOutOwners { get; set; }

        /// <summary>
        ///     Gets or sets the total market value of the fund company.
        /// </summary>
        /// <remarks>
        ///     This property represents the total market value of the fund company. It is a decimal value.
        /// </remarks>
        [JsonPropertyName("fund_company_total_market_value")]
        public decimal FundCompanyTotalMarketValue { get; set; }

        /// <summary>
        ///     Represents the total number of shares bought by new owners of a fund company.
        /// </summary>
        /// <remarks>
        ///     The value of this property reflects the cumulative number of shares purchased by new owners of a fund company.
        /// </remarks>
        /// /
        [JsonPropertyName("fund_company_total_shares_bought_by_new_owners")]
        public long FundCompanyTotalSharesBoughtByNewOwners { get; set; }

        /// <summary>
        ///     Gets or sets the total number of shares sold out by the fund company.
        /// </summary>
        /// <value>
        ///     The total number of shares sold out.
        /// </value>
        [JsonPropertyName("fund_company_total_shares_sold_out")]
        public long FundCompanyTotalSharesSoldOut { get; set; }

        /// <summary>
        ///     Gets or sets the number of shares bought by insiders.
        /// </summary>
        /// <value>
        ///     The number of shares bought by insiders.
        /// </value>
        /// <remarks>
        ///     This property represents the number of shares that have been bought by insiders. It is typically used in financial
        ///     applications to track insider trading activity.
        /// </remarks>
        [JsonPropertyName("insider_shares_bought")]
        public long InsiderSharesBought { get; set; }

        /// Gets or sets the number of shares owned by insiders.
        /// /
        [JsonPropertyName("insider_shares_owned")]
        public long InsiderSharesOwned { get; set; }

        /// <summary>
        ///     Gets or sets the number of insider shares sold.
        /// </summary>
        [JsonPropertyName("insider_shares_sold")]
        public long InsiderSharesSold { get; set; }

        /// <summary>
        ///     Gets or sets the institution holder number.
        /// </summary>
        /// <value>
        ///     The institution holder number.
        /// </value>
        [JsonPropertyName("institution_holder_number")]
        public int InstitutionHolderNumber { get; set; }

        /// <summary>
        ///     Gets or sets the number of shares bought by an institution.
        /// </summary>
        /// <value>
        ///     The number of shares bought by an institution.
        /// </value>
        [JsonPropertyName("institution_shares_bought")]
        public long InstitutionSharesBought { get; set; }

        /// <summary>
        ///     Gets or sets the number of shares held by the institution.
        /// </summary>
        /// <value>
        ///     The number of shares held by the institution.
        /// </value>
        [JsonPropertyName("institution_shares_held")]
        public long InstitutionSharesHeld { get; set; }

        /// <summary>
        ///     Represents the number of shares sold by an institution.
        /// </summary>
        /// <value>
        ///     The number of shares sold by an institution.
        /// </value>
        [JsonPropertyName("institution_shares_sold")]
        public long InstitutionSharesSold { get; set; }

        /// <summary>
        ///     Gets or sets the number of insider buys.
        /// </summary>
        /// <value>
        ///     The number of insider buys.
        /// </value>
        [JsonPropertyName("number_of_insider_buys")]
        public int NumberOfInsiderBuys { get; set; }

        /// <summary>
        ///     Gets or sets the number of insider sellers.
        /// </summary>
        /// <remarks>
        ///     This property represents the number of individuals who are considered insiders and have sold shares of a particular
        ///     stock or security.
        /// </remarks>
        [JsonPropertyName("number_of_insider_sellers")]
        public int NumberOfInsiderSellers { get; set; }

        /// <summary>
        ///     Gets or sets the number of quoted shares outstanding.
        /// </summary>
        /// <value>
        ///     The number of quoted shares outstanding.
        /// </value>
        /// <remarks>
        ///     This property represents the total number of shares of a publicly traded company that are held by shareholders and
        ///     available for trading in the stock market.
        /// </remarks>
        [JsonPropertyName("quoted_shares_outstanding")]
        public long QuotedSharesOutstanding { get; set; }

        /// Gets or sets the value of the ShareClassLevelSharesOutstandingBalanceSheet property.
        /// /
        [JsonPropertyName("share_class_level_shares_outstanding_balance_sheet")]
        public long ShareClassLevelSharesOutstandingBalanceSheet { get; set; }

        /// <summary>
        ///     Gets or sets the share class level shares outstanding interim.
        /// </summary>
        /// <value>
        ///     The share class level shares outstanding interim.
        /// </value>
        [JsonPropertyName("share_class_level_shares_outstanding_interim")]
        public long ShareClassLevelSharesOutstandingInterim { get; set; }

        /// <summary>
        ///     Gets or sets the share class level treasury share outstanding.
        /// </summary>
        /// <value>
        ///     The share class level treasury share outstanding.
        /// </value>
        [JsonPropertyName("share_class_level_treasury_share_outstanding")]
        public long ShareClassLevelTreasuryShareOutstanding { get; set; }

        /// <summary>
        ///     The total number of outstanding shares for a given property.
        /// </summary>
        /// <value>
        ///     The number of outstanding shares.
        /// </value>
        [JsonPropertyName("shares_outstanding")]
        public long SharesOutstanding { get; set; }

        /// <summary>
        ///     Gets or sets the Shares Outstanding with Balance Sheet Ending Date.
        /// </summary>
        /// <value>
        ///     The Shares Outstanding with Balance Sheet Ending Date.
        /// </value>
        [JsonPropertyName("shares_outstanding_with_balance_sheet_ending_date")]
        public string SharesOutstandingWithBalanceSheetEndingDate { get; set; }

        /// <summary>
        ///     Gets or sets the number of unquoted shares outstanding.
        /// </summary>
        /// <value>
        ///     The number of unquoted shares outstanding.
        /// </value>
        [JsonPropertyName("un_quoted_shares_outstanding")]
        public long UnQuotedSharesOutstanding { get; set; }
    }

    /// <summary>
    ///     Represents the profile of a share class.
    /// </summary>
    public class ShareClassProfile
    {
        /// <summary>
        ///     Gets or sets the share class ID.
        /// </summary>
        /// <value>
        ///     The share class ID.
        /// </value>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        ///     Gets or sets the enterprise value.
        /// </summary>
        /// <value>
        ///     The enterprise value.
        /// </value>
        [JsonPropertyName("enterprise_value")]
        public decimal EnterpriseValue { get; set; }

        /// <summary>
        ///     Gets or sets the as of date for the enterprise value.
        /// </summary>
        /// <value>
        ///     The as of date for the enterprise value.
        /// </value>
        [JsonPropertyName("EnterpriseValue.asOfDate")]
        public string EnterpriseValueAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the Market Capitalization of the property.
        /// </summary>
        /// <value>
        ///     The Market Capitalization.
        /// </value>
        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        /// <summary>
        ///     Gets or sets the date representing the market capitalization.
        /// </summary>
        /// <value>
        ///     The market capitalization as of a specific date.
        /// </value>
        [JsonPropertyName("MarketCap.asOfDate")]
        public string MarketCapAsOfDate { get; set; }

        /// <summary>
        ///     The reason for the change in shares.
        /// </summary>
        /// <remarks>
        ///     This property stores the reason for any change in the number of shares.
        /// </remarks>
        /// <value>
        ///     A string indicating the reason for the change in shares.
        /// </value>
        /// <seealso cref="ReasonOfSharesChange" />
        /// <example>
        ///     <code>
        /// var reason = object.ReasonOfSharesChange;
        /// </code>
        /// </example>
        [JsonPropertyName("reasonof_shares_change")]
        public string ReasonOfSharesChange { get; set; }

        /// <summary>
        ///     Gets or sets the reason of shares change as of the specified date.
        /// </summary>
        /// <value>
        ///     The reason of shares change as of the specified date.
        /// </value>
        [JsonPropertyName("ReasonofSharesChange.asOfDate")]
        public string ReasonOfSharesChangeAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the number of shares outstanding for a share class.
        /// </summary>
        [JsonPropertyName("share_class_level_shares_outstanding")]
        public long ShareClassLevelSharesOutstanding { get; set; }

        /// <summary>
        ///     Gets or sets the as-of date for the number of shares outstanding at the share class level.
        /// </summary>
        /// <value>
        ///     The as-of date for the number of shares outstanding at the share class level.
        /// </value>
        [JsonPropertyName("ShareClassLevelSharesOutstanding.asOfDate")]
        public string ShareClassLevelSharesOutstandingAsOfDate { get; set; }

        /// Gets or sets the number of shares outstanding.
        /// /
        [JsonPropertyName("shares_outstanding")]
        public long SharesOutstanding { get; set; }

        /// <summary>
        ///     Gets or sets the date as of which the number of outstanding shares is provided.
        /// </summary>
        /// <value>The date as of which the number of outstanding shares is provided.</value>
        [JsonPropertyName("SharesOutstanding.asOfDate")]
        public string SharesOutstandingAsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the shares outstanding with the balance sheet ending date.
        /// </summary>
        /// <value>
        ///     A string representing the shares outstanding with the balance sheet ending date.
        /// </value>
        [JsonPropertyName("shares_outstanding_with_balance_sheet_ending_date")]
        public string SharesOutstandingWithBalanceSheetEndingDate { get; set; }

        /// <summary>
        ///     The number of shares outstanding with the balance sheet ending on a specific date.
        /// </summary>
        /// <value>
        ///     The date at which the balance sheet is ending.
        /// </value>
        [JsonPropertyName("SharesOutstandingWithBalanceSheetEndingDate.asOfDate")]
        public string SharesOutstandingWithBalanceSheetEndingDateAsOfDate { get; set; }
    }

    /// <summary>
    ///     Represents ownership details of a share.
    /// </summary>
    public class OwnershipDetail
    {
        /// <summary>
        ///     Gets or sets the share class ID.
        /// </summary>
        /// <value>
        ///     The share class ID.
        /// </value>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        ///     Gets or sets the As Of Date property.
        /// </summary>
        /// <value>
        ///     The As Of Date.
        /// </value>
        [JsonPropertyName("as_of_date")]
        public string AsOfDate { get; set; }

        /// <summary>
        ///     Gets or sets the owner ID.
        /// </summary>
        /// <remarks>
        ///     The owner ID represents the unique identifier of the property owner.
        /// </remarks>
        /// <value>
        ///     The owner ID as a string.
        /// </value>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the owner.
        /// </summary>
        /// <value>
        ///     The type of the owner.
        /// </value>
        [JsonPropertyName("owner_type")]
        public string OwnerType { get; set; }

        /// <summary>
        ///     Gets or sets the market value of the property.
        /// </summary>
        /// <value>
        ///     The market value of the property.
        /// </value>
        [JsonPropertyName("market_value")]
        public decimal MarketValue { get; set; }

        /// <summary>
        ///     Gets or sets the number of shares.
        /// </summary>
        /// <value>
        ///     The number of shares.
        /// </value>
        [JsonPropertyName("number_of_shares")]
        public float NumberOfShares { get; set; }

        /// <summary>
        ///     Gets or sets the owner's Central Index Key (CIK).
        /// </summary>
        /// <value>
        ///     The CIK of the owner.
        /// </value>
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
        ///     Gets or sets the share change property.
        /// </summary>
        /// <value>
        ///     The share change.
        /// </value>
        [JsonPropertyName("share_change")]
        public int ShareChange { get; set; }

        /// <summary>
        ///     Represents the status property.
        /// </summary>
        /// /
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    /// <summary>
    ///     The ShareClass class represents a share class of a company.
    /// </summary>
    public class ShareClass
    {
        /// <summary>
        ///     Gets or sets the CompanyId of the property.
        /// </summary>
        /// <value>
        ///     The CompanyId of the property.
        /// </value>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the share class ID.
        /// </summary>
        /// <value>
        ///     The share class ID.
        /// </value>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        ///     Gets or sets the currency id.
        /// </summary>
        /// <value>
        ///     The currency id.
        /// </value>
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        /// <summary>
        ///     Gets or sets the DelistingDate of the property.
        /// </summary>
        /// <value>
        ///     A <see cref="System.String" /> representing the DelistingDate.
        /// </value>
        [JsonPropertyName("delisting_date")]
        public string DelistingDate { get; set; }

        /// <summary>
        ///     Gets or sets the exchange ID.
        /// </summary>
        /// <value>
        ///     The exchange ID.
        /// </value>
        [JsonPropertyName("exchange_id")]
        public string ExchangeId { get; set; }

        /// <summary>
        ///     Gets or sets the IPO date of the property.
        /// </summary>
        /// <value>
        ///     The IPO date, specified as a string.
        /// </value>
        [JsonPropertyName("i_p_o_date")]
        public string IPODate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the object is a depositary receipt.
        /// </summary>
        /// <value><c>true</c> if the object is a depositary receipt; otherwise, <c>false</c>.</value>
        [JsonPropertyName("is_depositary_receipt")]
        public bool IsDepositaryReceipt { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating if the investment is direct.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the investment is direct; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("is_direct_invest")]
        public bool IsDirectInvest { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the dividend is reinvested.
        /// </summary>
        /// <value>
        ///     <c>true</c> if dividend is reinvested; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("is_dividend_reinvest")]
        public bool IsDividendReinvest { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this is the primary share.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this is the primary share; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("is_primary_share")]
        public bool IsPrimaryShare { get; set; }

        /// <summary>
        ///     Gets or sets the MIC (Message Integrity Check) property.
        /// </summary>
        /// <value>
        ///     The value of the MIC (Message Integrity Check) property.
        /// </value>
        [JsonPropertyName("m_i_c")]
        public string MIC { get; set; }

        /// <summary>
        ///     Gets or sets the par value of the property.
        /// </summary>
        /// <value>
        ///     The par value.
        /// </value>
        [JsonPropertyName("par_value")]
        public decimal ParValue { get; set; }

        /// <summary>
        ///     Represents the type of security.
        /// </summary>
        /// <remarks>
        ///     This property is used to specify the type of security.
        /// </remarks>
        /// <value>
        ///     The type of security.
        /// </value>
        [JsonPropertyName("security_type")]
        public string SecurityType { get; set; }

        /// <summary>
        ///     Gets or sets the description of the share class.
        /// </summary>
        /// <value>
        ///     The description of the share class.
        /// </value>
        [JsonPropertyName("share_class_description")]
        public string ShareClassDescription { get; set; }

        /// <summary>
        ///     Gets or sets the share class status.
        /// </summary>
        /// <value>
        ///     The share class status property represents the status of the share class.
        /// </value>
        [JsonPropertyName("share_class_status")]
        public string ShareClassStatus { get; set; }

        /// <summary>
        ///     Gets or sets the symbol of an object.
        /// </summary>
        /// <value>
        ///     The symbol.
        /// </value>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the trading status.
        /// </summary>
        /// <value>
        ///     <c>true</c> if trading is enabled; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("trading_status")]
        public bool TradingStatus { get; set; }
    }
}