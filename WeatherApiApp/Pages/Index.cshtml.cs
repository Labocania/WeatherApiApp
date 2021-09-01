using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApiApp.Models;
using WeatherApiApp.Services;

namespace WeatherApiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ServicoMunicipio _servicoMunicipio;

        [BindProperty]
        public PrevisaoHoraOpenW PrevisaoHora { get; private set; }
        [BindProperty]
        public WeatherBit ClimaBit { get; private set; }
        [BindProperty]
        public PrevisaoDiariaOpenW PrevisaoDiaria { get; private set; }
        [BindProperty]
        public List<PrevisaoDiariaOpenW> HistoricoDiarioW { get; private set; }
        [BindProperty]
        public List<ViewOpenUV> ViewOpenUV { get; private set; } = new List<ViewOpenUV>();
        [BindProperty]
        public Dictionary<string, int> Municipios { get; private set; }

        public IndexModel(ServicoMunicipio servicoMunicipio)
        {
            _servicoMunicipio = servicoMunicipio;
            Municipios = servicoMunicipio.PegaMunicipioNomeId();
        }

        public async Task<IActionResult> OnGetAsync(string nome = "Rio-Branco")
        {
            PrevisaoHora = await _servicoMunicipio.PegaPrevisaoHoraAsync(Municipios[nome]);
            PrevisaoDiaria = await _servicoMunicipio.PegaPrevisaoWAsync(Municipios[nome]);
            foreach (PrevisaoOpenUV item in await _servicoMunicipio.PegaPrevisaoUVAsync(Municipios[nome]))
            {
                ViewOpenUV.Add(new ViewOpenUV(item));
            }
            HistoricoDiarioW = await _servicoMunicipio.PegaHistoricoWAsync(Municipios[nome]);
            ClimaBit = await _servicoMunicipio.PegaClimaBitAsync(Municipios[nome]);
            return Page();
        }
    }
}
