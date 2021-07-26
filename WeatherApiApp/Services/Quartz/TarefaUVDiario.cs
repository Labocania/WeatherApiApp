﻿using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiApp.Data;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services.Quartz
{
    public class TarefaUVDiario : IJob
    {
        private readonly ILogger<TarefaUVDiario> _logger;
        private readonly AppDbContext _appDb;
        private readonly ClienteOpenUV _apiCaller;
        private readonly Deserializer _deserializer;
        private readonly List<Municipio> _municipios;

        public TarefaUVDiario(ILogger<TarefaUVDiario> logger, AppDbContext appDb, ClienteOpenUV apiCaller, Deserializer deserializer)
        {
            _logger = logger;
            _appDb = appDb;
            _apiCaller = apiCaller;
            _deserializer = deserializer;
            _municipios = _appDb.Municipios.ToList();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Iniciando TarefaUVDiario!");
            string previsaoTexto = "";
            try
            {
                foreach (Municipio municipio in _municipios)
                {
                    _logger.LogInformation($"Obtendo previsão para o município: {municipio.Nome}.");
                    previsaoTexto = await _apiCaller.ChamarApiAsync(municipio);
                    municipio.PrevisoesOpenUV = _deserializer.ConverterOpenUV(previsaoTexto);
                    foreach (PrevisaoOpenUV previsao in municipio.PrevisoesOpenUV)
                    {
                        await _appDb.PrevisoesOpenUV.AddAsync(previsao);
                    }
                    _logger.LogInformation($"Previsão adicionada!");
                    await _appDb.SaveChangesAsync(context.CancellationToken);
                    _logger.LogInformation($"Previsão salva!");
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