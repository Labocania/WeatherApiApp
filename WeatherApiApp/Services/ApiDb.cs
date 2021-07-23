using System.Collections.Generic;
using System.Linq;
using WeatherApiApp.Data;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class ApiDb
    {
        private readonly AppDbContext _context;
        public ApiDb(AppDbContext context)
        {
            _context = context;
        }

        public Municipio ObterMunicipio(int id)
        {
            Municipio municipio = _context.Municipios.Find(id);
            if (municipio == null)
            {
                throw new System.ArgumentNullException("Município não encontrado");
            }
            return municipio;
        }

        public List<Municipio> ObterTodosMunicipios()
        {
            return _context.Municipios.ToList();
        }

        public ReqOpenUV SalvarRequisicaoOpenUV(int municipioId)
        {
            ReqOpenUV requisicao = new ReqOpenUV { HorarioRequisicao = System.DateTime.Now };
            _context.RequisicoesOpenUV.AddAsync(requisicao);
            _context.SaveChangesAsync();
            return requisicao;
        }

        public void SalvarPrevisaoOpenUV(PrevisaoOpenUV previsao)
        {
            _context.PrevisoesOpenUV.AddAsync(previsao);
            _context.SaveChangesAsync();
        }

        public void SalvarListaPrevisaoOpenUV(IList<PrevisaoOpenUV> previsoes)
        {
            foreach (PrevisaoOpenUV previsao in previsoes)
            {
                SalvarPrevisaoOpenUV(previsao);
            }
        }
    }
}
