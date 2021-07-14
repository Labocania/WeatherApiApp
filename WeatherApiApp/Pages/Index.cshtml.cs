using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiApp.Services;

namespace WeatherApiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ApiCaller ApiCaller { get; }

        public IndexModel(ILogger<IndexModel> logger, IOptions<ApiCaller> options)
        {
            _logger = logger;
            ApiCaller = options.Value;
        }

        public void OnGet()
        {

        }
    }
}
