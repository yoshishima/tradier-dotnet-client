using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.MarketData
{
    public class CorporateCalendarRootObject
    {
        [JsonPropertyName("request")]
        public string Request { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("results")]
        public List<CorporateCalendarData> Results { get; set; }
    }

    public class CorporateCalendarData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("tables")]
        public CorporateCalendarTable Tables { get; set; }
    }

    public class CorporateCalendarTable
    {
        [JsonPropertyName("corporate_calendars")]
        public List<CorporateCalendar> CorporateCalendars { get; set; }
    }

    public class CorporateCalendar
    {
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        [JsonPropertyName("begin_date_time")]
        public DateTime BeginDateTime { get; set; }

        [JsonPropertyName("end_date_time")]
        public DateTime EndDateTime { get; set; }

        [JsonPropertyName("event_type")]
        public int EventType { get; set; }

        [JsonPropertyName("estimated_date_for_next_event")]
        public DateTime EstimatedDateForNextEvent { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("event_fiscal_year")]
        public int EventFiscalYear { get; set; }

        [JsonPropertyName("event_status")]
        public string EventStatus { get; set; }

        [JsonPropertyName("time_zone")]
        public DateTime TimeZone { get; set; }
    }
}
