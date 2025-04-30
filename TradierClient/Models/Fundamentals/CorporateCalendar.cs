using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    /// <summary>
    ///     Represents the root object for corporate calendars data.
    /// </summary>
    public class CorporateCalendarsRootObject
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
        ///     Gets or sets the list of corporate calendar results.
        /// </summary>
        [JsonPropertyName("results")]
        public List<CorporateCalendarResult> Results { get; set; }
    }

    /// <summary>
    ///     Represents a corporate calendar result for a specific company.
    /// </summary>
    public class CorporateCalendarResult
    {
        /// <summary>
        ///     Gets or sets the type of the calendar result.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the company.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the tables containing the calendar data.
        /// </summary>
        [JsonPropertyName("tables")]
        public CorporateCalendarTables Tables { get; set; }
    }

    /// <summary>
    ///     Represents the corporate calendar tables for a company.
    /// </summary>
    public class CorporateCalendarTables
    {
        /// <summary>
        ///     Gets or sets the list of corporate calendars.
        /// </summary>
        [JsonPropertyName("corporate_calendars")]
        public List<CorporateCalendarEvent> CorporateCalendars { get; set; }
    }

    /// <summary>
    ///     Represents a corporate calendar event for a company.
    /// </summary>
    public class CorporateCalendarEvent
    {
        /// <summary>
        ///     Gets or sets the ID of the company.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        ///     Gets or sets the start date and time of the event.
        /// </summary>
        [JsonPropertyName("begin_date_time")]
        public DateTime? BeginDateTime { get; set; }

        /// <summary>
        ///     Gets or sets the end date and time of the event.
        /// </summary>
        [JsonPropertyName("end_date_time")]
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        ///     Gets or sets the type of event.
        /// </summary>
        [JsonPropertyName("event_type")]
        public string EventType { get; set; }

        /// <summary>
        ///     Gets or sets the numeric ID for the event type.
        /// </summary>
        [JsonPropertyName("event_type_id")]
        public int? EventTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the estimated date for the next event.
        /// </summary>
        [JsonPropertyName("estimated_date_for_next_event")]
        public DateTime? EstimatedDateForNextEvent { get; set; }

        /// <summary>
        ///     Gets or sets the event description.
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }

        /// <summary>
        ///     Gets or sets the fiscal year of the event.
        /// </summary>
        [JsonPropertyName("event_fiscal_year")]
        public int? EventFiscalYear { get; set; }

        /// <summary>
        ///     Gets or sets the fiscal quarter of the event.
        /// </summary>
        [JsonPropertyName("event_fiscal_quarter")]
        public int? EventFiscalQuarter { get; set; }

        /// <summary>
        ///     Gets or sets the status of the event.
        /// </summary>
        [JsonPropertyName("event_status")]
        public string EventStatus { get; set; }

        /// <summary>
        ///     Gets or sets the ID for the event status.
        /// </summary>
        [JsonPropertyName("event_status_id")]
        public int? EventStatusId { get; set; }

        /// <summary>
        ///     Gets or sets the time zone of the event.
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        ///     Gets or sets additional notes about the event.
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        /// <summary>
        ///     Gets or sets the link to more information about the event.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}