using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WeatherApiApp.Data;
using WeatherApiApp.Models;

namespace WeatherApiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public int MunicipioIdInput { get; set; }

        [BindProperty]
        public List<ClimaAtualOpenW> ClimasAtuais { get; private set; }
        [BindProperty]
        public ICollection<SelectListItem> IndiceMunicipios { get; private set; } = new List<SelectListItem>();

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            ClimasAtuais = _context.ClimasAtuaisOpenW.ToList();
            foreach (Municipio municipio in _context.Municipios.ToList())
            {
                IndiceMunicipios.Add(item: new SelectListItem { Value = municipio.ID.ToString(), Text = municipio.Nome });
            }
        }

        public void OnGet()
        {

        }
    }
}
