using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WeatherApiApp.Services
{
    public class OpenUVUrl : IApiUrl
    {
        private readonly ApiUrlBind _urls;
        private readonly IConfiguration _config;

        public OpenUVUrl(IOptions<ApiUrlBind> urls, IConfiguration config)
        {
            _urls = urls.Value;
            _config = config;
        }

        public string ApiKey()
        {
            return _config["OpenUVKey"];
        }

        public string CriaUrl(float latitude, float longitude, float altitude = 0, string exlcuir = "")
        {
            return $"{_urls.OpenUVUrl}lat={latitude}&lng={longitude}&alt={altitude}";
        }
    }
}
