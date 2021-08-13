﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class ClimaAtualOpenW
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public Municipio Municipio { get; set; }

        [JsonPropertyName("weather")]
        public ICollection<Condicao> Condicoes { get; set; }

        [JsonPropertyName("rain")]
        public Chuva Chuva { get; set; }
        
        [JsonPropertyName("dt")]
        [DataType(DataType.Date)]
        public System.DateTime DataPrevisao { get; set; }

        [JsonPropertyName("sunrise")]
        [DataType(DataType.Date)]
        public System.DateTime DataAmanhecer { get; set; }

        [JsonPropertyName("sunset")]
        [DataType(DataType.Date)]
        public System.DateTime DataEntardecer { get; set; }

        [JsonPropertyName("feels_like")]
        public float SensacaoTermica { get; set; }

        [JsonPropertyName("pressure")]
        public float Pressao { get; set; }

        [JsonPropertyName("humidity")]
        public float Humidade { get; set; } 

        [JsonPropertyName("dew_point")]
        public float PontoOrvalho { get; set; }

        [JsonPropertyName("uvi")]
        public float IndiceUV { get; set; }

        [JsonPropertyName("clouds")]
        public float CoberturaNuvem { get; set; }

        [JsonPropertyName("visibility")]
        public float Visibilidade { get; set; }
    }
}
