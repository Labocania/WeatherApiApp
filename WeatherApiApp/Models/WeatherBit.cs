using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class WeatherBit
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public Municipio Municipio { get; set; }

        [JsonPropertyName("ts")]
        [DataType(DataType.Date)]
        public System.DateTime DataPrevisao { get; set; }

        [JsonPropertyName("temp")]
        public float Temperatura { get; set; }

        [JsonPropertyName("app_temp")]
        public float SensacaoTermica { get; set; }

        [JsonPropertyName("rh")]
        public float Humidade { get; set; } // %

        [JsonPropertyName("dewpt")]
        public float PontoOrvalho { get; set; }

        [JsonPropertyName("clouds")]
        public float CoberturaNuvem { get; set; } // %

        [JsonPropertyName("vis")]
        public float Visibilidade { get; set; } // km

        [JsonPropertyName("precip")]
        public float Precipitacao { get; set; } // mm/hr

        [JsonPropertyName("uv")]
        public float IndiceUV { get; set; }

        [JsonPropertyName("aqi")]
        public float QualidadeAr { get; set; } //  [US - EPA standard 0 - +500]

    }
}
