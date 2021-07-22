using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaUVDiario : IJob
    {
        private readonly ILogger<TarefaUVDiario> _logger;
        private readonly ApiDb _apiDb;
        private readonly ClienteOpenUV _apiCaller;
        private readonly Deserializer _deserializer;
        private readonly List<Municipio> _municipios;

        public TarefaUVDiario(ILogger<TarefaUVDiario> logger, ApiDb apiDb, ClienteOpenUV apiCaller, Deserializer deserializer)
        {
            _logger = logger;
            _apiDb = apiDb;
            _apiCaller = apiCaller;
            _deserializer = deserializer;
            _municipios = apiDb.ObterTodosMunicipios();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Iniciando TarefaUVDiario");
            string previsaoTexto = "";
            IList<PrevisaoOpenUV> previsoesOpenUV;
            try
            {
                foreach (Municipio municipio in _municipios)
                {
                    previsaoTexto = await _apiCaller.ChamarApiAsync(municipio);
                    _apiDb.SalvarRequisicaoOpenUV(municipio.ID);
                    _logger.LogInformation($"Requisição salva, Município {municipio.Nome}");
                    previsoesOpenUV = _deserializer.ConverterOpenUV(previsaoTexto);
                    _apiDb.SalvarListaPrevisaoOpenUV(previsoesOpenUV);
                }
            }
            catch (System.Net.Http.HttpRequestException ex) // Erro na chamada API.
            {
                _logger.LogError(ex, ex.Message);
                throw new OperationCanceledException(context.CancellationToken);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex) // Erro ao salvar requisição.
            {
                _logger.LogError(ex, ex.Message);
                throw new OperationCanceledException(context.CancellationToken);
            }
        }
    }
}
