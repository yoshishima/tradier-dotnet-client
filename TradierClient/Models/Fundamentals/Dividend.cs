using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    public class Dividend
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
        [JsonPropertyName("cash_dividends")] public List<CashDividend> CashDividends { get; set; }
    }

    public class CashDividend
    {
        [JsonPropertyName("share_class_id")] public string ShareClassId { get; set; }

        [JsonPropertyName("dividend_type")] public string DividendType { get; set; }

        [JsonPropertyName("ex_date")] public DateTime ExDate { get; set; }

        [JsonPropertyName("cash_amount")] public decimal CashAmount { get; set; }

        [JsonPropertyName("currency_i_d")] public string CurrencyId { get; set; }

        [JsonPropertyName("declaration_date")] public DateTime DeclarationDate { get; set; }

        [JsonPropertyName("frequency")] public int Frequency { get; set; }

        [JsonPropertyName("pay_date")] public DateTime PayDate { get; set; }

        [JsonPropertyName("record_date")] public DateTime RecordDate { get; set; }
    }