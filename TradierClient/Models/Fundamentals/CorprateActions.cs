using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    public class CorprateActions

    {
        [JsonPropertyName("request")] public string Request { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("results")] public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("tables")] public Tables Tables { get; set; }
    }

    public class Tables
    {
        [JsonPropertyName("mergers_and_acquisitions")]
        public List<MergersAndAcquisitions> MergersAndAcquisitions { get; set; }

        [JsonPropertyName("stock_splits")] public Dictionary<string, StockSplit> StockSplits { get; set; }
    }

    public class MergersAndAcquisitions
    {
        [JsonPropertyName("acquired_company_id")]
        public string AcquiredCompanyId { get; set; }

        [JsonPropertyName("parent_company_id")]
        public string ParentCompanyId { get; set; }

        [JsonPropertyName("cash_amount")] public double CashAmount { get; set; }

        [JsonPropertyName("currency_id")] public string CurrencyId { get; set; }

        [JsonPropertyName("effective_date")] public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("notes")] public string Notes { get; set; }
    }

    public class StockSplit
    {
        [JsonPropertyName("share_class_id")] public string ShareClassId { get; set; }

        [JsonPropertyName("ex_date")] public DateTime ExDate { get; set; }

        [JsonPropertyName("adjustment_factor")]
        public double AdjustmentFactor { get; set; }

        [JsonPropertyName("split_from")] public double SplitFrom { get; set; }

        [JsonPropertyName("split_to")] public double SplitTo { get; set; }

        [JsonPropertyName("split_type")] public string SplitType { get; set; }
    }