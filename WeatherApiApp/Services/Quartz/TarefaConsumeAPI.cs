using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    [PersistJobDataAfterExecution]
    public abstract class TarefaConsumeAPI : IJob
    {
        protected readonly ILogger<TarefaConsumeAPI> _logger;
        protected readonly ServicoMunicipio _sevicoMunicipio;
        protected IClienteApi clienteApi;
        protected readonly Deserializer _deserializer;

        protected TarefaConsumeAPI(ILogger<TarefaConsumeAPI> logger, ServicoMunicipio servicoMunicipio, Deserializer deserializer)
        {
            _logger = logger;
            _sevicoMunicipio = servicoMunicipio;
            _deserializer = deserializer;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Iniciando {GetType().Name}!");
            foreach (Municipio municipio in _sevicoMunicipio.Municipios)
            {
                _logger.LogInformation($"Obtendo previsões para o município: {municipio.Nome}.");
                await Executor<Municipio, Task>(Tarefa, municipio, context);
            }
            _logger.LogInformation("Salvando no banco de dados.");
            await _sevicoMunicipio.Context.SaveChangesAsync(context.CancellationToken);
            _logger.LogInformation($"{GetType().Name} concluída!");
        }

        private TResult Executor<T,TResult>(Func<T, TResult> acao, T arg, IJobExecutionContext context)
        {
            try
            {
                return acao(arg);
            }
            catch (HttpRequestException ex)
            {         
                LidaErroChamada(ex, context).Wait();
            }
            catch (Exception ex)
            {
                LidaErroGeral(ex);
            }
            return default;
        }

        protected virtual async Task LidaErroChamada(HttpRequestException ex, IJobExecutionContext context)
        {
            _logger.LogError(ex, ex.Message);

            if (context.RefireCount >= 3)
            {
                throw new JobExecutionException(ex, false);
            }

            ITrigger trigger = TriggerBuilder
                    .Create()
                    .WithIdentity($"{GetType().Name}-trigger")
                    .StartAt(DateTime.Now.AddMinutes(5))
                    .Build();
            await context.Scheduler.RescheduleJob(context.Trigger.Key, trigger);
        }

        protected virtual void LidaErroGeral(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new JobExecutionException(ex, false);
        }

        protected virtual Task Tarefa(Municipio municipio)
        {
            return default;
        }
    }
}
