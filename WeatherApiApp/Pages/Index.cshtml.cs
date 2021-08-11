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

        [BindProperty(SupportsGet = true)]
        public int MunicipioIdInput { get; set; }

        [BindProperty]
        public ClimaAtualOpenW ClimaAtual { get; private set; }
        [BindProperty]
        public ICollection<SelectListItem> IndiceMunicipios { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, ServicoMunicipio servicoMunicipio)
        {
            _logger = logger;
            _servicoMunicipio = servicoMunicipio;
            IndiceMunicipios = servicoMunicipio.PegaSelecaoMunicipios();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ClimaAtual = await _servicoMunicipio.PegaClimaAtualAsync(MunicipioIdInput);
            return Page();
        }
    }
}
