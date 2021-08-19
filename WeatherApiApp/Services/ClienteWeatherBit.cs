using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class ClienteWeatherBit : IClienteApi
    {
        private readonly ApiUrlBind _urls;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClienteOpenUV> _logger;

        public ClienteWeatherBit(IOptions<ApiUrlBind> urls, IConfiguration config, HttpClient httpClient, ILogger<ClienteOpenUV> logger)
        {
            _urls = urls.Value;
            _config = config;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_urls.BaseWeatherBitUrl);
            _logger = logger;
        }

        public async Task<string> ChamarApiAsync(Municipio municipio, string excluir = "")
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(CriaUrl(municipio.Latitude, municipio.Longitude));
            _logger.LogInformation($"Status Code: {resposta.StatusCode}");
            _logger.LogInformation($"Reason Phrase: {resposta.ReasonPhrase}");
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsStringAsync();
        }

        public string CriaUrl(float latitude, float longitude, float altitude = 0, string exlcuir = "")
        {
            return $"current?lat={latitude.ToString("0.00", CultureInfo.InvariantCulture)}&lon={longitude.ToString("0.00", CultureInfo.InvariantCulture)}&lang=pt&key={_config["WeatherBitKey"]}";
        }
    }
}
