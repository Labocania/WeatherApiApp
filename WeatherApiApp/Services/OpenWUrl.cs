using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WeatherApiApp.Services
{
    public class OpenWUrl : IApiUrl
    {
        private readonly ApiUrlBind _urls;
        private readonly IConfiguration _config;

        public OpenWUrl(IOptions<ApiUrlBind> urls, IConfiguration config)
        {
            _urls = urls.Value;
            _config = config;
        }

        public string ApiKey()
        {
            return "";
        }

        public string CriaUrl(float latitude, float longitude, float altitude = 0, string exlcuir = "")
        {
            return $"{_urls.BaseOpenWUrl}lat={latitude}&lon={longitude}&exclude={exlcuir}&appid={_config["OpenWKey"]}";
        }
    }
}
