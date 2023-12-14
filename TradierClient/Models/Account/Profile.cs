using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tradier.Client.Helpers;

namespace Tradier.Client.Models.Account
{
    public class ProfileRootObject
    {
        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }
    }

    public class Profile
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("account")]
        [JsonConverter(typeof(SingleOrArrayConverter<Account>))]
        public List<Account> Account { get; set; }
    }

    public class Account
    {
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("classification")]
        public string Classification { get; set; }

        [JsonPropertyName("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonPropertyName("day_trader")]
        public bool DayTrader { get; set; }

        [JsonPropertyName("option_level")]
        public int OptionLevel { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("last_update_date")]
        public DateTime LastUpdateDate { get; set; }
    }
}
