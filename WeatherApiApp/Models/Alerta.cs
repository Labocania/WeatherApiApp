using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Alerta
    {
        public int ID { get; set; }
        public int PrevisaoOpenWId { get; set; }
        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }

        [DataMember(Name = "sender_name")]
        public string AlertaFonte { get; set; }

        [DataMember(Name = "event")]
        public string Evento { get; set; }

        [DataMember(Name = "start")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataMember(Name = "end")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [DataType(DataType.Date)]
        public DateTime DataTermino { get; set; }

        [DataMember(Name = "description")]
        public string Descricao { get; set; }
    }
}
