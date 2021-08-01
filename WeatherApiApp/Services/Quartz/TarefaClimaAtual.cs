using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiApp.Data;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaClimaAtual : IJob
    {
        private readonly ILogger<TarefaDiariaW> _logger;
        private readonly AppDbContext _appDb;
        private readonly ClienteOpenWeather _openWCaller;
        private readonly Deserializer _deserializer;
        private readonly List<Municipio> _municipios;

        public TarefaClimaAtual(ILogger<TarefaDiariaW> logger, AppDbContext appDb, ClienteOpenWeather openWCaller, Deserializer deserializer)
        {
            _logger = logger;
            _appDb = appDb;
            _openWCaller = openWCaller;
            _deserializer = deserializer;
            _municipios = _appDb.Municipios.ToList();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Iniciando TarefaClimaAtual!");
            try
            {
                foreach (Municipio municipio in _municipios)
                {
                    _logger.LogInformation($"Obtendo clima para o município: {municipio.Nome}.");
                    await Tarefa(municipio, context);
                }
                _logger.LogInformation("Salvando clima.");
                await _appDb.SaveChangesAsync(context.CancellationToken);
                _logger.LogInformation($"Clima salvo!");
            }
            catch (System.Net.Http.HttpRequestException ex) // Erro na chamada API.
            {
                _logger.LogError(ex, ex.Message);
                ITrigger trigger = TriggerBuilder
                    .Create()
                    .WithIdentity(typeof(TarefaDiariaW).Name + "-trigger")
                    .StartAt(DateTime.Now.AddMinutes(5))
                    .Build();
                await context.Scheduler.RescheduleJob(context.Trigger.Key, trigger);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new JobExecutionException(ex, true);
            }
        }

        private async Task Tarefa(Municipio municipio, IJobExecutionContext context)
        {
            _logger.LogInformation("Chamando OpenWeather API e convertendo a resposta.");
            municipio.ClimasAtuaisOpenW = new List<ClimaAtualOpenW>();
            municipio.ClimasAtuaisOpenW.Add(_deserializer.ConverterClimaAtual(await _openWCaller.ChamarApiAsync(municipio, "minutely,hourly,daily,alerts")));
            _logger.LogInformation("Adicionando ClimaAtualOpenW ao rastreamento.");
            foreach (ClimaAtualOpenW clima in municipio.ClimasAtuaisOpenW)
            {
                await _appDb.ClimasAtuaisOpenW.AddAsync(clima);
            }
            _logger.LogInformation($"ClimaAtualOpenW adicionado!");
        }
    }
}
