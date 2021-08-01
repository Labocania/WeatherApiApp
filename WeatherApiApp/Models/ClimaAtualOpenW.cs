using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class ClimaAtualOpenW
    {
        public int ID { get; set; }

        public Municipio Municipio { get; set; }

        [DataMember(Name = "weather")]
        public ICollection<Condicao> Condicoes { get; set; }

        [DataMember(Name = "dt")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
        [DataType(DataType.Date)]
        public System.DateTime DataPrevisao { get; set; }

        [DataMember(Name = "sunrise")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
        [DataType(DataType.Date)]
        public System.DateTime DataAmanhecer { get; set; }

        [DataMember(Name = "sunset")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
        [DataType(DataType.Date)]
        public System.DateTime DataEntardecer { get; set; }

        [DataMember(Name = "feels_like")]
        public float SensacaoTermica { get; set; }

        [DataMember(Name = "pressure")]
        public float Pressao { get; set; }

        [DataMember(Name = "humidity")]
        public float Humidade { get; set; } 

        [DataMember(Name = "dew_point")]
        public float PontoOrvalho { get; set; }

        [DataMember(Name = "uvi")]
        public float IndiceUV { get; set; }

        [DataMember(Name = "clouds")]
        public float CoberturaNuvem { get; set; }

        [DataMember(Name = "visibility")]
        public float Visibilidade { get; set; }
    }
}
