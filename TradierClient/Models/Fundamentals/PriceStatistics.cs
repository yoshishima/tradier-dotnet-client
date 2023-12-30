#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tradier.Client.Models.Fundamentals
{
    internal class RootPriceStatistics
    {
        public enum Id
        {
            The0P0001Mkrd,
            The0Pdxf1V399
        }

        public partial class Temperatures
        {
            [JsonPropertyName("request")] public string Request { get; set; }

            [JsonPropertyName("type")] public string Type { get; set; }

            [JsonPropertyName("results")] public Result[] Results { get; set; }
        }

        public class Result
        {
            [JsonPropertyName("type")] public string Type { get; set; }

            [JsonPropertyName("id")] public Id Id { get; set; }

            [JsonPropertyName("tables")] public Tables Tables { get; set; }
        }

        public class Tables
        {
            [JsonPropertyName("price_statistics")] public PriceStatistics PriceStatistics { get; set; }

            [JsonPropertyName("trailing_returns")] public Dictionary<string, Period30_D> TrailingReturns { get; set; }
        }

        public class PriceStatistics
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("period_30d")]
            public Period30_D Period30D { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("period_60d")]
            public Period30_D Period60D { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("period_90d")]
            public Period30_D Period90D { get; set; }

            [JsonPropertyName("period_1y")] public Period1Y Period1Y { get; set; }
        }

        public class Period1Y
        {
            [JsonPropertyName("share_class_id")] public Id ShareClassId { get; set; }

            [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

            [JsonPropertyName("period")] public string Period { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("high_price")]
            public double? HighPrice { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("low_price")]
            public double? LowPrice { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("arithmetic_mean")]
            public double? ArithmeticMean { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("best3_month_total_return")]
            public double? Best3MonthTotalReturn { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("standard_deviation")]
            public double? StandardDeviation { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("worst3_month_total_return")]
            public double? Worst3MonthTotalReturn { get; set; }
        }

        public class Period30_D
        {
            [JsonPropertyName("share_class_id")] public Id ShareClassId { get; set; }

            [JsonPropertyName("as_of_date")] public DateTimeOffset AsOfDate { get; set; }

            [JsonPropertyName("period")] public string Period { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("average_volume")]
            public long? AverageVolume { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("total_return")]
            public double? TotalReturn { get; set; }
        }

        public partial class Temperatures
        {
            public static Temperatures[] FromJson(string json)
            {
                return JsonSerializer.Deserialize<Temperatures[]>(json, QuickType.Converter.Settings);
            }
        }

        public static class Serialize
        {
            public static string ToJson(this Temperatures[] self)
            {
                return JsonSerializer.Serialize(self, QuickType.Converter.Settings);
            }
        }

        internal static class Converter
        {
            public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
            {
                Converters =
                {
                    IdConverter.Singleton,
                    new DateOnlyConverter(),
                    new TimeOnlyConverter(),
                    IsoDateTimeOffsetConverter.Singleton
                }
            };
        }

        internal class IdConverter : JsonConverter<Id>
        {
            public static readonly IdConverter Singleton = new IdConverter();

            public override bool CanConvert(Type t)
            {
                return t == typeof(Id);
            }

            public override Id Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                switch (value)
                {
                    case "0P0001MKRD":
                        return Id.The0P0001Mkrd;
                    case "0PDXF1V399":
                        return Id.The0Pdxf1V399;
                }

                throw new Exception("Cannot unmarshal type Id");
            }

            public override void Write(Utf8JsonWriter writer, Id value, JsonSerializerOptions options)
            {
                switch (value)
                {
                    case Id.The0P0001Mkrd:
                        JsonSerializer.Serialize(writer, "0P0001MKRD", options);
                        return;
                    case Id.The0Pdxf1V399:
                        JsonSerializer.Serialize(writer, "0PDXF1V399", options);
                        return;
                }

                throw new Exception("Cannot marshal type Id");
            }
        }

        public class DateOnlyConverter : JsonConverter<DateOnly>
        {
            private readonly string serializationFormat;

            public DateOnlyConverter() : this(null)
            {
            }

            public DateOnlyConverter(string? serializationFormat)
            {
                this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
            }

            public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                return DateOnly.Parse(value!);
            }

            public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(serializationFormat));
            }
        }

        public class TimeOnlyConverter : JsonConverter<TimeOnly>
        {
            private readonly string serializationFormat;

            public TimeOnlyConverter() : this(null)
            {
            }

            public TimeOnlyConverter(string? serializationFormat)
            {
                this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
            }

            public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                return TimeOnly.Parse(value!);
            }

            public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(serializationFormat));
            }
        }

        internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
        {
            private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";


            public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
            private CultureInfo? _culture;
            private string? _dateTimeFormat;

            public DateTimeStyles DateTimeStyles { get; set; } = DateTimeStyles.RoundtripKind;

            public string? DateTimeFormat
            {
                get => _dateTimeFormat ?? string.Empty;
                set => _dateTimeFormat = string.IsNullOrEmpty(value) ? null : value;
            }

            public CultureInfo Culture
            {
                get => _culture ?? CultureInfo.CurrentCulture;
                set => _culture = value;
            }

            public override bool CanConvert(Type t)
            {
                return t == typeof(DateTimeOffset);
            }

            public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
            {
                string text;


                if ((DateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                    || (DateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                    value = value.ToUniversalTime();

                text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

                writer.WriteStringValue(text);
            }

            public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert,
                JsonSerializerOptions options)
            {
                var dateText = reader.GetString();

                if (string.IsNullOrEmpty(dateText) == false)
                {
                    if (!string.IsNullOrEmpty(_dateTimeFormat))
                        return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, DateTimeStyles);
                    return DateTimeOffset.Parse(dateText, Culture, DateTimeStyles);
                }

                return default;
            }
        }
    }
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603
}