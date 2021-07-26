using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WeatherApiApp.Models
{
    [DataContract]
    public class Condicao
    {
        public int ID { get; set; }

        [DataMember(Name = "main")]
        public string Principal { get; set; }

        [DataMember(Name = "description")]
        public string Detalhes { get; set; }

        [DataMember(Name = "icon")]
        public string Icone { get; set; }

        public PrevisaoDiariaOpenW PrevisaoOpenW { get; set; }
    }
}
