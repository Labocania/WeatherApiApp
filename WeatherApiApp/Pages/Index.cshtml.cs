using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiApp.Models;
using WeatherApiApp.Services;

namespace WeatherApiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ServicoMunicipio _servicoMunicipio;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public ClimaAtualOpenW ClimaAtual { get; private set; }
        [BindProperty]
        public Dictionary<string, int> Municipios { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, ServicoMunicipio servicoMunicipio)
        {
            _logger = logger;
            _servicoMunicipio = servicoMunicipio;
            Municipios = servicoMunicipio.PegaSelecaoMunicipios();
        }

        public async Task<IActionResult> OnGetAsync(string nome = "Rio-Branco")
        {
            ClimaAtual = await _servicoMunicipio.PegaClimaAtualAsync(Municipios[nome]);
            return Page();
        }
    }
}
