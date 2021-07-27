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
            return RespostaTotalObjeto.ToObject<PrevisaoDiariaOpenW>();
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
}