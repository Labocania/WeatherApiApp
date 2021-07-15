using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WeatherApiApp.Services
{
    public class ApiCaller
    {
        private readonly ApiUrls _urls;
        private readonly IConfiguration _config;

        public ApiCaller(IOptions<ApiUrls> urls, IConfiguration config)
        {
            _urls = urls.Value;
            _config = config;
        }

        public string OpenWUrl { get; private set; }

        public void CriarOpenWUrl(string lat, string lon, string exlcude = "")
        {
            OpenWUrl = $"{_urls.BaseOpenWUrl}lat={lat}&lon={lon}&exclude={exlcude}&appid={_config["OpenUVKey"]}";
        }
    }
}
