using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Extensions
{
    public class ConversorFusoHorario : JsonConverter<DateTime>
    {
        private (string fusoWin, string fusoIana) _fusoHorario;
        public ConversorFusoHorario((string fusoWin, string fusoIana) fusoHorario) => _fusoHorario = fusoHorario;

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TimeZoneInfo fuso = TimeZoneInfo.GetSystemTimeZones().Any(x => x.Id == _fusoHorario.fusoWin)
                ? TimeZoneInfo.FindSystemTimeZoneById(_fusoHorario.fusoWin)
                : TimeZoneInfo.FindSystemTimeZoneById(_fusoHorario.fusoIana);
            return TimeZoneInfo.ConvertTime(reader.GetDateTime(), fuso);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
