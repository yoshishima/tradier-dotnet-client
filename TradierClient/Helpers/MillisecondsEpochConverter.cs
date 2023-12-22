using System;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// A custom JSON converter for converting DateTime to and from milliseconds since the Unix epoch.
/// </summary>
public class MillisecondsEpochConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// Represents the epoch timestamp, which is the starting point for measuring time in Unix systems.
    /// The epoch is defined as January 1, 1970, 00:00:00 UTC.
    /// </summary>
    private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Reads a <see cref="DateTime"/> value from the JSON data and converts it from milliseconds to DateTime.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> containing the JSON data.</param>
    /// <param name="typeToConvert">The destination <see cref="Type"/> being converted to.</param>
    /// <param name="options">The serializer options to use.</param>
    /// <returns>The converted <see cref="DateTime"/> value.</returns>
    /// <exception cref="JsonException">Thrown when an error occurs while converting milliseconds to DateTime.</exception>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            long milliseconds = reader.GetInt64();
            return _epoch.AddMilliseconds(milliseconds);
        }
        catch (Exception ex)
        {
            throw new JsonException("Error converting milliseconds to DateTime", ex);
        }
    }

    /// <summary>
    /// Writes a <see cref="DateTime"/> value as the number of milliseconds since the Unix epoch
    /// to a <see cref="Utf8JsonWriter"/> using the specified <see cref="JsonSerializerOptions"/>.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write the value to.</param>
    /// <param name="value">The <see cref="DateTime"/> value to write.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> to use.</param>
    /// <exception cref="JsonException">
    /// Thrown if there was an error converting the <paramref name="value"/> to milliseconds.
    /// </exception>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        try
        {
            long milliseconds = (long)(value.ToUniversalTime() - _epoch).TotalMilliseconds;
            writer.WriteNumberValue(milliseconds);
        }
        catch (Exception ex)
        {
            throw new JsonException("Error converting DateTime to milliseconds", ex);
        }
    }
}
