using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.CronJob
{
    public class TarefaUVDiario : CronJobService
    {
        private readonly ApiDb _apiDb;
        private readonly ApiCaller _apiCaller;
        private readonly Deserializer _deserializer;
        private readonly List<Municipio> _municipios;
        private readonly ILogger<TarefaUVDiario> _logger;

        public TarefaUVDiario(IScheduleConfig<TarefaUVDiario> configuracao, ApiDb apiDb, ApiCaller apiCaller, Deserializer deserializer, ILogger<TarefaUVDiario> logger) 
            : base(configuracao.CronExpression, configuracao.TimeZoneInfo)
        {
            _apiDb = apiDb;
            _apiCaller = apiCaller;
            _deserializer = deserializer;
            _municipios = apiDb.ObterTodosMunicipios();
            _logger = logger;
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            try
            {
                string previsaoTexto = "";
                IList<PrevisaoOpenUV> previsoesOpenUV;
                foreach (Municipio municipio in _municipios)
                {
                    int n = 1;
                    previsaoTexto = _apiCaller.RequisicaoOpenUV(municipio);
                    _logger.LogInformation($"Chamada {n} efetuada");
                    _apiDb.SalvarRequisicaoOpenUV(municipio.ID);
                    _logger.LogInformation($"Requisição salva, Município {municipio.Nome}");
                    previsoesOpenUV = _deserializer.ConverterOpenUV(previsaoTexto);
                    _apiDb.SalvarListaPrevisaoOpenUV(previsoesOpenUV);
                    n++;
                }
            }
            catch (System.Net.Http.HttpRequestException ex) // Erro na chamada API.
            {
                _logger.LogError(ex, ex.Message);
                throw new OperationCanceledException(cancellationToken);
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException ex) // Erro ao salvar requisição.
            {
                _logger.LogError(ex, ex.Message);
                throw new OperationCanceledException(cancellationToken);
            }
            return Task.CompletedTask; 
        }
    }
}
