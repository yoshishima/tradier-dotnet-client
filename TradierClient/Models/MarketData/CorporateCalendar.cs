using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    ///     Represents the root object for the corporate calendar data.
    /// </summary>
    public class CorporateCalendarRootObject
    {
        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        /// <value>
        ///     The request.
        /// </value>
        [JsonPropertyName("request")]
        public string Request { get; set; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the list of corporate calendar data results.
        /// </summary>
        /// <value>
        ///     The list of corporate calendar data results.
        /// </value>
        [JsonPropertyName("results")]
        public List<CorporateCalendarData> Results { get; set; }
    }

    /// <summary>
    ///     Represents the data for a corporate calendar.
    /// </summary>
    public class CorporateCalendarData
    {
        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <remarks>
        ///     This property is used to specify the type of the property.
        /// </remarks>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the Id of the property.
        /// </summary>
        /// <value>
        ///     The Id of the property.
        /// </value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the corporate calendar tables.
        /// </summary>
        [JsonPropertyName("tables")]
        public CorporateCalendarTable Tables { get; set; }
    }

    /// <summary>
    ///     Represents a corporate calendar table.
    /// </summary>
    public class CorporateCalendarTable
    {
        /// <summary>
        ///     Gets or sets the list of corporate calendars.
        /// </summary>
        [JsonPropertyName("corporate_calendars")]
        public List<CorporateCalendar> CorporateCalendars { get; set; }
    }

    /// <summary>
    ///     Represents a corporate calendar event.
    /// </summary>
    public class CorporateCalendar
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
        ///     Gets or sets the begin date and time.
        /// </summary>
        /// <value>
        ///     The begin date and time.
        /// </value>
        [JsonPropertyName("begin_date_time")]
        public DateTime BeginDateTime { get; set; }

        /// <summary>
        ///     Gets or sets the end date and time.
        /// </summary>
        /// <value>
        ///     The end date and time.
        /// </value>
        /// <remarks>
        ///     This property represents the date and time when an event or task ends.
        /// </remarks>
        [JsonPropertyName("end_date_time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        ///     Gets or sets the EventType property.
        /// </summary>
        /// <value>
        ///     The EventType property represents the type of the event.
        /// </value>
        [JsonPropertyName("event_type")]
        public int EventType { get; set; }

        /// <summary>
        ///     Gets or sets the estimated date for the next event.
        /// </summary>
        /// <value>
        ///     The estimated date for the next event.
        /// </value>
        [JsonPropertyName("estimated_date_for_next_event")]
        public DateTime EstimatedDateForNextEvent { get; set; }

        /// <summary>
        ///     Gets or sets the event property.
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }

        /// <summary>
        ///     Gets or sets the event fiscal year.
        /// </summary>
        /// <value>
        ///     The event fiscal year.
        /// </value>
        [JsonPropertyName("event_fiscal_year")]
        public int EventFiscalYear { get; set; }

        /// <summary>
        ///     Gets or sets the status of the event.
        /// </summary>
        /// <value>
        ///     The event status.
        /// </value>
        [JsonPropertyName("event_status")]
        public string EventStatus { get; set; }

        /// <summary>
        ///     The time zone property specifies the time zone of an object.
        /// </summary>
        /// <value>The time zone.</value>
        [JsonPropertyName("time_zone")]
        public DateTime TimeZone { get; set; }
    }
}