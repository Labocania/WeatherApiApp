using Microsoft.Extensions.Logging;
using Quartz;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaClimaWeatherBit : TarefaConsumeAPI
    {
        public TarefaClimaWeatherBit(ILogger<TarefaConsumeAPI> logger, ServicoMunicipio servicoMunicipio, Deserializer deserializer, ClienteWeatherBit weatherBitCaller) : base(logger, servicoMunicipio, deserializer)
        {
            clienteApi = weatherBitCaller;
        }

        protected override Task LidaErroChamada(HttpRequestException ex, IJobExecutionContext context)
        {
            return base.LidaErroChamada(ex, context);
        }

        protected override async Task Tarefa(Municipio municipio)
        {
            _logger.LogInformation("Chamando WeatherBit e convertendo a resposta.");
            municipio.WeatherBits = new List<WeatherBit>
            {
                _deserializer.ConverterWeatherBit(await clienteApi.ChamarApiAsync(municipio))
            };
            _logger.LogInformation("Adicionando WeatherBit ao rastreamento.");
            foreach (WeatherBit previsao in municipio.WeatherBits)
            {
                await _sevicoMunicipio.Context.WeatherBits.AddAsync(previsao);
            }
            _logger.LogInformation($"WeatherBit adicionada!");
        }
    }
}
