using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaDiariaW : TarefaConsumeAPI
    {
        public TarefaDiariaW(ILogger<TarefaConsumeAPI> logger, ServicoMunicipio servicoMunicipio, Deserializer deserializer, ClienteOpenWeather openWCaller) : base(logger, servicoMunicipio, deserializer)
        {
            clienteApi = openWCaller;
        }

        protected override async Task Tarefa(Municipio municipio)
        {
            _logger.LogInformation("Chamando OpenWeather API e convertendo a resposta.");
            municipio.PrevisoesDiariasOpenW = new List<PrevisaoDiariaOpenW>
            {
                _deserializer.ConverterDiariaOpenW(await clienteApi.ChamarApiAsync(municipio, "current,minutely,hourly"))
            };
            _logger.LogInformation("Adicionando PrevisaoDiariaOpenW ao rastreamento.");
            foreach (PrevisaoDiariaOpenW previsao in municipio.PrevisoesDiariasOpenW)
            {
                await _sevicoMunicipio.Context.PrevisoesDiariasOpenW.AddAsync(previsao);
            }
            _logger.LogInformation($"PrevisaoDiariaOpenW adicionada!");
        }
    }
}
