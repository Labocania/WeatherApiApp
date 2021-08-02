using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class SensacaoTermica
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public int PrevisaoOpenWId { get; set; }
        [JsonIgnore]
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }

        [JsonPropertyName("day")]
        public float SensDiaria { get; set; }

        [JsonPropertyName("morn")]
        public float SensManha { get; set; }

        [JsonPropertyName("eve")]
        public float SensEntardecer { get; set; }

        [JsonPropertyName("night")]
        public float SensNoite { get; set; }
    }
}
