using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Extensions
{
    public class ConversorFusoHorario : JsonConverter<DateTime>
    {
        private string _fusoHorario;
        public ConversorFusoHorario(string fusoHorario) => _fusoHorario = fusoHorario;

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return TimeZoneInfo.ConvertTime(reader.GetDateTime(), TimeZoneInfo.FindSystemTimeZoneById(_fusoHorario));
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
