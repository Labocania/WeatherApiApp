namespace WeatherApiApp.Services
{
    public interface IApiUrl
    {
        public string CriaUrl(float latitude, float longitude, float altitude = 0, string exlcuir = "");
        public string ApiKey();
    }
}
