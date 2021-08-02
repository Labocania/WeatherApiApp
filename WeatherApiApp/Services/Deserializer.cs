using System.Collections.Generic;
using System.Text.Json;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class Deserializer
    {
        public JsonDocument RespostaTotalObjeto { get; private set; }
        private JsonSerializerOptions _opcoes = new(JsonSerializerDefaults.Web);

        private void ConverterResultados(string respostaTexto)
        {
            RespostaTotalObjeto = JsonDocument.Parse(respostaTexto);
        }

        public IList<PrevisaoOpenUV> ConverterOpenUV(string respostaJson)
        {
            ConverterResultados(respostaJson);
            IList<PrevisaoOpenUV> previsao = new List<PrevisaoOpenUV>();
            using (RespostaTotalObjeto)
            {
                foreach (JsonElement resultado in RespostaTotalObjeto.RootElement.GetProperty("result").EnumerateArray())
                {
                    previsao.Add(resultado.ToObject<PrevisaoOpenUV>());
                }
            }
            return previsao;
        }

        public PrevisaoDiariaOpenW ConverterDiariaOpenW(string respostaJson)
        {
            ConverterResultados(respostaJson);
            PrevisaoDiariaOpenW previsao = new PrevisaoDiariaOpenW();
            previsao.Alertas = new List<Alerta>();
            using (RespostaTotalObjeto) 
            {
                previsao = RespostaTotalObjeto.RootElement.GetProperty("daily")[0].ToObject<PrevisaoDiariaOpenW>(_opcoes);
                if (RespostaTotalObjeto.RootElement.TryGetProperty("alerts", out JsonElement alertas))
                {
                    foreach (JsonElement alerta in alertas.EnumerateArray())
                    {
                        previsao.Alertas.Add(alerta.ToObject<Alerta>(_opcoes));
                    }
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
                clima = RespostaTotalObjeto.RootElement.GetProperty("current").ToObject<ClimaAtualOpenW>(_opcoes);
            }
            return clima;
        }

        /*  Implementação antiga de ConverterOpenUV
         *  IList<JToken> resultadoParcial = RespostaTotalObjeto.SelectTokens("result").Children().ToList();
            IList<PrevisaoOpenUV> resultadoFinal = new List<PrevisaoOpenUV>();
            foreach (JToken resultado in resultadoParcial)
            {
                resultadoFinal.Add(resultado.ToObject<PrevisaoOpenUV>());
            }

            return resultadoFinal;*/
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