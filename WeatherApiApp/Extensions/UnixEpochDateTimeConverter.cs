using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using TimeZoneConverter;

namespace WeatherApiApp.Extensions
{
    // Crédito: https://stackoverflow.com/a/63884990
    public class UnixEpochDateTimeConverter : JsonConverter<DateTime>
    {
        private string _timeZone;
        public UnixEpochDateTimeConverter(string timeZone) => _timeZone = timeZone;

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TimeZoneInfo fuso = TimeZoneInfo.GetSystemTimeZones().Any(x => x.Id == _timeZone)
                ? TimeZoneInfo.FindSystemTimeZoneById(_timeZone)
                : TimeZoneInfo.FindSystemTimeZoneById(TZConvert.IanaToWindows(_timeZone));

            return TimeZoneInfo.ConvertTime(DateTime.UnixEpoch.AddSeconds(reader.GetInt64()), fuso);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue((value - DateTime.UnixEpoch).TotalMilliseconds + "000");

        }
    }
}
