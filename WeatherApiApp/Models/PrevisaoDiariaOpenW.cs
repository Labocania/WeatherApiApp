using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class PrevisaoDiariaOpenW
    {
        public int ID { get; set; }

        [DataMember(Name = "dt")]
        [DataType(DataType.Date)]
        public System.DateTime DataPrevisao { get; set; }

        [DataMember(Name = "sunrise")]
        [DataType(DataType.Date)]
        public System.DateTime DataAmanhecer { get; set; }

        [DataMember(Name = "sunset")]
        [DataType(DataType.Date)]
        public System.DateTime DataEntardecer { get; set; }

        [DataMember(Name = "moon_phase")]
        public float FaseLunar { get; set; }

        [DataMember(Name = "day")]
        public float TempDiaria { get; set; }

        [DataMember(Name = "morn")]
        public float TempManha { get; set; }

        [DataMember(Name = "eve")]
        public float TempEntardecer { get; set; }

        [DataMember(Name = "night")]
        public float TempNoite { get; set; }

        [DataMember(Name = "min")]
        public float TempMin { get; set; }

        [DataMember(Name = "max")]
        public float TempMax { get; set; }

        [DataMember(Name = "day")]
        public float SensDiaria { get; set; }

        [DataMember(Name = "morn")]
        public float SensManha { get; set; }

        [DataMember(Name = "eve")]
        public float SensEntardecer { get; set; }

        [DataMember(Name = "night")]
        public float SensNoite { get; set; }

        [DataMember(Name = "pressure")]
        public float Pressao { get; set; }

        [DataMember(Name = "humidity")]
        public int Humidade { get; set; } // %

        [DataMember(Name = "dew_point")]
        public float PontoOrvalho { get; set; }

        [DataMember(Name = "clouds")]
        public int CoberturaNuvem { get; set; } // %

        [DataMember(Name = "uvi")]
        public float IndiceUV { get; set; }

        [DataMember(Name = "pop")]
        public int ProbPrecipitacao { get; set; }

        [DataMember(Name = "rain")]
        [DefaultValue(0.0f)]
        public float Precipitacao { get; set; }

        [DataMember(Name = "snow")]
        [DefaultValue(0.0f)]
        public float Neve { get; set; }

        public Municipio Municipio { get; set; }

        public ICollection<Condicao> Condicoes { get; set; }

        public Alerta Alerta { get; set; }
    }
}
