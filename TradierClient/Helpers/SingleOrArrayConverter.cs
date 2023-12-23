using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tradier.Client.Helpers
{
    /// <summary>
    /// A custom JSON converter that handles conversion between a single element or an array of elements.
    /// </summary>
    /// <typeparam name="T">The type of elements being converted.</typeparam>
    public class SingleOrArrayConverter<T> : JsonConverter<List<T>>
    {
        /// <summary>
        /// Determines whether the given type can be converted to a list of T.
        /// </summary>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <returns>
        /// <c>true</c> if the given type can be converted to a list of T; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(List<T>);
        }

        /// <summary>
        /// Reads JSON data from the specified Utf8JsonReader and deserializes it to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the JSON data to.</typeparam>
        /// <param name="reader">The Utf8JsonReader from which to read the JSON data.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The JsonSerializerOptions used for deserialization.</param>
        /// <returns>A List of objects deserialized from the JSON data.</returns>
        public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var document = JsonDocument.ParseValue(ref reader))
            {
                if (document.RootElement.ValueKind == JsonValueKind.Array)
                {
                    return JsonSerializer.Deserialize<List<T>>(document.RootElement.GetRawText(), options);
                }

                var item = JsonSerializer.Deserialize<T>(document.RootElement.GetRawText(), options);
                return new List<T> { item };
            }
        }

        /// <summary>
        /// Writes the specified list of values to a JSON writer using the specified options.
        /// </summary>
        /// <typeparam name="T">The type of values in the list.</typeparam>
        /// <param name="writer">The JSON writer to write to.</param>
        /// <param name="value">The list of values to write.</param>
        /// <param name="options">The JSON serializer options to use.</param>
        public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
        {
            if (value.Count == 1)
                JsonSerializer.Serialize(writer, value[0], options);
            else
                JsonSerializer.Serialize(writer, value, options);
        }
    }
}