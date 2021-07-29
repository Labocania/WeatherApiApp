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
    public class TarefaDiariaUV : IJob
    {
        private readonly ILogger<TarefaDiariaUV> _logger;
        private readonly AppDbContext _appDb;
        private readonly ClienteOpenUV _openUVCaller;        
        private readonly Deserializer _deserializer;
        private readonly List<Municipio> _municipios;

        public TarefaDiariaUV(ILogger<TarefaDiariaUV> logger, AppDbContext appDb, ClienteOpenUV openUVCaller, Deserializer deserializer)
        {
            _logger = logger;
            _appDb = appDb;
            _openUVCaller = openUVCaller;
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
                    await TarefaOpenUV(municipio, context);
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

        private async Task TarefaOpenUV(Municipio municipio, IJobExecutionContext context)
        {
            _logger.LogInformation("Chamando OpenUV API e convertendo a resposta.");
            municipio.PrevisoesOpenUV = _deserializer.ConverterOpenUV(await _openUVCaller.ChamarApiAsync(municipio));
            _logger.LogInformation("Adicionando PrevisaoOpenUV ao rastreamento.");
            foreach (PrevisaoOpenUV previsao in municipio.PrevisoesOpenUV)
            {
                await _appDb.PrevisoesOpenUV.AddAsync(previsao);
            }
            _logger.LogInformation($"PrevisaoOpenUV adicionada!");
        }
    }
}
