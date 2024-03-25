using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tradier.Client.Models.Dividends
{
    /// <summary>
    /// Represents a collection of dividend data.
    /// </summary>
    public partial class Dividends
    {
        /// <summary>
        /// Represents a request for dividends information.
        /// </summary>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        /// Represents the type of the dividends.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Represents the results of a dividends request
        /// </summary>
        [JsonPropertyName("results")]
        public List<divResult> Results { get; set; }
    }

    /// <summary>
    /// Represents a single dividend result.
    /// </summary>
    public partial class divResult
    {
        /// <summary>
        /// Represents the dividend type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Represents the identifier of a dividend.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Represents the dividends information for a particular request.
        /// </summary>
        [JsonPropertyName("tables")]
        public divTables Tables { get; set; }
    }

    /// <summary>
    /// Represents the dividend information for a particular stock or symbol.
    /// </summary>
    public partial class divTables

    {
        /// <summary>
        /// Represents a cash dividend for a share class.
        /// </summary>
        [JsonPropertyName("cash_dividends")]
        public List<CashDividend> CashDividends { get; set; }

    }

    /// <summary>
    /// Represents a cash dividend.
    /// </summary>
    public partial class CashDividend
    {
        /// <summary>
        /// Gets or sets the share class identifier.
        /// </summary>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        /// Represents the type of dividend.
        /// </summary>
        [JsonPropertyName("dividend_type")]
        public string DividendType { get; set; }

        /// <summary>
        /// Represents the ex-dividend date of a cash dividend.
        /// </summary>
        [JsonPropertyName("ex_date")]
        public DateTimeOffset ExDate { get; set; }

        /// <summary>
        /// Represents a cash dividend amount.
        /// </summary>
        [JsonPropertyName("cash_amount")]
        public double CashAmount { get; set; }

        /// <summary>
        /// Represents the currency of a cash dividend.
        /// </summary>
        [JsonPropertyName("currency_i_d")]
        public string CurrencyID { get; set; }

        /// <summary>
        /// Gets or sets the declaration date of a cash dividend.
        /// </summary>
        /// <value>The declaration date of the cash dividend.</value>
        [JsonPropertyName("declaration_date")]
        public DateTimeOffset DeclarationDate { get; set; }

        /// <summary>
        /// Represents the frequency of a cash dividend payment.
        /// </summary>
        [JsonPropertyName("frequency")]
        public long Frequency { get; set; }

        /// <summary>
        /// Represents the pay date of a cash dividend.
        /// </summary>
        [JsonPropertyName("pay_date")]
        public DateTimeOffset PayDate { get; set; }

        /// <summary>
        /// Gets or sets the record date of the cash dividend.
        /// </summary>
        /// <value>The record date.</value>
        [JsonPropertyName("record_date")]
        public DateTimeOffset RecordDate { get; set; }
    }

    /// <summary>
    /// Represents the currency identifier for US Dollars (USD).
    /// </summary>
    public enum CurrencyID
    {
        /// <
        Usd };

    /// <summary>
    /// Represents the dividend type "Cd".
    /// </summary>
    public enum DividendType
    {
        /// <
        Cd,

        /// <
        Sc };

    /// <summary>
    /// Represents the Share Class ID for the enum member "The0P000000Gy" in the Dividends namespace.
    /// </summary>
    public enum ShareClassId
    {
        /// <
        The0P000000Gy,

        /// <summary>
        /// Represents the share class ID "The0P000001Ik" of the ShareClassId enum.
        /// </summary>
        The0P000001Ik
    };
}
