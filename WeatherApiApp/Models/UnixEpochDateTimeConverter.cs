using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    // Crédito: https://stackoverflow.com/questions/19971494/how-to-deserialize-a-unix-timestamp-μs-to-a-datetime-from-json/19972214#19972214
    public class UnixEpochDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.UnixEpoch.AddSeconds(reader.GetInt64()).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue((value - DateTime.UnixEpoch).TotalMilliseconds + "000");

        }
    }
}
