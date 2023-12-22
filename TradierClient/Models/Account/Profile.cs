using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Account
{
    /// <summary>
    ///     Represents the root object of a profile.
    /// </summary>
    public class ProfileRootObject
    {
        /// <summary>
        ///     Gets or sets the profile property.
        /// </summary>
        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }
    }

    /// <summary>
    ///     A class representing a profile.
    /// </summary>
    public class Profile
    {
        /// <summary>
        ///     Gets or sets the Id of the property.
        /// </summary>
        /// <value>
        ///     The Id of the property.
        /// </value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Represents the Account property.
        /// </summary>
        [JsonPropertyName("account")]
        [JsonConverter(typeof(SingleOrArrayConverter<Account>))]
        public List<Account> Account { get; set; }
    }

    /// <summary>
    ///     Represents an account.
    /// </summary>
    public class Account
    {
        /// <summary>
        ///     Gets or sets the account number.
        /// </summary>
        /// <value>
        ///     The account number.
        /// </value>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        ///     Gets or sets the classification of the property.
        /// </summary>
        /// <value>
        ///     The classification string.
        /// </value>
        [JsonPropertyName("classification")]
        public string Classification { get; set; }

        /// <summary>
        ///     Gets or sets the date and time when the property was created.
        /// </summary>
        /// <value>
        ///     The date and time when the property was created.
        /// </value>
        /// <remarks>
        ///     This property is annotated with the [JsonPropertyName("date_created")] attribute to specify the JSON property name
        ///     for this property when serialized.
        /// </remarks>
        [JsonPropertyName("date_created")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the person is a day trader.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the person is a day trader; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("day_trader")]
        public bool DayTrader { get; set; }

        /// <summary>
        ///     Represents the option level for a property.
        /// </summary>
        /// <value>
        ///     The option level as an integer.
        /// </value>
        [JsonPropertyName("option_level")]
        public int OptionLevel { get; set; }

        /// <summary>
        ///     Gets or sets the Status of the property.
        /// </summary>
        /// <remarks>
        ///     The status represents the current state of the property.
        /// </remarks>
        /// <value>A string representing the status of the property.</value>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>
        ///     The type of the property.
        /// </value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the LastUpdateDate property.
        /// </summary>
        /// <value>
        ///     The date and time when the object was last updated.
        /// </value>
        /// <remarks>
        ///     This property is decorated with the JsonPropertyName attribute
        ///     and represents the "last_update_date" property in the JSON structure.
        /// </remarks>
        [JsonPropertyName("last_update_date")]
        public DateTime LastUpdateDate { get; set; }
    }
}