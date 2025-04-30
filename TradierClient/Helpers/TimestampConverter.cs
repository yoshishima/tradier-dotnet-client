using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tradier.Client.Helpers
{
    /// <summary>
    ///     Converts between Unix timestamp (seconds since epoch) and .NET DateTime objects.
    /// </summary>
    public class TimestampConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime _epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///     Reads and converts the JSON to a DateTime.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The converted DateTime value.</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                // Read the JSON number (Unix timestamp in seconds)
                var unixTimeStamp = reader.GetInt64();

                // Convert Unix timestamp to DateTime
                return _epochStart.AddSeconds(unixTimeStamp);
            }

            throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }

        /// <summary>
        ///     Writes a DateTime as JSON (Unix timestamp).
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // Convert DateTime to Unix timestamp (seconds since epoch)
            var unixTimeStamp = (long)(value.ToUniversalTime() - _epochStart).TotalSeconds;

            // Write the timestamp as a JSON number
            writer.WriteNumberValue(unixTimeStamp);
        }
    }
}