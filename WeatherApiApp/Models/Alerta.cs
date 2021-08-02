using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Alerta
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }

        [JsonPropertyName("sender_name")]
        public string AlertaFonte { get; set; }

        [JsonPropertyName("event")]
        public string Evento { get; set; }

        [JsonPropertyName("start")]
        [DataType(DataType.Date)]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime DataInicio { get; set; }

        [JsonPropertyName("end")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        [DataType(DataType.Date)]
        public DateTime DataTermino { get; set; }

        [JsonPropertyName("description")]
        public string Descricao { get; set; }
    }
}
