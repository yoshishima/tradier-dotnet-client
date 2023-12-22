﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    public class CalendarRootobject
    {
        [JsonPropertyName("calendar")] public Calendar Calendar { get; set; }
    }

    public class Calendar
    {
        [JsonPropertyName("month")] public int Month { get; set; }

        [JsonPropertyName("year")] public int Year { get; set; }

        [JsonPropertyName("days")] public Days Days { get; set; }
    }

    public class Days
    {
        [JsonPropertyName("day")] public List<CalendarDay> Day { get; set; }
    }

    public class CalendarDay
    {
        [JsonPropertyName("date")] public string Date { get; set; }

        [JsonPropertyName("status")] public string Status { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("premarket")] public Premarket Premarket { get; set; }

        [JsonPropertyName("open")] public Open Open { get; set; }

        [JsonPropertyName("postmarket")] public Postmarket Postmarket { get; set; }
    }

    public class Premarket
    {
        [JsonPropertyName("start")] public string Start { get; set; }

        [JsonPropertyName("end")] public string End { get; set; }
    }

    public class Open
    {
        [JsonPropertyName("start")] public string Start { get; set; }

        [JsonPropertyName("end")] public string End { get; set; }
    }

    public class Postmarket
    {
        [JsonPropertyName("start")] public string Start { get; set; }

        [JsonPropertyName("end")] public string End { get; set; }
    }
}