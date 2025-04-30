using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    /// <summary>
    ///     Represents the root object for corporate actions data.
    /// </summary>
    public class CorporateActionsRootObject
    {
        /// <summary>
        ///     Gets or sets the request information.
        /// </summary>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        ///     Gets or sets the type of the data.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the list of corporate action results.
        /// </summary>
        [JsonPropertyName("results")]
        public List<CorporateActionResult> Results { get; set; }
    }

    /// <summary>
    ///     Represents a corporate action result for a specific company.
    /// </summary>
    public class CorporateActionResult
    {
        /// <summary>
        ///     Gets or sets the type of the corporate action result.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the company.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the tables containing the corporate action data.
        /// </summary>
        [JsonPropertyName("tables")]
        public CorporateActionTables Tables { get; set; }
    }

    /// <summary>
    ///     Represents the corporate action tables for a company.
    /// </summary>
    public class CorporateActionTables
    {
        /// <summary>
        ///     Gets or sets the list of corporate actions.
        /// </summary>
        [JsonPropertyName("corporate_actions")]
        public List<CorporateAction> CorporateActions { get; set; }
    }

    /// <summary>
    ///     Represents a corporate action for a company.
    /// </summary>
    public class CorporateAction
    {
        /// <summary>
        ///     Gets or sets the ID of the company.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the share class ID.
        /// </summary>
        [JsonPropertyName("share_class_id")]
        public string ShareClassId { get; set; }

        /// <summary>
        ///     Gets or sets the original action ID.
        /// </summary>
        [JsonPropertyName("original_action_id")]
        public string OriginalActionId { get; set; }

        /// <summary>
        ///     Gets or sets the action ID.
        /// </summary>
        [JsonPropertyName("action_id")]
        public string ActionId { get; set; }

        /// <summary>
        ///     Gets or sets the announcement date.
        /// </summary>
        [JsonPropertyName("announcement_date")]
        public DateTime? AnnouncementDate { get; set; }

        /// <summary>
        ///     Gets or sets the effective date.
        /// </summary>
        [JsonPropertyName("effective_date")]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        ///     Gets or sets the record date.
        /// </summary>
        [JsonPropertyName("record_date")]
        public DateTime? RecordDate { get; set; }

        /// <summary>
        ///     Gets or sets the payable date.
        /// </summary>
        [JsonPropertyName("payable_date")]
        public DateTime? PayableDate { get; set; }

        /// <summary>
        ///     Gets or sets the action type.
        /// </summary>
        [JsonPropertyName("action_type")]
        public string ActionType { get; set; }

        /// <summary>
        ///     Gets or sets the action type ID.
        /// </summary>
        [JsonPropertyName("action_type_id")]
        public string ActionTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the action sub-type.
        /// </summary>
        [JsonPropertyName("action_sub_type")]
        public string ActionSubType { get; set; }

        /// <summary>
        ///     Gets or sets the action status.
        /// </summary>
        [JsonPropertyName("action_status")]
        public string ActionStatus { get; set; }

        /// <summary>
        ///     Gets or sets the action status ID.
        /// </summary>
        [JsonPropertyName("action_status_id")]
        public string ActionStatusId { get; set; }

        /// <summary>
        ///     Gets or sets the currency ID.
        /// </summary>
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the extended description.
        /// </summary>
        [JsonPropertyName("extended_description")]
        public string ExtendedDescription { get; set; }

        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        [JsonPropertyName("created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the updated date.
        /// </summary>
        [JsonPropertyName("updated_date")]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the former value.
        /// </summary>
        [JsonPropertyName("former_value")]
        public decimal? FormerValue { get; set; }

        /// <summary>
        ///     Gets or sets the current value.
        /// </summary>
        [JsonPropertyName("current_value")]
        public decimal? CurrentValue { get; set; }

        /// <summary>
        ///     Gets or sets the adjustment factor.
        /// </summary>
        [JsonPropertyName("adjustment_factor")]
        public decimal? AdjustmentFactor { get; set; }

        /// <summary>
        ///     Gets or sets the action factor.
        /// </summary>
        [JsonPropertyName("action_factor")]
        public decimal? ActionFactor { get; set; }
    }
}