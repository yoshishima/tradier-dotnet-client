using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    /// Represents the root object containing company data.
    /// </summary>
    public class CompanyDataRootObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDataRootObject"/> class.
        /// </summary>
        public CompanyDataRootObject()
        {
            Results = new List<CompanyData>();
        }

        /// <summary>
        /// Gets or sets the request property.
        /// </summary>
        [JsonPropertyName("request")] public string Request { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        [JsonPropertyName("type")] public string Type { get; set; }

        /// <summary>
        /// Gets or sets the collection of company data results.
        /// </summary>
        /// <value>
        /// The collection of company data results.
        /// </value>
        [JsonPropertyName("results")] public IEnumerable<CompanyData> Results { get; set; }
    }

    /// <summary>
    /// Represents company-specific data.
    /// </summary>
    public class CompanyData
    {
        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the ID of the property.
        /// </summary>
        /// <value>
        /// A string representing the ID of the property.
        /// </value>
        [JsonPropertyName("id")] public string Id { get; set; }

        /// <summary>
        /// Gets or sets the company data tables.
        /// </summary>
        /// <value>
        /// The company data tables.
        /// </value>
        [JsonPropertyName("tables")] public CompanyDataTable Tables { get; set; }
    }

    /// <summary>
    /// Represents a data table that contains company-related information.
    /// </summary>
    public class CompanyDataTable
    {
        /// <summary>
        /// Represents the company profile of a property.
        /// </summary>
        [JsonPropertyName("company_profile")] public CompanyProfile CompanyProfile { get; set; }

        /// <summary>
        /// Gets or sets the asset classification.
        /// </summary>
        /// <value>
        /// The asset classification.
        /// </value>
        [JsonPropertyName("asset_classification")]
        public AssetClassification AssetClassification { get; set; }

        /// <summary>
        /// Represents the historical asset classification.
        /// </summary>
        [JsonPropertyName("historical_asset_classification")]
        public HistoricalAssetClassification HistoricalAssetClassification { get; set; }

        /// <summary>
        /// Gets or sets the long descriptions.
        /// </summary>
        [JsonPropertyName("long_descriptions")]
        public string LongDescriptions { get; set; }
    }

    /// <summary>
    /// Represents the profile of a company.
    /// </summary>
    public class CompanyProfile
    {
        /// <summary>
        /// Gets or sets the CompanyId of the property.
        /// </summary>
        /// <value>
        /// The CompanyId is a string property representing the unique identifier of the company.
        /// </value>
        [JsonPropertyName("company_id")] public string CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the average number of employees.
        /// </summary>
        /// <value>
        /// The average number of employees.
        /// </value>
        [JsonPropertyName("average_employee_number")]
        public int AverageEmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        /// <value>
        /// The contact email.
        /// </value>
        [JsonPropertyName("contact_email")] public string ComtactEmail { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the head office is same as the registered office.
        /// </summary>
        /// <value>
        /// <c>true</c> if the head office is same as the registered office; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("is_head_office_same_with_registered_office_flag")]
        public bool IsHeadOfficeSameWithRegisteredOfficeFlag { get; set; }

        /// <summary>
        /// Gets or sets the total employee number.
        /// </summary>
        [JsonPropertyName("total_employee_number")]
        public int TotalEmployeeNumber { get; set; }

        /// <summary>
        /// Represents the date when the total number of employees was recorded.
        /// </summary>
        [JsonPropertyName("TotalEmployeeNumber.asOfDate")]
        public DateTime TotalEmployeeNumberAsOfDate { get; set; }

        /// <summary>
        /// Gets or sets the headquarter of the company.
        /// </summary>
        /// <value>
        /// The headquarter of the company.
        /// </value>
        [JsonPropertyName("headquarter")] public CompanyHeadquarter Headquarter { get; set; }
    }

    /// <summary>
    /// Represents a company headquarters.
    /// </summary>
    public class CompanyHeadquarter
    {
        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        /// <value>
        /// The first line of the address.
        /// </value>
        [JsonPropertyName("address_line1")] public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the city of an object.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [JsonPropertyName("city")] public string City { get; set; }

        /// <summary>
        /// Represents the country of a person.
        /// </summary>
        /// <value>
        /// The country, as a string.
        /// </value>
        [JsonPropertyName("country")] public string Country { get; set; }

        /// <summary>
        /// Gets or sets the fax property.
        /// </summary>
        /// <value>
        /// The fax number.
        /// </value>
        [JsonPropertyName("fax")] public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the homepage URL for the property.
        /// </summary>
        /// <value>
        /// A string representing the homepage URL for the property.
        /// </value>
        [JsonPropertyName("homepage")] public string Homepage { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [JsonPropertyName("phone")] public string Phone { get; set; }

        /// Gets or sets the postal code.
        /// @JsonPropertyName("postal_code")
        /// /
        [JsonPropertyName("postal_code")] public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the province of the property.
        /// </summary>
        /// <value>
        /// The name of the province.
        /// </value>
        [JsonPropertyName("province")] public string Province { get; set; }
    }

    /// <summary>
    /// Represents the base class for asset classifications.
    /// </summary>
    public abstract class AssetClassificationBase
    {
        /// <summary>
        /// The unique identifier of a company.
        /// </summary>
        /// <remarks>
        /// This property represents the company_id property in the JSON.
        /// </remarks>
        [JsonPropertyName("company_id")] public string CompanyId { get; set; }

        [JsonPropertyName("financial_health_grade")]
        public string FinancialHealthGrade { get; set; }

        /// <summary>
        /// Represents the Morningstar Economy Sphere Code.
        /// </summary>
        /// <value>
        /// The code indicating the economic sphere.
        /// </value>
        [JsonPropertyName("morningstar_economy_sphere_code")]
        public int MorningstarEconomySphereCode { get; set; }

        /// <summary>
        /// Gets or sets the Morningstar Industry Code.
        /// </summary>
        /// <value>
        /// The Morningstar Industry Code.
        /// </value>
        [JsonPropertyName("morningstar_industry_code")]
        public int MorningstarIndustryCode { get; set; }

        /// <summary>
        /// Gets or sets the Morningstar industry group code.
        /// </summary>
        /// <value>
        /// The Morningstar industry group code.
        /// </value>
        [JsonPropertyName("morningstar_industry_group_code")]
        public int MorningstarIndustryGroupCode { get; set; }

        /// <summary>
        /// Gets or sets the Morningstar sector code.
        /// </summary>
        /// <value>
        /// The Morningstar sector code.
        /// </value>
        [JsonPropertyName("morningstar_sector_code")]
        public int MorningstarSectorCode { get; set; }

        /// <summary>
        /// Gets or sets the profitability grade for a property.
        /// </summary>
        /// <value>
        /// The profitability grade.
        /// </value>
        [JsonPropertyName("profitability_grade")]
        public string ProfitabilityGrade { get; set; }

        /// <summary>
        /// Gets or sets the size score of an object.
        /// </summary>
        /// <remarks>
        /// The size score represents the numerical value of the size of an object.
        /// </remarks>
        [JsonPropertyName("size_score")] public float SizeScore { get; set; }

        /// <summary>
        /// Gets or sets the stock type.
        /// </summary>
        [JsonPropertyName("stock_type")] public int StockType { get; set; }

        /// <summary>
        /// Gets or sets the style box property.
        /// </summary>
        /// <value>
        /// The style box.
        /// </value>
        [JsonPropertyName("style_box")] public int StyleBox { get; set; }

        /// <summary>
        /// Gets or sets the style score.
        /// </summary>
        [JsonPropertyName("style_score")] public float StyleScore { get; set; }

        /// <summary>
        /// Gets or sets the value score.
        /// </summary>
        /// <remarks>
        /// This property represents the value score for a certain entity.
        /// The value score is a float value indicating the score of the entity in terms of its value.
        /// </remarks>
        [JsonPropertyName("value_score")] public float ValueScore { get; set; }
    }

    /// The AssetClassification class represents the classification of an asset.
    /// It extends the AssetClassificationBase class.
    /// /
    public class AssetClassification : AssetClassificationBase
    {
        /// <summary>
        /// Gets or sets the value of Cannaics.
        /// </summary>
        [JsonPropertyName("c_a_n_n_a_i_c_s")] public int Cannaics { get; set; }

        /// <summary>
        /// Gets or sets the date on which the financial health grade was determined.
        /// </summary>
        /// <remarks>
        /// This property represents the date when the financial health grade was assessed.
        /// </remarks>
        [JsonPropertyName("FinancialHealthGrade.asOfDate")]
        public DateTime FinancialHealthGradeAsOfDate { get; set; }

        /// <summary>
        /// Gets or sets the growth grade property.
        /// </summary>
        [JsonPropertyName("growth_grade")] public string GrowthGrade { get; set; }

        /// <summary>
        /// Gets or sets the as-of date for the growth grade.
        /// </summary>
        /// <value>
        /// The as-of date for the growth grade.
        /// </value>
        [JsonPropertyName("GrowthGrade.asOfDate")]
        public DateTime GrowthGradeAsOfDate { get; set; }

        /// <summary>
        /// Gets or sets the Nace property.
        /// </summary>
        /// <value>
        /// The Nace property.
        /// </value>
        [JsonPropertyName("n_a_c_e")] public float Nace { get; set; }

        /// <summary>
        /// This property represents the NAICS (North American Industry Classification System) code.
        /// </summary>
        /// <value>
        /// The NAICS code.
        /// </value>
        [JsonPropertyName("n_a_i_c_s")] public int Naics { get; set; }

        /// <summary>
        /// Gets or sets the profitability grade as of the specified date.
        /// </summary>
        /// <value>
        /// The profitability grade as of the specified date.
        /// </value>
        [JsonPropertyName("ProfitabilityGrade.asOfDate")]
        public DateTime ProfitabilityGradeAsOfDate { get; set; }

        /// <summary>
        /// Gets or sets the Sic property.
        /// </summary>
        /// <value>
        /// The Sic property.
        /// </value>
        [JsonPropertyName("s_i_c")] public int Sic { get; set; }

        /// <summary>
        /// Gets or sets the as-of date for the stock type.
        /// </summary>
        /// <remarks>
        /// This property represents the date when the stock type was last updated or confirmed.
        /// </remarks>
        /// <value>
        /// The as-of date for the stock type.
        /// </value>
        [JsonPropertyName("StockType.asOfDate")]
        public DateTime StockTypeAsOfDate { get; set; }

        /// <summary>
        /// Gets or sets the as-of date for the style box.
        /// </summary>
        /// <remarks>
        /// This property represents the date at which the style box is applicable.
        /// </remarks>
        /// <value>
        /// The as-of date for the style box.
        /// </value>
        [JsonPropertyName("StyleBox.asOfDate")]
        public DateTime StyleBoxAsOfDate { get; set; }
    }

    /// <summary>
    /// Represents a historical asset classification.
    /// </summary>
    public class HistoricalAssetClassification : AssetClassificationBase
    {
        /// <summary>
        /// Represents the date at which the information is valid or applicable.
        /// </summary>
        /// <remarks>
        /// This is a property that stores the date value using the <see cref="DateTime"/> data type.
        /// Please note that this property is decorated with the <see cref="JsonPropertyNameAttribute"/> attribute,
        /// which indicates that it will be serialized/deserialized using the name "as_of_date".
        /// </remarks>
        [JsonPropertyName("as_of_date")] public DateTime AsOfDate { get; set; }
    }
}