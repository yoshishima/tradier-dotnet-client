using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    /// <summary>
    /// Represents the root object for dividends data.
    /// </summary>
    public class DividendsRootObject
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
        /// Gets or sets the list of dividend results.
        /// </summary>
        [JsonPropertyName("results")]
        public List<DividendResult> Results { get; set; }
    }

    /// <summary>
    /// Represents a dividend result for a specific company.
    /// </summary>
    public class DividendResult
    {
        /// <summary>
        /// Gets or sets the type of the dividend result.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tables containing the dividend data.
        /// </summary>
        [JsonPropertyName("tables")]
        public DividendTables Tables { get; set; }
    }

    /// <summary>
    /// Represents the dividend tables for a company.
    /// </summary>
    public class DividendTables
    {
        /// <summary>
        /// Gets or sets the list of cash dividends.
        /// </summary>
        [JsonPropertyName("cash_dividends")]
        public List<CashDividend> CashDividends { get; set; }
    }

    /// <summary>
    /// Represents a cash dividend for a company.
    /// </summary>
    public class CashDividend
    {
        /// <summary>
        /// Gets or sets the share class ID.
        /// </summary>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        /// Gets or sets the type of dividend.
        /// </summary>
        [JsonPropertyName("dividend_type")]
        public string DividendType { get; set; }

        /// <summary>
        /// Gets or sets the ex-dividend date.
        /// </summary>
        [JsonPropertyName("ex_date")]
        public DateTime ExDate { get; set; }

        /// <summary>
        /// Gets or sets the dividend amount.
        /// </summary>
        [JsonPropertyName("cash_amount")]
        public decimal CashAmount { get; set; }

        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        [JsonPropertyName("currency_i_d")]
        public string CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the declaration date.
        /// </summary>
        [JsonPropertyName("declaration_date")]
        public DateTime DeclarationDate { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the dividend.
        /// </summary>
        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }

        /// <summary>
        /// Gets or sets the pay date.
        /// </summary>
        [JsonPropertyName("pay_date")]
        public DateTime PayDate { get; set; }

        /// <summary>
        /// Gets or sets the record date.
        /// </summary>
        [JsonPropertyName("record_date")]
        public DateTime RecordDate { get; set; }
    }
}