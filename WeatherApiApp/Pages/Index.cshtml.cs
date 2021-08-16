using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
        public PrevisaoDiariaOpenW PrevisaoDiaria { get; private set; }
        [BindProperty]
        public List<ViewOpenUV> ViewOpenUV { get; private set; } = new List<ViewOpenUV>();
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
            PrevisaoDiaria = await _servicoMunicipio.PegaPrevisaoWAsync(Municipios[nome]);
            foreach (PrevisaoOpenUV item in await _servicoMunicipio.PegaPrevisaoUVAsync(Municipios[nome]))
            {
                ViewOpenUV.Add(new ViewOpenUV(item));
            }
            return Page();
        }
    }
}
