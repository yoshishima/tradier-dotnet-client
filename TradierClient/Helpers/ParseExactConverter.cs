using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tradier.Client.Helpers
{
    /// <summary>
    /// Class ParseExactConverter is a custom JsonConverter used to parse and write DateTime values in a specific format.
    /// </summary>
    /// <typeparam name="DateTime">The type of DateTime.</typeparam>
    public class ParseExactConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// Reads a DateTime value from the given Utf8JsonReader.
        /// </summary>
        /// <param name="reader">The Utf8JsonReader to read from.</param>
        /// <param name="typeToConvert">The Type to convert the DateTime value to.</param>
        /// <param name="options">The JsonSerializerOptions.</param>
        /// <returns>The parsed DateTime value.</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return default;
            }

            var dateString = reader.GetString();
            return DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Writes the specified DateTime value to the Utf8JsonWriter using the specified format.
        /// </summary>
        /// <param name="writer">The Utf8JsonWriter to write to.</param>
        /// <param name="value">The DateTime value to write.</param>
        /// <param name="options">The JsonSerializerOptions to use for writing.</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}