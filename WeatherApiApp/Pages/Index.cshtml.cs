using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WeatherApiApp.Models;

namespace WeatherApiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public int municipioId { get; set; }
        public IList<PrevisaoOpenUV> PrevisoesOpenUV { get; set; }

        public void OnGet()
        {

        }
    }
}
