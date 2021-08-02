using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class Deserializer
    {
        public JObject RespostaTotalObjeto { get; private set; }

        private void ConverterResultados(string respostaTexto)
        {
            RespostaTotalObjeto = JObject.Parse(respostaTexto);
        }

        public IList<PrevisaoOpenUV> ConverterOpenUV(string respostaJson)
        {
            ConverterResultados(respostaJson);
            return RespostaTotalObjeto.SelectToken("result").ToObject<IList<PrevisaoOpenUV>>();
        }

        public PrevisaoDiariaOpenW ConverterDiariaOpenW(string respostaJson)
        {
            ConverterResultados(respostaJson);
            PrevisaoDiariaOpenW previsao = RespostaTotalObjeto["daily"][0].ToObject<PrevisaoDiariaOpenW>();
            if (RespostaTotalObjeto["alerts"] != null)
            {
                List<Alerta> alertas = new List<Alerta>();
                foreach (var alerta in RespostaTotalObjeto["alerts"])
                {
                    alertas.Add(alerta.ToObject<Alerta>());
                }
                previsao.Alertas = alertas;
            }            
            return previsao;
        }

        public ClimaAtualOpenW ConverterClimaAtual(string respostaJson)
        {
            ClimaAtualOpenW clima = new ClimaAtualOpenW();
            System.Text.Json.JsonSerializerOptions opcoes = new(System.Text.Json.JsonSerializerDefaults.Web);
            using (System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.Parse(respostaJson))
            {
                clima = document.RootElement.GetProperty("current").ToObject<ClimaAtualOpenW>(opcoes);
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
        public static T ToObject<T>(this System.Text.Json.JsonElement element, System.Text.Json.JsonSerializerOptions options = null)
        {
            var bufferWriter = new System.Buffers.ArrayBufferWriter<byte>();
            using (var writer = new System.Text.Json.Utf8JsonWriter(bufferWriter))
                element.WriteTo(writer);
            return System.Text.Json.JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
        }

        public static T ToObject<T>(this System.Text.Json.JsonDocument document, System.Text.Json.JsonSerializerOptions options = null)
        {
            if (document == null)
                throw new System.ArgumentNullException(nameof(document));
            return document.RootElement.ToObject<T>(options);
        }
    }
}