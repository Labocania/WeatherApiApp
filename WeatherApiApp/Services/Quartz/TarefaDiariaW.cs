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
    [PersistJobDataAfterExecution]
    public class TarefaDiariaW : IJob
    {
        private readonly ILogger<TarefaDiariaW> _logger;
        private readonly AppDbContext _appDb;
        private readonly ClienteOpenWeather _openWCaller;
        private readonly Deserializer _deserializer;
        private readonly List<Municipio> _municipios;

        public TarefaDiariaW(ILogger<TarefaDiariaW> logger, AppDbContext appDb,ClienteOpenWeather openWCaller, Deserializer deserializer)
        {
            _logger = logger;
            _appDb = appDb;
            _openWCaller = openWCaller;
            _deserializer = deserializer;
            _municipios = _appDb.Municipios.ToList();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Iniciando TarefaDiaria!");
            try
            {
                foreach (Municipio municipio in _municipios)
                {
                    _logger.LogInformation($"Obtendo previsões para o município: {municipio.Nome}.");
                    await TarefaOpenW(municipio, context);
                }
                _logger.LogInformation("Salvando previsões.");
                await _appDb.SaveChangesAsync(context.CancellationToken);
                _logger.LogInformation($"Previsão salva!");
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
                throw new JobExecutionException(ex, false);
            }
        }

        private async Task TarefaOpenW(Municipio municipio, IJobExecutionContext context)
        {
            _logger.LogInformation("Chamando OpenWeather API e convertendo a resposta.");
            municipio.PrevisoesDiariasOpenW = new List<PrevisaoDiariaOpenW>();
            municipio.PrevisoesDiariasOpenW.Add(_deserializer.ConverterDiariaOpenW(await _openWCaller.ChamarApiAsync(municipio, "current,minutely,hourly")));
            _logger.LogInformation("Adicionando PrevisaoDiariaOpenW ao rastreamento.");
            foreach (PrevisaoDiariaOpenW previsao in municipio.PrevisoesDiariasOpenW)
            {
                await _appDb.PrevisoesDiariasOpenW.AddAsync(previsao);
            }
            _logger.LogInformation($"PrevisaoDiariaOpenW adicionada!");
        }
    }
}
