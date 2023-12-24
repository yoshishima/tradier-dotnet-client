using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tradier.Client.Helpers
{
    /// <summary>
    ///     A custom JSON converter for converting Unix timestamps to DateTime objects.
    /// </summary>
    public class TimestampConverter : JsonConverter<DateTime>
    {
        /// <summary>
        ///     Reads a <see cref="DateTime" /> value from the JSON using the specified <see cref="Utf8JsonReader" />.
        /// </summary>
        /// <param name="reader">The reader to use for reading the JSON.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions" /> to use for serialization.</param>
        /// <returns>The deserialized <see cref="DateTime" /> value.</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var tt = reader.GetString();
            var t = long.Parse(tt);
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(t).ToLocalTime();
        }

        /// <summary>
        ///     Writes the given DateTime value to the specified Utf8JsonWriter using the specified JsonSerializerOptions.
        /// </summary>
        /// <param name="writer">The Utf8JsonWriter to write to.</param>
        /// <param name="value">The DateTime value to write.</param>
        /// <param name="options">The JsonSerializerOptions to use.</param>
        /// <exception cref="NotImplementedException">This method is not implemented and will throw an exception.</exception>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}