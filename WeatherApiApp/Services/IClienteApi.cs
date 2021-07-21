using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.Services
{
    public interface IClienteApi
    {
        public string CriaUrl(float latitude, float longitude, float altitude = 0, string exlcuir = "");
        public Task<string> ChamarApiAsync(Municipio municipio, string excluir = "");
    }
}
