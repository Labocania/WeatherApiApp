using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaPrevisaoHoraOpenW : TarefaConsumeAPI
    {
        public TarefaPrevisaoHoraOpenW(ILogger<TarefaConsumeAPI> logger, ServicoMunicipio servicoMunicipio, Deserializer deserializer, ClienteOpenWeather openWCaller) : base(logger, servicoMunicipio, deserializer)
        {
            clienteApi = openWCaller;
        }

        protected override async Task Tarefa(Municipio municipio)
        {
            _logger.LogInformation("Chamando OpenWeather API e convertendo a resposta.");
            municipio.ClimasAtuaisOpenW = new List<PrevisaoHoraOpenW>
            {
                _deserializer.ConverterClimaAtual(await clienteApi.ChamarApiAsync(municipio, "current,minutely,daily,alerts"))
            };
            _logger.LogInformation("Adicionando PrevisaoHoraOpenW ao rastreamento.");
            foreach (PrevisaoHoraOpenW clima in municipio.ClimasAtuaisOpenW)
            {
                await _sevicoMunicipio.Context.ClimasAtuaisOpenW.AddAsync(clima);
            }
            _logger.LogInformation($"PrevisaoHoraOpenW adicionado!");
        }
    }
}
