using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.MarketData
{
    /// <summary>
    /// Represents a root object for a calendar.
    /// </summary>
    public class CalendarRootobject
    {
        /// <summary>
        /// Gets or sets the <see cref="Calendar"/> object.
        /// </summary>
        /// <value>
        /// The calendar.
        /// </value>
        [JsonPropertyName("calendar")] public Calendar Calendar { get; set; }
    }

    /// <summary>
    /// Represents a calendar for a specific month and year.
    /// </summary>
    public class Calendar
    {
        /// <summary>
        /// Gets or sets the month value.
        /// </summary>
        /// <value>
        /// The month value.
        /// </value>
        [JsonPropertyName("month")] public int Month { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        [JsonPropertyName("year")] public int Year { get; set; }

        /// <summary>
        /// Gets or sets the number of days.
        /// </summary>
        [JsonPropertyName("days")] public Days Days { get; set; }
    }

    /// <summary>
    /// Represents a collection of calendar days.
    /// </summary>
    public class Days
    {
        /// <summary>
        /// Gets or sets the list of calendar days.
        /// </summary>
        [JsonPropertyName("day")] public List<CalendarDay> Day { get; set; }
    }

    /// <summary>
    /// Represents a calendar day.
    /// </summary>
    public class CalendarDay
    {
        /// <summary>
        /// Gets or sets the date value.
        /// </summary>
        [JsonPropertyName("date")] public string Date { get; set; }

        /// <summary>
        /// Gets or sets the status of the property.
        /// </summary>
        /// <value>
        /// The status of the property.
        /// </value>
        [JsonPropertyName("status")] public string Status { get; set; }

        /// <summary>
        /// Gets or sets the description of the property.
        /// </summary>
        /// <value>The description.</value>
        [JsonPropertyName("description")] public string Description { get; set; }

        /// Gets or sets the premarket details.
        /// /
        [JsonPropertyName("premarket")] public Premarket Premarket { get; set; }

        /// <summary>
        /// Gets or sets the value for the "open" property.
        /// </summary>
        /// <value>The value for the "open" property.</value>
        [JsonPropertyName("open")] public Open Open { get; set; }

        /// <summary>
        /// Gets or sets the Postmarket information.
        /// </summary>
        /// <value>
        /// The Postmarket information.
        /// </value>
        [JsonPropertyName("postmarket")] public Postmarket Postmarket { get; set; }
    }

    /// <summary>
    /// Represents a premarket time period.
    /// </summary>
    public class Premarket
    {
        /// <summary>
        /// Gets or sets the value of the Start property.
        /// </summary>
        /// <value>
        /// The value of the Start property.
        /// </value>
        [JsonPropertyName("start")] public string Start { get; set; }

        /// <summary>
        /// Gets or sets the value of the "end" property.
        /// </summary>
        /// <value>
        /// The value of the "end" property.
        /// </value>
        [JsonPropertyName("end")] public string End { get; set; }
    }

    /// <summary>
    /// Represents a time interval range.
    /// </summary>
    public class Open
    {
        /// <summary>
        /// Gets or sets the value of the Start property.
        /// </summary>
        /// <remarks>
        /// This property represents the start value in a specific format.
        /// </remarks>
        /// <value>
        /// A string representing the start value.
        /// </value>
        [JsonPropertyName("start")] public string Start { get; set; }

        /// <summary>
        /// Gets or sets the value of the "end" property.
        /// </summary>
        [JsonPropertyName("end")] public string End { get; set; }
    }

    /// <summary>
    /// Represents a Postmarket object.
    /// </summary>
    public class Postmarket
    {
        /// <summary>
        /// Gets or sets the value of the Start property.
        /// </summary>
        [JsonPropertyName("start")] public string Start { get; set; }

        /// <summary>
        /// Gets or sets the value of the property End.
        /// </summary>
        /// <value>
        /// The value of the property End.
        /// </value>
        [JsonPropertyName("end")] public string End { get; set; }
    }
}