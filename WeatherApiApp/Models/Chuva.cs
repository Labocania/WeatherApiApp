using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Chuva
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public int ClimaAtualOpenWId { get; set; }
        [JsonIgnore]
        public ClimaAtualOpenW ClimaAtualOpenW { get; set; }

        [JsonPropertyName("1h")]
        public float ChuvaUltimaHora { get; set; }
    }
}