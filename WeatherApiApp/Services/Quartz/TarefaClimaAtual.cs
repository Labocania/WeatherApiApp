using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApiApp.Data;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaClimaAtual : TarefaConsumeAPI
    {
        public TarefaClimaAtual(ILogger<TarefaConsumeAPI> logger, AppDbContext appDb, Deserializer deserializer, ClienteOpenWeather openWCaller) : base(logger, appDb, deserializer)
        {
            clienteApi = openWCaller;
        }

        protected override async Task Tarefa(Municipio municipio)
        {
            _logger.LogInformation("Chamando OpenWeather API e convertendo a resposta.");
            municipio.ClimasAtuaisOpenW = new List<ClimaAtualOpenW>();
            municipio.ClimasAtuaisOpenW.Add(_deserializer.ConverterClimaAtual(await clienteApi.ChamarApiAsync(municipio, "minutely,hourly,daily,alerts")));
            _logger.LogInformation("Adicionando ClimaAtualOpenW ao rastreamento.");
            foreach (ClimaAtualOpenW clima in municipio.ClimasAtuaisOpenW)
            {
                await _appDb.ClimasAtuaisOpenW.AddAsync(clima);
            }
            _logger.LogInformation($"ClimaAtualOpenW adicionado!");
        }
    }
}
