using System.Net.Http;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public class ApiCaller
    {
        private readonly HttpClient _httpClient;
        private readonly OpenUVUrl _openUVUrl;
        private readonly OpenWUrl _openWUrl;

        public ApiCaller(HttpClient httpClient, OpenUVUrl openUVUrl, OpenWUrl openWUrl)
        {
            _httpClient = httpClient;
            _openUVUrl = openUVUrl;
            _openWUrl = openWUrl;
        }

        public string RequisicaoOpenUV(Municipio municipio)
        {
            string url = _openUVUrl.CriaUrl(municipio.Latitude, municipio.Longitude, municipio.Altitude);
            return ChamarApiAsync(url, _openUVUrl.ApiKey()).Result;
        }

        public string RequisicaoOpenW(Municipio municipio, string excluir)
        {
            string url = _openWUrl.CriaUrl(municipio.Latitude, municipio.Longitude, municipio.Altitude, excluir);
            return ChamarApiAsync(url, _openWUrl.ApiKey()).Result;
        }

        private async Task<string> ChamarApiAsync(string url, string token)
        {
            HttpRequestMessage mensagem = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri(url)
            };

            if (!string.IsNullOrEmpty(token))
            {
                mensagem.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", token);
            }

            HttpResponseMessage resposta = await _httpClient.SendAsync(mensagem);
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadAsStringAsync();
        }
    }
}
