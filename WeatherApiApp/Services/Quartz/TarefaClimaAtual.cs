using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaClimaAtual : TarefaConsumeAPI
    {
        public TarefaClimaAtual(ILogger<TarefaConsumeAPI> logger, ServicoMunicipio servicoMunicipio, Deserializer deserializer, ClienteOpenWeather openWCaller) : base(logger, servicoMunicipio, deserializer)
        {
            clienteApi = openWCaller;
        }

        protected override async Task Tarefa(Municipio municipio)
        {
            _logger.LogInformation("Chamando OpenWeather API e convertendo a resposta.");
            municipio.ClimasAtuaisOpenW = new List<ClimaAtualOpenW>
            {
                _deserializer.ConverterClimaAtual(await clienteApi.ChamarApiAsync(municipio, "minutely,hourly,daily,alerts"))
            };
            _logger.LogInformation("Adicionando ClimaAtualOpenW ao rastreamento.");
            foreach (ClimaAtualOpenW clima in municipio.ClimasAtuaisOpenW)
            {
                await _sevicoMunicipio.Context.ClimasAtuaisOpenW.AddAsync(clima);
            }
            _logger.LogInformation($"ClimaAtualOpenW adicionado!");
        }
    }
}
