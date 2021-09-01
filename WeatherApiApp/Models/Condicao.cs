using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Condicao
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }
        [JsonIgnore]
        public PrevisaoHoraOpenW ClimaAtualOpenW { get; set; }

        [JsonPropertyName("main")]
        public string Principal { get; set; }

        [JsonPropertyName("description")]
        public string Detalhes { get; set; }

        [JsonPropertyName("icon")]
        public string Icone { get; set; }
    }
}
