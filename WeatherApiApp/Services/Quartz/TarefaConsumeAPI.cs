using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Data;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    [PersistJobDataAfterExecution]
    public abstract class TarefaConsumeAPI : IJob
    {
        protected readonly ILogger<TarefaConsumeAPI> _logger;
        protected readonly AppDbContext _appDb;
        protected readonly List<Municipio> _municipios;
        protected IClienteApi clienteApi;
        protected readonly Deserializer _deserializer;

        protected TarefaConsumeAPI(ILogger<TarefaConsumeAPI> logger, AppDbContext appDb, Deserializer deserializer)
        {
            _logger = logger;
            _appDb = appDb;
            _deserializer = deserializer;
            _municipios = _appDb.Municipios.ToList();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Iniciando {GetType().Name}!");
            foreach (Municipio municipio in _municipios)
            {
                _logger.LogInformation($"Obtendo previsões para o município: {municipio.Nome}.");
                await Executor<Municipio, Task>(Tarefa, municipio, context);
            }
            _logger.LogInformation("Salvando no banco de dados.");
            await _appDb.SaveChangesAsync(context.CancellationToken);
            _logger.LogInformation($"Tarefa concluída!");
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
