using Microsoft.Extensions.Logging;
using Quartz;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaDiariaUV : TarefaConsumeAPI
    {
        public TarefaDiariaUV(ILogger<TarefaConsumeAPI> logger, ServicoMunicipio servicoMunicipio, Deserializer deserializer, ClienteOpenUV openUVCaller) : base(logger, servicoMunicipio, deserializer)
        {
            clienteApi = openUVCaller;
        }

        protected override Task LidaErroChamada(HttpRequestException ex, IJobExecutionContext context)
        {
            if (ex.StatusCode.Value.Equals(System.Net.HttpStatusCode.Forbidden))
            {
                throw new JobExecutionException(ex, false);
            }
            else
            {
                return base.LidaErroChamada(ex, context);
            }
        }

        protected override async Task Tarefa(Municipio municipio)
        {
            _logger.LogInformation("Chamando OpenUV API e convertendo a resposta.");
            municipio.PrevisoesOpenUV = _deserializer.ConverterOpenUV(municipio, await clienteApi.ChamarApiAsync(municipio));
            _logger.LogInformation("Adicionando PrevisaoOpenUV ao rastreamento.");
            foreach (PrevisaoOpenUV previsao in municipio.PrevisoesOpenUV)
            {
                await _sevicoMunicipio.Context.PrevisoesOpenUV.AddAsync(previsao);
            }
            _logger.LogInformation($"PrevisaoOpenUV adicionada!");
        }
    }
}
