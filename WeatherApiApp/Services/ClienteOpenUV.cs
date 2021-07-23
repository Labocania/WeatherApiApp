using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class ClienteOpenUV : IClienteApi
    {
        private readonly ApiUrlBind _urls;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClienteOpenUV> _logger;

        public ClienteOpenUV(IOptions<ApiUrlBind> urls, IConfiguration config, HttpClient httpClient, ILogger<ClienteOpenUV> logger)
        {
            _urls = urls.Value;
            _config = config;
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.BaseAddress = new System.Uri(_urls.BaseOpenUVUrl);
            _httpClient.DefaultRequestHeaders.Add("x-access-token", _config["OpenUVKey"]);
        }

        public async Task<string> ChamarApiAsync(Municipio municipio, string excluir = "")
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(CriaUrl(municipio.Latitude, municipio.Longitude, municipio.Altitude));
            _logger.LogInformation($"Status Code: {resposta.StatusCode}");
            _logger.LogInformation($"Reason Phrase: {resposta.ReasonPhrase}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsStringAsync();
        }

        public string CriaUrl(float latitude, float longitude, float altitude = 0, string exlcuir = "")
        {
            return $"forecast?lat={latitude.ToString("0.00")}&lng={longitude.ToString("0.00")}&alt={altitude.ToString("0.00")}";
        }
    }
}
