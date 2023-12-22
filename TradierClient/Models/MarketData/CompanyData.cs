using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    public class CompanyDataRootObject
    {
        public CompanyDataRootObject()
        {
            Results = new List<CompanyData>();
        }

        [JsonPropertyName("request")] public string Request { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("results")] public IEnumerable<CompanyData> Results { get; set; }
    }

    public class CompanyData
    {
        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("tables")] public CompanyDataTable Tables { get; set; }
    }

    public class CompanyDataTable
    {
        [JsonPropertyName("company_profile")] public CompanyProfile CompanyProfile { get; set; }

        [JsonPropertyName("asset_classification")]
        public AssetClassification AssetClassification { get; set; }

        [JsonPropertyName("historical_asset_classification")]
        public HistoricalAssetClassification HistoricalAssetClassification { get; set; }

        [JsonPropertyName("long_descriptions")]
        public string LongDescriptions { get; set; }
    }

    public class CompanyProfile
    {
        [JsonPropertyName("company_id")] public string CompanyId { get; set; }

        [JsonPropertyName("average_employee_number")]
        public int AverageEmployeeNumber { get; set; }

        [JsonPropertyName("contact_email")] public string ComtactEmail { get; set; }

        [JsonPropertyName("is_head_office_same_with_registered_office_flag")]
        public bool IsHeadOfficeSameWithRegisteredOfficeFlag { get; set; }

        [JsonPropertyName("total_employee_number")]
        public int TotalEmployeeNumber { get; set; }

        [JsonPropertyName("TotalEmployeeNumber.asOfDate")]
        public DateTime TotalEmployeeNumberAsOfDate { get; set; }

        [JsonPropertyName("headquarter")] public CompanyHeadquarter Headquarter { get; set; }
    }

    public class CompanyHeadquarter
    {
        [JsonPropertyName("address_line1")] public string AddressLine1 { get; set; }

        [JsonPropertyName("city")] public string City { get; set; }

        [JsonPropertyName("country")] public string Country { get; set; }

        [JsonPropertyName("fax")] public string Fax { get; set; }

        [JsonPropertyName("homepage")] public string Homepage { get; set; }

        [JsonPropertyName("phone")] public string Phone { get; set; }

        [JsonPropertyName("postal_code")] public string PostalCode { get; set; }

        [JsonPropertyName("province")] public string Province { get; set; }
    }

    public abstract class AssetClassificationBase
    {
        [JsonPropertyName("company_id")] public string CompanyId { get; set; }

        [JsonPropertyName("financial_health_grade")]
        public string FinancialHealthGrade { get; set; }

        [JsonPropertyName("morningstar_economy_sphere_code")]
        public int MorningstarEconomySphereCode { get; set; }

        [JsonPropertyName("morningstar_industry_code")]
        public int MorningstarIndustryCode { get; set; }

        [JsonPropertyName("morningstar_industry_group_code")]
        public int MorningstarIndustryGroupCode { get; set; }

        [JsonPropertyName("morningstar_sector_code")]
        public int MorningstarSectorCode { get; set; }

        [JsonPropertyName("profitability_grade")]
        public string ProfitabilityGrade { get; set; }

        [JsonPropertyName("size_score")] public float SizeScore { get; set; }

        [JsonPropertyName("stock_type")] public int StockType { get; set; }

        [JsonPropertyName("style_box")] public int StyleBox { get; set; }

        [JsonPropertyName("style_score")] public float StyleScore { get; set; }

        [JsonPropertyName("value_score")] public float ValueScore { get; set; }
    }

    public class AssetClassification : AssetClassificationBase
    {
        [JsonPropertyName("c_a_n_n_a_i_c_s")] public int Cannaics { get; set; }

        [JsonPropertyName("FinancialHealthGrade.asOfDate")]
        public DateTime FinancialHealthGradeAsOfDate { get; set; }

        [JsonPropertyName("growth_grade")] public string GrowthGrade { get; set; }

        [JsonPropertyName("GrowthGrade.asOfDate")]
        public DateTime GrowthGradeAsOfDate { get; set; }

        [JsonPropertyName("n_a_c_e")] public float Nace { get; set; }

        [JsonPropertyName("n_a_i_c_s")] public int Naics { get; set; }

        [JsonPropertyName("ProfitabilityGrade.asOfDate")]
        public DateTime ProfitabilityGradeAsOfDate { get; set; }

        [JsonPropertyName("s_i_c")] public int Sic { get; set; }

        [JsonPropertyName("StockType.asOfDate")]
        public DateTime StockTypeAsOfDate { get; set; }

        [JsonPropertyName("StyleBox.asOfDate")]
        public DateTime StyleBoxAsOfDate { get; set; }
    }

    public class HistoricalAssetClassification : AssetClassificationBase
    {
        [JsonPropertyName("as_of_date")] public DateTime AsOfDate { get; set; }
    }
}