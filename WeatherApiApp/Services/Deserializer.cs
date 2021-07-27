using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class Deserializer
    {
        public JObject RespostaTotalObjeto { get; private set; }
        private IList<JToken> resultadoParcial;

        private void ConverterResultados(string respostaTexto)
        {
            RespostaTotalObjeto = JObject.Parse(respostaTexto);
        }

        public IList<PrevisaoOpenUV> ConverterOpenUV(string respostaJson)
        {
            ConverterResultados(respostaJson);
            resultadoParcial = RespostaTotalObjeto.SelectTokens("result").Children().ToList();
            IList<PrevisaoOpenUV> resultadoFinal = new List<PrevisaoOpenUV>();
            foreach (JToken resultado in resultadoParcial)
            {
                resultadoFinal.Add(resultado.ToObject<PrevisaoOpenUV>());
            }

            return resultadoFinal;
        }

        //public IList<PrevisaoOpenW> ConverterOpenW(string respostaJson)
    }
}