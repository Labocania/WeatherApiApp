using Microsoft.EntityFrameworkCore;
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
        public AppDbContext Context { get; private set; }
        public List<Municipio> Municipios { get; private set; }

        public ServicoMunicipio(AppDbContext context)
        {
            Context = context;
            Municipios = Context.Municipios.ToList();
        }

        public Dictionary<string, int> PegaMunicipioNomeId()
        {
            Dictionary<string, int> valores = new();
            foreach (Municipio municipio in Municipios)
            {
                valores.Add(municipio.Nome.Replace(" ", "-"), municipio.ID);
            }
            return valores;
        }

        public async Task<PrevisaoHoraOpenW> PegaClimaAtualAsync(int id)
        {
            return await Context.ClimasAtuaisOpenW.Where(clima => clima.Municipio.ID == id)
                .Include(clima => clima.Condicoes)
                .Include(clima => clima.Chuva)
                .OrderByDescending(clima => clima.ID)
                .FirstOrDefaultAsync();
        }

        public async Task<PrevisaoDiariaOpenW> PegaPrevisaoWAsync(int id)
        {
            return await Context.PrevisoesDiariasOpenW.Where(previsao => previsao.Municipio.ID == id)
                .Include(previsao => previsao.Condicoes)
                .Include(previsao => previsao.Temperatura)
                .Include(previsao => previsao.SensacaoTermica)
                .Include(previsao => previsao.Alertas)
                .OrderByDescending(previsao => previsao.ID)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PrevisaoDiariaOpenW>> PegaHistoricoWAsync(int id)
        {
            DateTime cincoDiasAtras = DateTime.Today.AddDays(-5);

            return await Context.PrevisoesDiariasOpenW.Where(previsao => previsao.Municipio.ID == id && previsao.DataPrevisao.CompareTo(cincoDiasAtras) > 0)
                .Include(previsao => previsao.Condicoes)
                .Include(previsao => previsao.Temperatura)
                .Include(previsao => previsao.SensacaoTermica)
                .Include(previsao => previsao.Alertas)
                .OrderBy(previsao => previsao.ID)
                .ToListAsync();
        }

        public async Task<List<PrevisaoOpenUV>> PegaPrevisaoUVAsync(int id)
        {
            IQueryable<PrevisaoOpenUV> query = Context.PrevisoesOpenUV.Where(previsao => previsao.Municipio.ID == id && previsao.Horario.Day == DateTime.Now.Day);
            if (!query.Any())
            {
                query = Context.PrevisoesOpenUV.Where(previsao => previsao.Municipio.ID == id && previsao.Horario.Day == DateTime.Today.AddDays(-1.0).Day);
            }

            return await query.OrderBy(previsao => previsao.Horario).ToListAsync();
        }

        public async Task<WeatherBit> PegaClimaBitAsync(int id)
        {
            return await Context.WeatherBit.Where(clima => clima.Municipio.ID == id)
                        .OrderByDescending(clima => clima.ID)
                        .FirstOrDefaultAsync();
        }
    }
}
