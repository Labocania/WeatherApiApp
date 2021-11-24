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

        private IQueryable<Municipio> MunicipioQueryAsync(int id)
        {
            return Context.Municipios.AsNoTracking()
                .Where(municipio => municipio.ID == id)
                .Select(municipio => new Municipio
                    {
                        PrevisoesOpenUV = municipio.PrevisoesOpenUV,
                        PrevisoesDiariasOpenW = municipio.PrevisoesDiariasOpenW,
                        PrevisoesHoraOpenW = municipio.PrevisoesHoraOpenW,
                    }
                );
        }

        public async Task<PrevisaoHoraOpenW> PegaPrevisaoHoraAsync(int id)
        {
            return await Context.ClimasAtuaisOpenW
                .AsSingleQuery()
                .Where(clima => clima.Municipio.ID == id)
                .OrderByDescending(clima => clima.ID)
                .Select(clima => new PrevisaoHoraOpenW
                {
                    DataPrevisao = clima.DataPrevisao,
                    Condicoes = clima.Condicoes.Select(cond => new Condicao { Icone = cond.Icone, Detalhes = cond.Detalhes}).ToList(),
                    Chuva = clima.Chuva,
                    Temperatura = clima.Temperatura,
                    SensacaoTermica = clima.SensacaoTermica,
                    ProbPrecipitacao = clima.ProbPrecipitacao,
                    Humidade = clima.Humidade,
                    Pressao = clima.Pressao,
                    PontoOrvalho = clima.PontoOrvalho,
                    IndiceUV = clima.IndiceUV,
                    Visibilidade = clima.Visibilidade
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PrevisaoDiariaOpenW> PegaPrevisaoWAsync(int id)
        {
            return await Context.PrevisoesDiariasOpenW
                .AsSingleQuery()
                .Where(previsao => previsao.Municipio.ID == id)
                .OrderByDescending(previsao => previsao.ID)
                .Select(previsao => new PrevisaoDiariaOpenW
                {
                    DataPrevisao = previsao.DataPrevisao,
                    Temperatura = new Temperatura() { TempDiaria = previsao.Temperatura.TempDiaria, TempMax = previsao.Temperatura.TempMax, TempMin = previsao.Temperatura.TempMin },
                    SensacaoTermica = previsao.SensacaoTermica,
                    Condicoes = previsao.Condicoes.Select(cond => new Condicao { Icone = cond.Icone, Detalhes = cond.Detalhes }).ToList(),
                    ProbPrecipitacao = previsao.ProbPrecipitacao,
                    Precipitacao = previsao.Precipitacao,
                    Neve = previsao.Neve,
                    CoberturaNuvem = previsao.CoberturaNuvem,
                    IndiceUV = previsao.IndiceUV,
                    Humidade = previsao.Humidade,
                    DataAmanhecer = previsao.DataAmanhecer,
                    DataEntardecer = previsao.DataEntardecer,
                    Pressao = previsao.Pressao,
                    PontoOrvalho = previsao.PontoOrvalho,
                    Alertas = previsao.Alertas
                })
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
                .AsNoTracking()
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
                        .AsNoTracking()
                        .OrderByDescending(clima => clima.ID)
                        .FirstOrDefaultAsync();
        }
    }
}
