using Microsoft.AspNetCore.Mvc.Rendering;
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

        public ICollection<SelectListItem> PegaSelecaoMunicipios()
        {
            ICollection<SelectListItem> indiceMunicipios = new List<SelectListItem>();
            foreach (var municipio in Municipios)
            {
                indiceMunicipios.Add(item: new SelectListItem { Value = municipio.ID.ToString(), Text = municipio.Nome });
            }

            return indiceMunicipios;
        }

        public async Task<ClimaAtualOpenW> PegaClimaAtualAsync(int id)
        {
            return await _context.ClimasAtuaisOpenW
                .Include(clima => clima.Condicoes)
                .Include(clima => clima.Municipio).Where(clima => clima.Municipio.ID == id)
                .OrderBy(clima => clima.DataPrevisao)
                .LastAsync();

           /* return await _context.Municipios
                .Where(x => x.ID == id)
                .Include(municipio => municipio.ClimasAtuaisOpenW
                                        .Where(clima => clima.Municipio.ID == id)
                                        .TakeLast(1))
                .SingleOrDefaultAsync();  */            
        }
    }
}
