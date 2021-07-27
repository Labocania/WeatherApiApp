using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class ClienteOpenWeather : IClienteApi
    {
        private readonly ApiUrlBind _urls;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClienteOpenUV> _logger;

        public ClienteOpenWeather(IOptions<ApiUrlBind> urls, IConfiguration config, HttpClient httpClient, ILogger<ClienteOpenUV> logger)
        {
            _urls = urls.Value;
            _config = config;
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.BaseAddress = new System.Uri(_urls.BaseOpenWUrl);
        }

        public async Task<string> ChamarApiAsync(Municipio municipio, string excluir = "")
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(CriaUrl(municipio.Latitude, municipio.Longitude, municipio.Altitude, excluir));
            _logger.LogInformation($"Status Code: {resposta.StatusCode}");
            _logger.LogInformation($"Reason Phrase: {resposta.ReasonPhrase}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsStringAsync();
        }

        public string CriaUrl(float latitude, float longitude, float altitude = 0, string exlcuir = "")
        {
            return $"onecall?lat={latitude}&lon={longitude}&exclude={exlcuir}&units=metric&lang=pt_br&appid={_config["OpenWKey"]}";
        }
    }
}
