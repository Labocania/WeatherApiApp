using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiApp.Data;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class ServicoMunicipio
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ServicoMunicipio> _logger;
        public List<Municipio> Municipios { get; private set; }

        public ServicoMunicipio(AppDbContext context, ILogger<ServicoMunicipio> logger)
        {
            _context = context;
            _logger = logger;
            Municipios = _context.Municipios.ToList();
        }

        public Dictionary<string, int> PegaSelecaoMunicipios()
        {
            Dictionary<string, int> valores = new Dictionary<string, int>();
            foreach (Municipio municipio in Municipios)
            {
                valores.Add(municipio.Nome.Replace(" ", "-"), municipio.ID);
            }
            return valores;
        }

        public async Task<ClimaAtualOpenW> PegaClimaAtualAsync(int id)
        {
            return await _context.ClimasAtuaisOpenW.Where(clima => clima.Municipio.ID == id)
                .Include(clima => clima.Condicoes)
                .Include(clima => clima.Chuva)
                .OrderByDescending(clima => clima.ID)
                .FirstAsync();
        }

        public async Task<PrevisaoDiariaOpenW> PegaPrevisaoWAsync(int id)
        {
            return await _context.PrevisoesDiariasOpenW.Where(previsao => previsao.Municipio.ID == id)
                .Include(previsao => previsao.Condicoes)
                .Include(previsao => previsao.Temperatura)
                .Include(previsao => previsao.SensacaoTermica)
                .Include(previsao => previsao.Alertas)
                .OrderByDescending(previsao => previsao.ID)
                .FirstAsync();
        }

        public async Task<PrevisaoOpenUV> PegaPrevisaoUVAsync(int id)
        {
            return await _context.PrevisoesOpenUV.Where(previsao => previsao.Municipio.ID == id).OrderByDescending(previsao => previsao.ID).FirstAsync();
        }
    }
}
