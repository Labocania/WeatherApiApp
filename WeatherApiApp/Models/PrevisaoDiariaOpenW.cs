using Newtonsoft.Json.Converters;
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
        public int ID { get; set; }

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

        [DataMember(Name = "moon_phase")]
        public float FaseLunar { get; set; }

        [DataMember(Name = "temp")]
        public Temperatura Temperatura { get; set; }

        [DataMember(Name = "feels_like")]
        public SensacaoTermica SensacaoTermica { get; set; }

        [DataMember(Name = "pressure")]
        public float Pressao { get; set; }

        [DataMember(Name = "humidity")]
        public float Humidade { get; set; } // %

        [DataMember(Name = "dew_point")]
        public float PontoOrvalho { get; set; }

        [DataMember(Name = "weather")]
        public ICollection<Condicao> Condicoes { get; set; }

        [DataMember(Name = "clouds")]
        public float CoberturaNuvem { get; set; } // %

        [DataMember(Name = "uvi")]
        public float IndiceUV { get; set; }

        [DataMember(Name = "pop")]
        public float ProbPrecipitacao { get; set; }

        [DataMember(Name = "rain")]
        [DefaultValue(0.0f)]
        public float Precipitacao { get; set; }

        [DataMember(Name = "snow")]
        [DefaultValue(0.0f)]
        public float Neve { get; set; }

        [DataMember(Name = "alerts")]
        public ICollection<Alerta> Alertas { get; set; }
        public Municipio Municipio { get; set; }
    }
}
