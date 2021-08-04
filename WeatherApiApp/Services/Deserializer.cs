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

        public IList<PrevisaoOpenUV> ConverterOpenUV(string fusoHorario, string respostaJson)
        {
            ConverterResultados(respostaJson);
            IList<PrevisaoOpenUV> previsao = new List<PrevisaoOpenUV>();
            using (RespostaTotalObjeto)
            {
                _opcoes = new(JsonSerializerDefaults.Web)
                {
                    Converters =
                    {
                        new ConversorFusoHorario(fusoHorario)
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

        public ClimaAtualOpenW ConverterClimaAtual(string respostaJson)
        {
            ConverterResultados(respostaJson);
            ClimaAtualOpenW clima = new ClimaAtualOpenW();
            using (RespostaTotalObjeto)
            {
                _opcoes = new(JsonSerializerDefaults.Web)
                {
                    Converters =
                    {
                        new UnixEpochDateTimeConverter(RespostaTotalObjeto.RootElement.GetProperty("timezone").GetString())
                    }
                };

                clima = RespostaTotalObjeto.RootElement.GetProperty("current").ToObject<ClimaAtualOpenW>(_opcoes);
            }
            return clima;
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