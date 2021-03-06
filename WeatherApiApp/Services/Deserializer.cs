using System.Collections.Generic;
using System.Text.Json;
using WeatherApiApp.Models;
using WeatherApiApp.Extensions;

namespace WeatherApiApp.Services
{
    public class Deserializer
    {
        public JsonDocument RespostaTotalObjeto { get; private set; }
        private JsonSerializerOptions _opcoes;

        private void ConverterResultados(string respostaTexto)
        {
            RespostaTotalObjeto = JsonDocument.Parse(respostaTexto);
        }

        public IList<PrevisaoOpenUV> ConverterOpenUV(Municipio municipio, string respostaJson)
        {
            ConverterResultados(respostaJson);
            IList<PrevisaoOpenUV> previsao = new List<PrevisaoOpenUV>();
            using (RespostaTotalObjeto)
            {
                _opcoes = new(JsonSerializerDefaults.Web)
                {
                    Converters =
                    {
                        new ConversorFusoHorario((municipio.FusoWin, municipio.FusoIana))
                    }
                };

                foreach (JsonElement resultado in RespostaTotalObjeto.RootElement.GetProperty("result").EnumerateArray())
                {
                    previsao.Add(resultado.ToObject<PrevisaoOpenUV>(_opcoes));
                }
            }
            return previsao;
        }

        public PrevisaoDiariaOpenW ConverterDiariaOpenW(string respostaJson)
        {
            ConverterResultados(respostaJson);
            PrevisaoDiariaOpenW previsao = new PrevisaoDiariaOpenW();
            using (RespostaTotalObjeto) 
            {
                _opcoes = new(JsonSerializerDefaults.Web)
                {
                    Converters =
                    {
                        new UnixEpochDateTimeConverter(RespostaTotalObjeto.RootElement.GetProperty("timezone").GetString())
                    }
                };

                previsao = RespostaTotalObjeto.RootElement.GetProperty("daily")[0].ToObject<PrevisaoDiariaOpenW>(_opcoes);
                if (RespostaTotalObjeto.RootElement.TryGetProperty("alerts", out JsonElement alertas))
                {
                    List<Alerta> listaAlertas = new List<Alerta>();
                    foreach (JsonElement alerta in alertas.EnumerateArray())
                    {
                        listaAlertas.Add(alerta.ToObject<Alerta>(_opcoes));
                    }

                    previsao.Alertas = listaAlertas;
                }
            }           
            return previsao;
        }

        public PrevisaoHoraOpenW ConverterClimaAtual(string respostaJson)
        {
            ConverterResultados(respostaJson);
            PrevisaoHoraOpenW clima = new PrevisaoHoraOpenW();
            using (RespostaTotalObjeto)
            {
                _opcoes = new(JsonSerializerDefaults.Web)
                {
                    Converters =
                    {
                        new UnixEpochDateTimeConverter(RespostaTotalObjeto.RootElement.GetProperty("timezone").GetString())
                    }
                };

                clima = RespostaTotalObjeto.RootElement.GetProperty("hourly")[1].ToObject<PrevisaoHoraOpenW>(_opcoes);
            }
            return clima;
        }

        public WeatherBit ConverterWeatherBit(string respostaJson)
        {
            ConverterResultados(respostaJson);
            WeatherBit weatherBit = new WeatherBit();
            using (RespostaTotalObjeto)
            {
                _opcoes = new(JsonSerializerDefaults.Web)
                {
                    Converters =
                    {
                        new UnixEpochDateTimeConverter(RespostaTotalObjeto.RootElement.GetProperty("data")[0].GetProperty("timezone").GetString())
                    }
                };

                weatherBit = RespostaTotalObjeto.RootElement.GetProperty("data")[0].ToObject<WeatherBit>(_opcoes);
            }

            return weatherBit;
        }
    }

    // Credits: https://stackoverflow.com/a/59047063 User: https://stackoverflow.com/users/3744182/dbc
    // Converte de JsonElement direto para classe padrão em C#.
    public static partial class JsonExtensions
    {
        public static T ToObject<T>(this JsonElement element, JsonSerializerOptions options = null)
        {
            var bufferWriter = new System.Buffers.ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
                element.WriteTo(writer);
            return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
        }

        public static T ToObject<T>(this JsonDocument document, JsonSerializerOptions options = null)
        {
            if (document == null)
                throw new System.ArgumentNullException(nameof(document));
            return document.RootElement.ToObject<T>(options);
        }
    }
}