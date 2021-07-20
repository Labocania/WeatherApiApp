using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WeatherApiApp.Models;
using WeatherApiApp.Services;

namespace WeatherApiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApiDb _apiDb;
        private readonly ApiCaller _apiCaller;
        private readonly Deserializer _deserializer;
        
        public IndexModel(ILogger<IndexModel> logger, ApiDb apiDb, ApiCaller apiCaller, Deserializer deserializer)
        {
            _logger = logger;
            _apiDb = apiDb;
            _apiCaller = apiCaller;
            _deserializer = deserializer;
        }

        [BindProperty(SupportsGet = true)]
        public int municipioId { get; set; }
        public IList<PrevisaoOpenUV> PrevisoesOpenUV { get; set; }

        public void OnGet()
        {
            // Usar exception filter?
            try
            {
                Municipio municipio = _apiDb.ObterMunicipio(municipioId);
                string previsaoTexto = _apiCaller.RequisicaoOpenUV(municipio);
                _apiDb.SalvarRequisicaoOpenUV(municipio.ID);
                PrevisoesOpenUV = _deserializer.ConverterOpenUV(previsaoTexto);
                foreach (PrevisaoOpenUV previsao in PrevisoesOpenUV)
                {
                    _apiDb.SalvarPrevisaoOpenUV(previsao);
                }
                // retorna previsao
            }
            catch(ArgumentNullException ex)
            {
                // Municipio null
                Console.WriteLine(ex.Message);
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                // Adicionar mais catch
                // Temporário!
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
