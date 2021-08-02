using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Temperatura
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public int PrevisaoOpenWId { get; set; }
        [JsonIgnore]
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }

        [JsonPropertyName("day")]
        public float TempDiaria { get; set; }

        [JsonPropertyName("morn")]
        public float TempManha { get; set; }

        [JsonPropertyName("eve")]
        public float TempEntardecer { get; set; }

        [JsonPropertyName("night")]
        public float TempNoite { get; set; }

        [JsonPropertyName("min")]
        public float TempMin { get; set; }

        [JsonPropertyName("max")]
        public float TempMax { get; set; }
    }
}
