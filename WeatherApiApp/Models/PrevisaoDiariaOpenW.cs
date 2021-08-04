using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class PrevisaoDiariaOpenW
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public Municipio Municipio { get; set; }

        [JsonPropertyName("alerts")]
        public ICollection<Alerta> Alertas { get; set; }

        [JsonPropertyName("temp")]
        public Temperatura Temperatura { get; set; }

        [JsonPropertyName("feels_like")]
        public SensacaoTermica SensacaoTermica { get; set; }

        [JsonPropertyName("weather")]
        public ICollection<Condicao> Condicoes { get; set; }

        [JsonPropertyName("dt")]
        [DataType(DataType.Date)]
        public System.DateTime DataPrevisao { get; set; }

        [JsonPropertyName("sunrise")]
        [DataType(DataType.Date)]
        public System.DateTime DataAmanhecer { get; set; }

        [JsonPropertyName("sunset")]
        [DataType(DataType.Date)]
        public System.DateTime DataEntardecer { get; set; }

        [JsonPropertyName("moon_phase")]
        public float FaseLunar { get; set; }

        [JsonPropertyName("pressure")]
        public float Pressao { get; set; }

        [JsonPropertyName("humidity")]
        public float Humidade { get; set; } 

        [JsonPropertyName("dew_point")]
        public float PontoOrvalho { get; set; }

        [JsonPropertyName("clouds")]
        public float CoberturaNuvem { get; set; } 

        [JsonPropertyName("uvi")]
        public float IndiceUV { get; set; }

        [JsonPropertyName("pop")]
        public float ProbPrecipitacao { get; set; }

        [JsonPropertyName("rain")]
        [DefaultValue(0.0f)]
        public float Precipitacao { get; set; }

        [JsonPropertyName("snow")]
        [DefaultValue(0.0f)]
        public float Neve { get; set; }
    }
}
